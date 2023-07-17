using AnimalShelter.WebApi.Common.Exceptions;

namespace AnimalShelter.WebApi.Services.Upload;

/// <summary>
/// Implementation of <see cref="IUploadService" />
/// </summary>
public class UploadService : IUploadService
{

	#region IUploadService Members
	public async Task<string> SaveFileAsync(string base64, string id, string folderPath)
	{
		// split base64 string to format and data
		var data = base64.Split(',');

		// check if data is valid
		if (data.Length != 2)
		{
			throw new InvalidPhotoException("Not found image format or image data");
		}

		// convert image data to bytes and get image format
		byte[] imageBytes;
		string fileName;
		try
		{
			var extension = data[0].Split(';')[0].Split('/')[1];
			imageBytes = Convert.FromBase64String(data[1]);
			fileName = $"{id}.{extension}";
		}
		catch
		{
			throw new InvalidPhotoException("Can't convert image");
		}

		// create directory if not exist
		var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath);
		CreateDirectory(directory);

		// save image to server
		var uploadPath = Path.Combine(directory, fileName);
		await File.WriteAllBytesAsync(uploadPath, imageBytes);

		// return path to image
		var filePath = Path.Combine(folderPath, fileName);
		return filePath;
	}
	#endregion

	/// <summary>
	/// Create directory if not exist
	/// </summary>
	/// <param name="directory">Path to directory</param>
	private static void CreateDirectory(string directory)
	{
		if (Directory.Exists(directory) == false)
		{
			Directory.CreateDirectory(directory);
		}
	}
}
namespace AnimalShelter.WebApi.Services.Upload;

/// <summary>
/// Service for uploading files to the server
/// </summary>
public interface IUploadService
{
	/// <summary>
	/// Saves a file to the server
	/// </summary>
	/// <param name="base64">Photo encoded to base64</param>
	/// <param name="id">Id of entity</param>
	/// <param name="folderPath">Path to entity type folder</param>
	/// <returns></returns>
	Task<string> SaveFileAsync(string base64, string id, string folderPath);
}
namespace AnimalShelter.WebApi.Common.Exceptions;

public class InvalidPhotoException : Exception
{
	public InvalidPhotoException(string message) : base($"Photo encoding is invalid. {message}")
	{

	}
}
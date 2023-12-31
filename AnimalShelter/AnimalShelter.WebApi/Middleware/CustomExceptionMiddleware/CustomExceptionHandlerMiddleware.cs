﻿using System.Net;
using System.Text.Json;
using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.WebApi.Common.Exceptions;
using FluentValidation;

namespace AnimalShelter.WebApi.Middleware.CustomExceptionMiddleware;

/// <summary>
/// Middleware for handling exceptions
/// </summary>
public class CustomExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public CustomExceptionHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception e)
		{
			await HandleExceptionAsync(context, e);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var code = HttpStatusCode.InternalServerError;
		var result = string.Empty;

		switch (exception)
		{
			case ValidationException validationException:
				code = HttpStatusCode.BadRequest;
				result = JsonSerializer.Serialize(validationException.Errors);
				break;
			case NotFoundException:
				code = HttpStatusCode.NotFound;
				break;
			case InvalidPhotoException:
				code = HttpStatusCode.BadRequest;
				break;
		}

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)code;
		if (result == string.Empty)
		{
			result = JsonSerializer.Serialize(new {error = exception.Message});
		}

		return context.Response.WriteAsync(result);
	}
}
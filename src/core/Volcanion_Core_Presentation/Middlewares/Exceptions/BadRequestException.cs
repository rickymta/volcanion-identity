﻿namespace Volcanion_Core_Presentation.Middlewares.Exceptions;

/// <summary>
/// BadRequestException
/// </summary>
/// <param name="message"></param>
public class BadRequestException(string message) : Exception(message)
{
}
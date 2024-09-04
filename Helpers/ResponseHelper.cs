using Microsoft.AspNetCore.Mvc;

public static class ResponseHelper
{
    public static ActionResult HandleException(ILogger logger, Exception ex)
    {
        string message = "An unexpected error occurred.";
        logger.LogError(ex, message);
        return new ObjectResult(message) { StatusCode = 500 };
    }

    public static ActionResult HandleNotFound(ILogger logger, int id)
    {
        string message = $"No entity with ID {id} exists.";
        logger.LogWarning(message);
        return new NotFoundObjectResult(message);
    }

    public static ActionResult HandleBadRequest(ILogger logger, string message)
    {
        logger.LogWarning(message);
        return new BadRequestObjectResult(new { error = message });
    }

    public static ActionResult HandleSuccess(ILogger logger, string message)
    {
        logger.LogInformation(message);
        return new OkObjectResult(message);
    }

    public static ActionResult HandleConflict(ILogger logger, string message)
    {
        logger.LogWarning(message);
        return new ConflictObjectResult(message);
    }
}
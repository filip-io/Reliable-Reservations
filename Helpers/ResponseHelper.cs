using Microsoft.AspNetCore.Mvc;

public static class ResponseHelper
{
    public static ActionResult HandleSuccess(ILogger logger, string message)
    {
        logger.LogInformation(message);
        return new OkObjectResult(new { message });
    }

    public static ActionResult HandleException(ILogger logger, Exception ex)
    {
        logger.LogError(ex, "An unexpected error occurred.");

        return new ObjectResult(new { error = "An unexpected error occurred." })
        {
            StatusCode = 500
        };
    }

    public static ActionResult HandleBadRequest(ILogger logger, string message)
    {
        logger.LogWarning(message);
        return new BadRequestObjectResult(new { error = message });
    }

    public static ActionResult HandleNotFound(ILogger logger, string message)
    {
        logger.LogWarning(message);
        return new NotFoundObjectResult(new { error = message });
    }



    public static ActionResult HandleConflict(ILogger logger, string message)
    {
        logger.LogWarning(message);
        return new ConflictObjectResult(new { error = message });
    }
}
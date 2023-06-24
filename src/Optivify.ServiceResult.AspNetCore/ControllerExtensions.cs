using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Optivify.ServiceResult;

public static class ControllerExtensions
{
    public static ActionResult ToActionResult(this ControllerBase controller, IResult result)
    {
        switch (result.Status)
        {
            case ResultStatus.Success: return Success(controller, result);
            case ResultStatus.Error: return Error(controller, result);
            case ResultStatus.Invalid: return BadRequest(controller, result);
            case ResultStatus.NotFound: return NotFound(controller, result);
            case ResultStatus.Unauthorized: return Unauthorized(controller, result);
            case ResultStatus.Forbidden: return Forbidden(controller);
            default:
                throw new NotSupportedException($"Result status is not supported.");
        }
    }

    private static ActionResult Success(ControllerBase controller, IResult result)
    {
        if (typeof(Result).IsInstanceOfType(result))
        {
            return controller.Ok();
        }

        return controller.Ok(result.GetValue());
    }

    private static ActionResult Error(ControllerBase controller, IResult result)
    {
        return controller.UnprocessableEntity(new ProblemDetails
        {
            Title = "Something went wrong.",
            Detail = result.CombineErrorMessages()
        });
    }

    private static ActionResult BadRequest(ControllerBase controller, IResult result)
    {
        foreach (var validationError in result.ValidationErrors)
        {
            controller.ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
        }

        return controller.BadRequest(controller.ModelState);
    }

    private static ActionResult NotFound(ControllerBase controller, IResult result)
    {
        if (result.ErrorMessages.Any())
        {
            return controller.NotFound(new ProblemDetails
            {
                Title = "Resource not found.",
                Detail = result.CombineErrorMessages()
            });
        }

        return controller.NotFound();
    }

    private static ActionResult Unauthorized(ControllerBase controller, IResult result)
    {
        if (result.ErrorMessages.Any())
        {
            return controller.Unauthorized(new ProblemDetails
            {
                Title = "Unauthorized.",
                Detail = result.CombineErrorMessages()
            });
        }

        return controller.Unauthorized();
    }

    private static ActionResult Forbidden(ControllerBase controller)
    {
        return controller.Forbid();
    }
}

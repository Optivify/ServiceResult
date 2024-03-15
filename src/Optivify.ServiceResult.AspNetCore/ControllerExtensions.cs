using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Optivify.ServiceResult;

public static class ControllerExtensions
{
    public static ActionResult ToActionResult(this ControllerBase controller, IResult result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Success(controller, result),
            ResultStatus.Error => Error(controller, result),
            ResultStatus.Invalid => BadRequest(controller, result),
            ResultStatus.NotFound => NotFound(controller, result),
            ResultStatus.Unauthorized => Unauthorized(controller, result),
            ResultStatus.Forbidden => Forbidden(controller),
            _ => throw new NotSupportedException("Result status is not supported.")
        };
    }

    private static ActionResult Success(ControllerBase controller, IResult result) => 
        result is Result ? controller.Ok() : controller.Ok(result.GetValue());

    private static ActionResult Error(ControllerBase controller, IResult result) =>
        controller.UnprocessableEntity(new ProblemDetails
        {
            Title = "Something went wrong.",
            Detail = result.CombineErrorMessages()
        });

    private static ActionResult BadRequest(ControllerBase controller, IResult result)
    {
        foreach (var validationError in result.ValidationErrors)
        {
            controller.ModelState.AddModelError(
                validationError.PropertyName ?? string.Empty, 
                validationError.ErrorMessage ?? string.Empty);
        }

        return controller.BadRequest(controller.ModelState);
    }

    private static ActionResult NotFound(ControllerBase controller, IResult result) =>
        result.ErrorMessages.Any()
            ? controller.NotFound(new ProblemDetails
            {
                Title = "Resource not found.",
                Detail = result.CombineErrorMessages()
            })
            : controller.NotFound();

    private static ActionResult Unauthorized(ControllerBase controller, IResult result) =>
        result.ErrorMessages.Any()
            ? controller.Unauthorized(new ProblemDetails
            {
                Title = "Unauthorized.",
                Detail = result.CombineErrorMessages()
            })
            : controller.Unauthorized();

    private static ActionResult Forbidden(ControllerBase controller) => 
        controller.Forbid();
}

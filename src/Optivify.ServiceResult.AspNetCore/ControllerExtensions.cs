using Microsoft.AspNetCore.Mvc;

namespace Optivify.ServiceResult.AspNetCore
{
    public static class ControllerExtensions
    {
        public static ActionResult ToActionResult(this ControllerBase controller, IResult result)
        {
            var resultApiModel = result.ToApiModel();

            switch (result.Status)
            {
                // Success
                case ResultStatus.Success:
                    resultApiModel.Message = result.SuccessMessage;

                    return Ok(controller, resultApiModel);

                // Error
                case ResultStatus.Error:
                    resultApiModel.Message = result.CombineErrorMessages();

                    return UnprocessableEntity(controller, resultApiModel);

                // Invalid
                case ResultStatus.Invalid:
                    resultApiModel.Message = result.ValidationErrors?.FirstOrDefault()?.ErrorMessage ?? result.CombineErrorMessages();

                    return BadRequest(controller, resultApiModel);

                // NotFound
                case ResultStatus.NotFound:
                    resultApiModel.Message = result.CombineErrorMessages();

                    return NotFound(controller, resultApiModel);

                // Unauthorized
                case ResultStatus.Unauthorized:
                    resultApiModel.Message = result.CombineErrorMessages();

                    return Unauthorized(controller, resultApiModel);

                // Forbidden
                case ResultStatus.Forbidden:
                    return Forbidden(controller);

                default:
                    throw new NotSupportedException($"The result status {result.Status} is not supported.");
            }
        }

        private static ActionResult Ok(ControllerBase controller, ResultApiModel resultApiModel)
        {
            return controller.Ok(resultApiModel);
        }

        private static ActionResult BadRequest(ControllerBase controller, ResultApiModel resultApiModel)
        {
            return controller.BadRequest(resultApiModel);
        }

        private static ActionResult NotFound(ControllerBase controller, ResultApiModel resultApiModel)
        {
            return controller.NotFound(resultApiModel);
        }

        private static ActionResult Unauthorized(ControllerBase controller, ResultApiModel resultApiModel)
        {
            return controller.Unauthorized(resultApiModel);
        }

        private static ActionResult Forbidden(ControllerBase controller)
        {
            return controller.Forbid();
        }

        private static ActionResult UnprocessableEntity(ControllerBase controller, ResultApiModel resultApiModel)
        {
            return controller.UnprocessableEntity(resultApiModel);
        }
    }
}

using Application.Dtos;
using Application.Dtos.Default;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Template.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult<BaseResponse<T>> Result<T>(this ControllerBase controller, BaseResponse<T> result)
        {
            try
            {
                if (result.Success)
                {
                    return controller.Ok(result);
                }
                else if (result.Errors.Count > 0)
                {
                    return controller.StatusCode(result.Errors.First().StatusCode, result);
                }

                return controller.StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return controller.StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse<IEnumerable<T>>
                {
                    Success = false,
                    Errors = new List<ErrorMessage> { new ErrorMessage("Ocorreu um erro interno no servidor") },
                    Exceptions = new List<ErrorMessage> { new ErrorMessage(ex.Message) }
                });
            }
        }
        public static ActionResult<DefaultResponse> DefaultResult(this ControllerBase controller, DefaultResponse result)
        {
            try
            {
                if (result.Success)
                {
                    return controller.Ok(result);
                }
                else if (result.Errors.Count > 0)
                {
                    return controller.StatusCode(result.Errors.First().StatusCode, result);
                }

                return controller.StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return controller.StatusCode(StatusCodes.Status500InternalServerError, new DefaultResponse
                {
                    Success = false,
                    Errors = new List<ErrorMessage> { new ErrorMessage("Ocorreu um erro interno no servidor") },
                    Exceptions = new List<ErrorMessage> { new ErrorMessage(ex.Message) }
                });
            }
        }
    }
}

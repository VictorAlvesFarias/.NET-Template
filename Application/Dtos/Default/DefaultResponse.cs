namespace Application.Dtos.Default
{
    public class DefaultResponse:BaseResponse<DefaultResponse>
    {
        public DefaultResponse(bool success = false) => Success = success;
    }
}

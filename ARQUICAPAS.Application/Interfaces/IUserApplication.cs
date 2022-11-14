using ARQUICAPAS.Application.Commons.Bases;
using ARQUICAPAS.Application.Dtos.User.Request;

namespace ARQUICAPAS.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> ResgisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}

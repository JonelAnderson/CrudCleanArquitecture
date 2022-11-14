using ARQUICAPAS.Application.Commons.Bases;
using ARQUICAPAS.Application.Dtos.Encargado.Request;
using ARQUICAPAS.Application.Dtos.Encargado.Response;
using ARQUICAPAS.Infrastructure.Commons.Bases.Request;
using ARQUICAPAS.Infrastructure.Commons.Bases.Response;

namespace ARQUICAPAS.Application.Interfaces
{
    public interface IEncargadoApplication
    {
        Task<BaseResponse<BaseEntityResponse<EncargadoResponseDto>>> ListEncargados(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<EncargadoSelectResponseDto>>> ListSelectEncargados();
        Task<BaseResponse<EncargadoResponseDto>> EncargadoById(int encargadoId);
        Task<BaseResponse<bool>> RegisterEncargado(EncargadoRequestDto RequestDto);

        Task<BaseResponse<bool>> EditEncargado(int encargadoId, EncargadoRequestDto RequestDto);
        Task<BaseResponse<bool>> RemoveEncargado(int encargadoId);
    }
}

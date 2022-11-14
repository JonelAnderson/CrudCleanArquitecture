using ARQUICAPAS.Application.Commons.Bases;
using ARQUICAPAS.Application.Dtos.Encargado.Request;
using ARQUICAPAS.Application.Dtos.Encargado.Response;
using ARQUICAPAS.Application.Interfaces;
using ARQUICAPAS.Application.Validators.Encargado;
using ARQUICAPAS.Domain.Entities;
using ARQUICAPAS.Infrastructure.Commons.Bases.Request;
using ARQUICAPAS.Infrastructure.Commons.Bases.Response;
using ARQUICAPAS.Infrastructure.Persistences.Interfaces;
using ARQUICAPAS.Utilities.Static;
using AutoMapper;

namespace ARQUICAPAS.Application.Services
{
    public class EncargadoApplication : IEncargadoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly EncargadoValidator _validationRules;
        public EncargadoApplication(IUnitOfWork unitOfWork, IMapper mapper, EncargadoValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<BaseEntityResponse<EncargadoResponseDto>>> ListEncargados(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<EncargadoResponseDto>>();
            var encargados = await _unitOfWork.Encargado.ListEncargados(filters);
            if (encargados is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<EncargadoResponseDto>>(encargados);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<IEnumerable<EncargadoSelectResponseDto>>> ListSelectEncargados()
        {
            var response = new BaseResponse<IEnumerable<EncargadoSelectResponseDto>>();
            var encargados = await _unitOfWork.Encargado.GetAllAsync();
            if (encargados is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<EncargadoSelectResponseDto>>(encargados);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<EncargadoResponseDto>> EncargadoById(int encargadoId)
        {
            var response = new BaseResponse<EncargadoResponseDto>();
            var encargado = await _unitOfWork.Encargado.GetByIdAsync(encargadoId);
            if (encargado is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<EncargadoResponseDto>(encargado);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> RegisterEncargado(EncargadoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            var encargado = _mapper.Map<Encargado>(requestDto);
            response.Data = await _unitOfWork.Encargado.RegisterAsync(encargado);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditEncargado(int encargadoId, EncargadoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var encargadoEdit = await EncargadoById(encargadoId);
            if (encargadoEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }

            var encargado = _mapper.Map<Encargado>(requestDto);
            encargado.Id = encargadoId;
            response.Data = await _unitOfWork.Encargado.EditAsync(encargado);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPADTE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;

        }


        public async Task<BaseResponse<bool>> RemoveEncargado(int encargadoId)
        {
            var response = new BaseResponse<bool>();
            var category = await EncargadoById(encargadoId);
            if (category.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Encargado.RemoveAsync(encargadoId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

       

    }
}

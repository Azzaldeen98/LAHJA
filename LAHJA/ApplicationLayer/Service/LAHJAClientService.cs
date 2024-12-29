using Application.Services.Service;
using AutoMapper;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;
using LAHJA.Helpers.Services;

namespace LAHJA.ApplicationLayer.Service
{
    public class LAHJAClientService
    {
        private readonly LAHJAService _lahjaService;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public LAHJAClientService(LAHJAService lahjaService, IMapper mapper, TokenService tokenService)
        {
            _lahjaService = lahjaService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            // يمكنك إضافة منطق إضافي هنا إذا لزم الأمر
            return await _lahjaService.GetAllAsync();
        }

        public async Task<Result<ServiceResponse>> GetOneAsync(string id)
        {
            // يمكنك استخدام _tokenService للتحقق أو إدارة الرموز
            return await _lahjaService.GetOneAsync(id);
        }

        public async Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request)
        {
            // مثال على استخدام _mapper لتحويل البيانات إذا لزم الأمر
            var mappedRequest = _mapper.Map<ServiceRequest>(request);
            return await _lahjaService.CreateAsync(mappedRequest);
        }

        public async Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request)
        {
            var mappedRequest = _mapper.Map<ServiceRequest>(request);
            return await _lahjaService.UpdateAsync(mappedRequest);
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _lahjaService.DeleteAsync(id);
        }
    }

}

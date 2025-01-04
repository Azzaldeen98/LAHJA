using Application.UseCase.Request;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Wrapper;


namespace Application.Services.Service
{
    public class RequestService
    {
        private readonly CreateRequestUseCase  createRequestUseCase;
        private readonly RequestAllowedUseCase requestAllowedUseCase;
   
 
 

        public RequestService(CreateRequestUseCase createRequestUseCase, RequestAllowedUseCase requestAllowedUseCase)
        {
            this.createRequestUseCase = createRequestUseCase;
            this.requestAllowedUseCase = requestAllowedUseCase;
        }

        public async Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request)
        {
            return await createRequestUseCase.ExecuteAsync(request);
        }

        public async Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId)
        {
            return await requestAllowedUseCase.ExecuteAsync(serviceId);
        }

     

      
    }
}

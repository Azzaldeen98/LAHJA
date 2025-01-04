using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Wrapper;

namespace Domain.Repository.Request
{
    public interface IRequestRepository
    {
        Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request);
        Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId);
    }
}
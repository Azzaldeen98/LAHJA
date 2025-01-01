﻿using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;

namespace Domain.Repository.Service
{
    public interface IServiceRepository
    {
        Task<Result<List<ServiceResponse>>> GetAllAsync();
        Task<Result<ServiceResponse>> GetOneAsync(string id);
        Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request);
        Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request);
        Task<Result<DeleteResponse>> DeleteAsync(string id);
    }
}
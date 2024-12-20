using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class PriceApiClient: BuildApiClient<PriceClient>
    {

        public PriceApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config) : base(clientFactory, mapper, config)
        {
        }

    
        public async Task<Result<PriceResponseModel>> getAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                
                var response = await client.GetAsync(id);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<List<PriceResponseModel>>> getAllAsync(string productId, bool? active)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetAllAsync(productId,  active);


                var resModel = _mapper.Map<List<PriceResponseModel>>(response);
                return Result<List<PriceResponseModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<List<PriceResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }  
        
        public async Task<Result<PriceResponseModel>> CreateAsync(PriceCreateRequestModel request)
        {
            try
            {
                var model = _mapper.Map<PriceCreate>(request);
                var client = await GetApiClient();
                var response = await client.CreateAsync(model);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<PriceResponseModel>> UpdateAsync(PriceUpdateRequestModel request)
        {
            try
            {
                var model = _mapper.Map<PriceUpdate>(request);
                var client = await GetApiClient();
                var response = await client.UpdateAsync(request.Id,model);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}

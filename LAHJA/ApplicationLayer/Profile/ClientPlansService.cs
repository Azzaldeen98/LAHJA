using Application.Services.Profile;
using AutoMapper;
using Domain.Entities.Profile;
using Domain.Wrapper;
using LAHJA.Helpers.Services;

namespace LAHJA.ApplicationLayer.Profile
{
    public class ClientProfileService
    {
        private readonly ProfileService profileService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;

        public ClientProfileService(ProfileService profileService,
            IMapper mapper,
            TokenService tokenService)
        {

            this.profileService = profileService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<Result<ProfileResponse>> GetPlansGroupAsync()
        {

            return await profileService.getProfileAsync();

            //if ( result.Succeeded)
            //{
            //    var res = result.Data;
            //    var data = _mapper.Map<List<PlansFeture>>(res);
            //    int i = 0;
            //foreach (var item in data)
            //{
            //    item.Services = _mapper.Map<List<ProfileResponse>>(res[i].SubscriptionFeatures);
            //    item.numberOfServices = _mapper.Map<List<NumberOfService>>(res[i++].TechnicalFeatures);
            //}
            //    return Result<List<PlansFeture>>.Success(data);
            //}
            //else
            //{
            //    return Result<List<PlansFeture>>.Fail();
            //}

        }

    }
}

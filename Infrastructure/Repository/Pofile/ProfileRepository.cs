using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Entities.Profile;
using Domain.Repository.Profile;
using Domain.ShareData;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.ApiClient.Profile;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Shared.Helpers;
using Shared.Settings;

public class ProfileRepository :IProfileRepository
{

    private readonly SeedsProfile seedsProfile;
    private readonly ProfileApiClient profileApiClient;
    private readonly ISessionUserManager _sessionUserManager;
    private readonly IMapper _mapper;
    private readonly ApplicationModeService appModeService;

    public ProfileRepository(SeedsProfile seedsProfile,
                             ProfileApiClient profileApiClient,
                            IMapper mapper,
                            ApplicationModeService appModeService,
                            ISessionUserManager sessionUserManager)
    {
        this.seedsProfile = seedsProfile;
        this.profileApiClient = profileApiClient;
        _mapper = mapper;
        this.appModeService = appModeService;
        this._sessionUserManager = sessionUserManager;
    }

    public async Task<Result<ProfileResponse>> getProfileAsync()
    {

        var response = await ExecutorAppMode.ExecuteAsync<Result<ProfileResponseModel>>(
             async () => Result<ProfileResponseModel>.Success(),//await profileApiClient.getProfileAsync(),
              async () => Result<ProfileResponseModel>.Success(await seedsProfile.getProfileAsync()));

        if (response.Succeeded)
        {
            var result = (response.Data != null) ? _mapper.Map<ProfileResponse>(response.Data) : null;
            return Result<ProfileResponse>.Success(result);
        }
        else
        {
            return Result<ProfileResponse>.Fail(response.Messages);
        }
    }
}

using BNZF99_SG1_21_22_2.Logic.Interfaces;
using BNZF99_SG1_21_22_2.Logic.Services;
using BNZF99_SG1_21_22_2.Repository.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BNZF99_SG1_21_22_2.Logic.Infrastructure
{
    public static class BLInitialization
    {
        public static void InitBlServices(IServiceCollection services)
        {
            RepoInitialization.InitRepoServices(services);

            services.AddScoped<IArtistLogic, ArtistLogic>();
        }
    }
}

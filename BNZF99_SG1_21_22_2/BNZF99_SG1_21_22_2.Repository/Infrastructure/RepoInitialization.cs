using BNZF99_SG1_21_22_2.Repository.DbContexts;
using BNZF99_SG1_21_22_2.Repository.Interfaces;
using BNZF99_SG1_21_22_2.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BNZF99_SG1_21_22_2.Repository.Infrastructure
{
    public static class RepoInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<ArtistDbContext>((sp) => new ArtistDbContext());
            services.AddScoped<IArtistRepository, ArtistRepository>();
        }
    }
}

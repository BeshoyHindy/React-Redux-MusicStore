using AutoMapper;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.WebApi.Models;
using ReactMusicStore.WebApi.ViewModels;

namespace ReactMusicStore.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<Genre, GenreMenuViewModel>();
        }
    }
}
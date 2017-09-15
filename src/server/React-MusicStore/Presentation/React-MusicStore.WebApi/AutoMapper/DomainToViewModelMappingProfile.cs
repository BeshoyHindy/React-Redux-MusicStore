using AutoMapper;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.WebApi.Models;
using ReactMusicStore.WebApi.ViewModels;

namespace ReactMusicStore.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<GenreMenuViewModel, Genre>();
        }
    }
}
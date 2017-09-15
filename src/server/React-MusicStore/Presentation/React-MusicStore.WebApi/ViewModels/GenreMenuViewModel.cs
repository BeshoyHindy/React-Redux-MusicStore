using AutoMapper;
using ReactMusicStore.Core.Domain.Entities;

namespace ReactMusicStore.WebApi.ViewModels
{
    public class GenreMenuViewModel
    {
        public string Name { get; set; }

        public static GenreMenuViewModel ToViewModel(Genre genre)
        {
            return Mapper.Map<GenreMenuViewModel>(genre);
        }
    }
}
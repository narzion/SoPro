using AutoMapper;
using Entity;
using Entity.ViewModels;

namespace Services.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Bookmark, BookmarkVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
        }
    }
}

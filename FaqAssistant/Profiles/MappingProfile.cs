using AutoMapper;
using FaqAssistant.Api.Dtos;
using FaqAssistant.Entities;

namespace FaqAssistant.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // FAQ
            CreateMap<Faq, FaqResponseDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Tags, o => o.MapFrom(s => s.FaqTags.Select(ft => ft.Tag.Name)))
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedByUser.DisplayName));


            CreateMap<FaqCreateDto, Faq>();
            CreateMap<FaqUpdateDto, Faq>();

            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            // Tag
            CreateMap<Tag, TagDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagUpdateDto, Tag>();

            // User
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}

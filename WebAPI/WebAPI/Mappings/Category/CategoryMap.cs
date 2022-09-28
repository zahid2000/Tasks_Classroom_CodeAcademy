namespace WebAPI.Mappings.Category;

public class CategoryMap : Profile
{
    public CategoryMap()
    {
        CreateMap<Models.Category, CategoryDto>()
            .ForMember(dest=>dest.FullProperty,
            opt=>opt.MapFrom(src=>$"{src.CategoryId} {src.CategoryName} {src.Description}"))
            .ReverseMap();
        CreateMap<Models.Category, CategoryCreateDto>().ReverseMap();
        CreateMap<CategoryDto, CategoryCreateDto>().ReverseMap();
    }
}

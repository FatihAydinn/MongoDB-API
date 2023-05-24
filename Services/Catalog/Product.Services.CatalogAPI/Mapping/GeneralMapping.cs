using AutoMapper;
using RAS.Services.ProductAPI.Dtos;
using RAS.Services.ProductAPI.Models;

namespace RAS.Services.ProductAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
        //ReverseMap: Eşleştirici konfigürasyonunu tersine çevirmek için kullanılan bir yöntemdir.
        //Eşleştirmeyi tersine çevirdiğinizde, bu sefer hedef nesnesinin özellikleri kaynak nesnesinin özelliklerine kopyalanır veya eşleştirilir.
        //Eşleştirmeyi tersine çevirmek, özellikle iki yönlü veri aktarımlarında veya çift yönlü işlemlerde kullanışlı olabilir.
        //Örneğin, bir veritabanından veri alırken bir DTO'ya eşleştirme yapabilir ve daha sonra bu DTO'yu güncellediğinizde, güncellemeleri otomatik olarak veritabanı nesnesine yansıtmak için eşleştirmeyi tersine çevirebilirsiniz.

        CreateMap<Guitar, GuitarDto>().ReverseMap();//GuitarDto'yu Guitar nesnesine eşleştir ve eşleştirmeyi tersine çevir
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();

        CreateMap<Guitar, GuitarCreateDto>().ReverseMap();
        CreateMap<Guitar, GuitarUpdateDto>().ReverseMap();
        }
    }
}

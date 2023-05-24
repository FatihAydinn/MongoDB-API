
namespace RAS.Services.ProductAPI.Dtos
{
    public class GuitarDto
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string UserID { get; set; }

        public string CategoryID { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedTime { get; set; }

        public FeatureDto Feature { get; set; }

        public CategoryDto Category { get; set; }
    }
}

namespace RAS.Services.ProductAPI.Dtos
{
    public class GuitarCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Picture { get; set; }

        public string UserID { get; set; }

        public string CategoryID { get; set; }

        public FeatureDto Feature { get; set; }
    }
}

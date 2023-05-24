namespace RAS.Services.ProductAPI.Settings
{
    public interface IDatabaseSettings
    {
        //Options Pattern: Configration dosyalarını bir sınıf üzerine alarak okuma işlemi.
        //appsettings.json içerisinde bulunan connection elemanlarına karşılık gelen proplar oluşturulur.

        public string GuitarCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

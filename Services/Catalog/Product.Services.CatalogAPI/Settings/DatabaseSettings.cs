namespace RAS.Services.ProductAPI.Settings
{
    public class DatabaseSettings : IDatabaseSettings
        //implementler set edildi ama propertyler set edilmedi, programcs de edilecek
    {
        public string GuitarCollectionName { get;set;}
        public string CategoryCollectionName { get;set;}
        public string ConnectionString { get;set;}
        public string DatabaseName { get;set;}
    }
}

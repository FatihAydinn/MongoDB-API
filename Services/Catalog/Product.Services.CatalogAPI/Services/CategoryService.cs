
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using RAS.Services.ProductAPI.Dtos;
using RAS.Services.ProductAPI.Models;
using RAS.Services.ProductAPI.Settings;
using RAS.Shared.Dtos;

namespace RAS.Services.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        //mongodb Category Collectiona(table) bağlantı kurulur
        private readonly IMongoCollection<Category> _categoryCollection;

        //DTO dönüşümü
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            //veritabanı bağlantı yolu
            var client = new MongoClient(databaseSettings.ConnectionString);

            //client üzerinden veritabanı adına erişir
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            //alınan veritabanı üzerinden collection adına erişir
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        //Tüm datalara erişim
        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            //InsertOneAsync: Sağlanan nesneyi koleksiyona yeni bir belge olarak ekler
            await _categoryCollection.InsertOneAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(categoryDto),200);
        }

        //ID ye göre listeleme
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.ID == id).FirstOrDefaultAsync();

            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}

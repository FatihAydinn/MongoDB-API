using AutoMapper;
using MongoDB.Driver;
using RAS.Services.ProductAPI.Dtos;
using RAS.Services.ProductAPI.Models;
using RAS.Services.ProductAPI.Settings;
using RAS.Shared.Dtos;

namespace RAS.Services.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        //mongodb Category Collectiona(table) bağlantı kurulur
        private readonly IMongoCollection<Guitar> _guitarCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        //DTO dönüşümü
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            //veritabanı bağlantı yolu
            var client = new MongoClient(databaseSettings.ConnectionString);

            //client üzerinden veritabanı adına erişir
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _guitarCollection = database.GetCollection<Guitar>(databaseSettings.GuitarCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }
        public async Task<Response<List<GuitarDto>>> GetAllAsync()
        {
            var guitars = await _guitarCollection.Find(courses => true).ToListAsync();

            if (guitars.Any())
            {
                foreach (var guitar in guitars)
                {
                    guitar.Category = await _categoryCollection.Find<Category>(x => x.ID == guitar.CategoryID).FirstAsync();
                }
            }
            else
            {
                guitars = new List<Guitar>();
            }

            return Response<List<GuitarDto>>.Success(_mapper.Map<List<GuitarDto>>(guitars), 200);
        }
        public async Task<Response<GuitarDto>> GetByIdAsync(string id)
        {
            var guitar = await _guitarCollection.Find<Guitar>(x => x.ID == id).FirstOrDefaultAsync();

            if (guitar == null)
            {
                return Response<GuitarDto>.Fail("Guitar not found", 404);
            }
            guitar.Category = await _categoryCollection.Find<Category>(x => x.ID == id).FirstOrDefaultAsync();

            return Response<GuitarDto>.Success(_mapper.Map<GuitarDto>(guitar), 200);
        }
        public async Task<Response<List<GuitarDto>>> GetAllByUserIdAsync(string userid)
        {
            var guitars = await _guitarCollection.Find<Guitar>(x => x.UserID == userid).ToListAsync();
            if (guitars.Any())
            {
                foreach (var guitar in guitars)
                {
                    guitar.Category = await _categoryCollection.Find<Category>(x => x.ID == guitar.CategoryID).FirstAsync();
                }
            }
            else
            {
                guitars = new List<Guitar>();
            }

            return Response<List<GuitarDto>>.Success(_mapper.Map<List<GuitarDto>>(guitars), 200);
        }
        public async Task<Response<GuitarDto>> CreateAsync(GuitarCreateDto guitarCreateDto)
        {
            var newGuitar = _mapper.Map<Guitar>(guitarCreateDto);

            newGuitar.CreatedTime = DateTime.Now;
            await _guitarCollection.InsertOneAsync(newGuitar);

            return Response<GuitarDto>.Success(_mapper.Map<GuitarDto>(newGuitar),200);
        }
        public async Task<Response<NoContent>> UpdateAsync(GuitarUpdateDto guitarUpdateDto)
        {
            var updateGuitar = _mapper.Map<Guitar>(guitarUpdateDto);

            var result = await _guitarCollection.FindOneAndReplaceAsync(x => x.ID == guitarUpdateDto.ID, updateGuitar);

            if (result == null)
            {
                return Response<NoContent>.Fail("Guitar not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _guitarCollection.DeleteOneAsync(x=>x.ID == id);

            if (result.DeletedCount>0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Guitar not found",404);
            }
        }
    }
}

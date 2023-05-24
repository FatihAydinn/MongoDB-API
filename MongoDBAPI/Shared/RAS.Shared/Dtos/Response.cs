using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RAS.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }

        [JsonIgnore] //JSON verisinde gözükmesi istenmeyen anahtarlar özel olarak belirtmek istendiğinde kullanılır
        //yani StatusCode kullanılacak ama Response içerisinde yer almayacak
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }

        //Static Factory Methodlar

        //Başarılı olup data döndüğünde;
        public static Response<T> Success(T data,int statusCode) 
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccess = true};
        }

        //Başarılı olup data almaması durumunda;
        public static Response<T> Success(int statusCode) 
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccess = true };
        }

        //Başarısız olması durumunda;
        public static Response<T> Fail(List<string> errors,int statusCode) 
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccess = false
            };
        }

        //Tek bir error için;
        public static Response<T> Fail(string error,int statusCode)
        {
            return new Response<T> { Errors=new List<string>() { error},StatusCode = statusCode, IsSuccess = false};
        }
    }
}

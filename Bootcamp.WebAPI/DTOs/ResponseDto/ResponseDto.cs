using System.Text.Json.Serialization;

namespace Bootcamp.WebAPI.DTOs.ResponseDto
{
    public class ResponseDto<T>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string> Messages { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string> Errors { get; set; }
        //[JsonIgnore]
        public int StatusCode { get; set; }


        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>() { StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T>() { Data = data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(T data, string message, int statusCode)
        {
            return new ResponseDto<T>() { Data = data, Messages = new List<string>() { message }, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(T data, List<string> messages, int statusCode)
        {
            return new ResponseDto<T>() {Data = data, Messages = messages, StatusCode = statusCode};
        }

        public static ResponseDto<T> Fail(int statusCode)
        {
            return new ResponseDto<T>() { StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail( List<string> errors, int statusCode)
        {
            return new ResponseDto<T>() { Errors = errors, StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>() { Errors = new List<string>() { error }, StatusCode = statusCode };
        }
    }
}

using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs;

public class CustomResponseDto<T>
{
    public T Data { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    public List<string> Errors { get; set; }

    public static CustomResponseDto<T> Success(int statusCode, T Data)
    {
        var result = new CustomResponseDto<T>()
        {
            Data = Data,
            StatusCode = statusCode
        };
        return result;
    }

    public static CustomResponseDto<T> Success(int statusCode)
    {
        var result = new CustomResponseDto<T>()
        {
            StatusCode = statusCode,
        };
        return result;
    }

    public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
    {
        var result = new CustomResponseDto<T>()
        {
            StatusCode = statusCode,
            Errors = errors
        };
        return result;
    }

    public static CustomResponseDto<T> Fail(int statusCode, string error)
    {
        var result = new CustomResponseDto<T>()
        {
            StatusCode = statusCode,
            Errors = new List<string> { error }
        };
        return result;
    }

}
using System;

public interface IApiResponse<T>
{
    T Data { get; set; }
    string Message { get; set; }
    int Status { get; set; }
}

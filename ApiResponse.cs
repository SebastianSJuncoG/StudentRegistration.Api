using System;
using stu

public class ApiResponse<T> : IApiResponse<T>
{
    public T Data { get; set; }
    
    // La propiedad 'Message' contendrá un mensaje descriptivo
    public string Message { get; set; }
    
    // La propiedad 'Status' contendrá un código de estado (ej. 200, 404, 500)
    public int Status { get; set; }
}

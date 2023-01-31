namespace Lama.Core.Infrastructure.Models;

public class ServiceResponse<T> : ServiceResponse
{
    public T Data { get; set; }

    public ServiceResponse() { }
    public ServiceResponse(int? status, string message, T data, object[] errors = null, int? totalRecords = null) : base(status, message, errors, totalRecords)
    {
        Data = data;
    }
}

public class ServiceResponse
{
    public bool Success
    {
        get
        {
            return Status == 0;
        }
    }

    public int? Status { get; set; }
    public string Message { get; set; }
    public object[] Errors { get; set; }
    public int? TotalRecords { get; set; }
    public ServiceResponse() { }
    public ServiceResponse(int? status, string message, object[] errors = null, int? totalRecords = null)
    {
        Status = status;
        Message = message;
        Errors = errors;
        TotalRecords = totalRecords;
    }
}

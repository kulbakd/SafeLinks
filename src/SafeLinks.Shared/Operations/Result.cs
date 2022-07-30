namespace SafeLinks.shared.Operations;

public class Result
{
    public bool Successful { get; protected set; }
    public string? Message { get; protected set; }

    protected Result()
    {
        Successful = true;
    }

    protected Result(string message)
    {
        Successful = false;
        Message = message;
    }

    public static Result Success()
    {
        return new Result();
    }

    public static Result Fail(string message)
    {
        return new Result(message);
    }
}

public class Result<TData> : Result
{
    public TData? Data { get; protected set; }

    private Result(TData data)
    {
        Successful = true;
        Data = data;
    }

    private Result(string message) : base(message) {}

    public static Result<TData> Success(TData data)
    {
        return new Result<TData>(data);
    }

    public new static Result<TData> Fail(string message)
    {
        return new Result<TData>(message);
    }
}
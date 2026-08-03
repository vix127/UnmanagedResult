namespace UnmanagedResult;

public interface IResult<out TValue, TError>
    where TValue : unmanaged
    where TError : unmanaged, IError
{
    public TValue Value { get; }
    public TError Error { get; }
}

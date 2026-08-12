namespace UnmanagedResult;

public interface IResult<TValue, TError>
    where TValue : unmanaged
    where TError : unmanaged, IError
{

}

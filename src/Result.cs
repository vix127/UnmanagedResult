using System;

namespace UnmanagedResult;

public struct Result<TValue, TEnum> : IResult<TValue, Error<TEnum>>
    where TValue : unmanaged
    where TEnum : unmanaged, Enum
{
    public TValue Value => throw new System.NotImplementedException();

    public Error<TEnum> Error => default;
}
using System;

namespace UnmanagedResult;

public readonly struct Error<TEnum> : IError
    where TEnum : unmanaged, Enum
{
    public TEnum Code { get; }

    public Error(TEnum code)
    {
        Code = code;
    }

    public static implicit operator Error<TEnum>(TEnum code)
    {
        return new(code);
    }

    public static implicit operator TEnum(Error<TEnum> error)
    {
        return error.Code;
    }
}
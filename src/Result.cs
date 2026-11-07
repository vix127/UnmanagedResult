// Copyright (c) 2026 Viktor Stojanović. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using System;

namespace UnmanagedResult;

public readonly struct Result<TValue, TEnumBackedError, TEnum> : IResult<TValue, TEnumBackedError>
    where TValue           : unmanaged
    where TEnumBackedError : unmanaged, IEnumBackedError<TEnum>
    where TEnum            : unmanaged, Enum
{
    private readonly byte _flags;
    private readonly TValue _value;
    private readonly TEnumBackedError _error;
    public bool IsSuccess => _flags is 0;

    public Result(TValue value)
    {
        _value = value;
        _flags = 0;
    }

    public Result(TEnumBackedError error)
    {
        _error = error;
        _flags = 1;
    }

    public static implicit operator Result<TValue, TEnumBackedError, TEnum>(TValue value)
    {
        return new(value);
    }

    public static implicit operator Result<TValue, TEnumBackedError, TEnum>(TEnumBackedError error)
    {
        return new(error);
    }

    public static bool operator true(Result<TValue, TEnumBackedError, TEnum> result)
    {
        return result.IsSuccess;
    }

    public static bool operator false(Result<TValue, TEnumBackedError, TEnum> result)
    {
        return !result.IsSuccess;
    }
}

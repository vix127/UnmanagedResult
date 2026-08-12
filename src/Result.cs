// Copyright (c) 2026 Viktor Stojanović. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using System;

namespace UnmanagedResult;

public readonly struct Result<TValue, TEnum> : IResult<TValue, Error<TEnum>>
    where TValue : unmanaged
    where TEnum  : unmanaged, Enum
{
    private readonly byte         _flags;
    private readonly TValue       _value;
    private readonly Error<TEnum> _error;
    public bool IsSuccess => _flags is 0;

    public Result(TValue value)
    {
        _value = value;
        _flags = 0;
    }

    public Result(Error<TEnum> error)
    {
        _error = error;
        _flags = 1;
    }


    public static bool operator true(Result<TValue, TEnum> result)
    {
        return result.IsSuccess;
    }

    public static bool operator false(Result<TValue, TEnum> result)
    {
        return !result.IsSuccess;
    }
}
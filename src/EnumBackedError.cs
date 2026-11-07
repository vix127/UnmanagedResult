// Copyright (c) 2026 Viktor Stojanović. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using System;

namespace UnmanagedResult;

public readonly struct EnumBackedError<TEnum> : IEnumBackedError<TEnum>
    where TEnum : unmanaged, Enum
{
    public TEnum Code { get; }

    public EnumBackedError(TEnum code)
    {
        Code = code;
    }

    public static implicit operator EnumBackedError<TEnum>(TEnum code)
    {
        return new(code);
    }

    public static implicit operator TEnum(EnumBackedError<TEnum> error)
    {
        return error.Code;
    }
}
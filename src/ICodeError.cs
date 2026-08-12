// Copyright (c) 2026 Viktor Stojanović. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using System;

namespace UnmanagedResult;

public interface ICodeError<TEnum> : IError
    where TEnum : unmanaged, Enum
{
    public TEnum Code { get; }
}

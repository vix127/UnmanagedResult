// Copyright (c) 2026 Viktor Stojanović. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace UnmanagedResult;

public interface IResult<TValue, TError>
    where TValue : unmanaged
    where TError : unmanaged, IError
{

}

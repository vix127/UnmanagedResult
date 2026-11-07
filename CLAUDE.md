# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build

- Solution: `UnmanagedResult.slnx`
- Project: `src/UnmanagedResult.csproj` (targets `net10.0` and `netstandard2.0`, `LangVersion` 14.0)

Build everything:

```bash
dotnet build
```

Build a single framework:

```bash
dotnet build src/UnmanagedResult.csproj -f net10.0
```

There is no test project in this repository.

## Architecture

`UnmanagedResult` is a zero-allocation, unmanaged `Result`/`Error` type library.

Key files in `src/`:

- `IResult.cs` / `IError.cs` — core interfaces. `IResult<TValue, TError>` requires `TValue : unmanaged` and `TError : unmanaged, IError`; `IsSuccess` property.
- `IEnumBackedError.cs` — interface for errors that wrap an enum code: exposes `TEnum Code` (constrains `TEnum : unmanaged, Enum`).
- `EnumBackedError.cs` — readonly struct implementing `IEnumBackedError<TEnum>` with implicit conversions between the enum code and the error.
- `Result.cs` — readonly struct `Result<TValue, TEnumBackedError, TEnum>` with success/failure flag, stored value/error, plus `true`/`false` operators and implicit conversions from `TValue` and `TEnumBackedError`.

Design constraints to respect:
- All payloads are `unmanaged`; `Result` stores `TValue`/`TEnumBackedError` by value. No heap allocations.
- Implicit conversions intentionally chain at most one user-defined conversion; raw enum codes are not implicitly convertible to `Result` in the three-parameter signature — wrap as `EnumBackedError<TEnum>` first (or use `new EnumBackedError<TEnum>(code)`).

## Code style

Formatting is governed by the root `editorconfig`:
- Spaces, 4-space indent for `.cs`, file-scoped namespaces.
- `insert_final_newline = true`, `trim_trailing_whitespace = true` — every file must end with a trailing newline.
- Allman braces (`csharp_new_line_before_open_brace = all`), braces preferred for all blocks.
- `var` suggested everywhere; nullable enabled; unsafe blocks allowed.

Apply these rules when editing; the project has no linter invocation beyond `dotnet build`.
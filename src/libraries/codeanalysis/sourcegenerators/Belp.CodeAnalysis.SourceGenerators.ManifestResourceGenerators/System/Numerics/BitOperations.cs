// Copied from https://raw.githubusercontent.com/dotnet/runtime/e31ddfdc4f574b26231233dc10c9a9c402f40590/src/libraries/System.IO.Hashing/src/System/IO/Hashing/BitOperations.cs
#pragma warning disable
#nullable disable

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Numerics
{
    internal static class BitOperations
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateLeft(uint value, int offset)
            => (value << offset) | (value >> (32 - offset));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateLeft(ulong value, int offset)
            => (value << offset) | (value >> (64 - offset));
    }
}

﻿using System.Numerics;

namespace ElgamalSandbox.Core.Models;

public class AutoCounter<T>
where T : struct, IIncrementOperators<T>
{
    private T _value;

    public AutoCounter(T value = default)
    {
        _value = value;
    }

    public static implicit operator T(AutoCounter<T> counter)
    {
        ArgumentNullException.ThrowIfNull(counter);

        return counter._value++;
    }
}
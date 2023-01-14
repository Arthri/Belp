# Belp.Build.PseudoKeywords
[![Project License](https://img.shields.io/badge/license-MIT-green?style=flat-square "License")](https://github.com/Arthri/Belp/blob/02b63f4be263d747f3078a0568bf235bf021d0cd/LICENSE) [![Latest NuGet Release](https://img.shields.io/nuget/v/Belp.Build.PseudoKeywords?style=flat-square "Latest NuGet Release")](https://www.nuget.org/packages/Belp.Build.PseudoKeywords/latest)

Adds new language keywords using global usings.

## Disclaimer
This project is not meant to be used seriously; it is merely a proof of concept.

## Installation

### Requirements
- Any project compiling for .NET 7 or above, or C#11 or above.

### Install using Visual Studio Package Manager
1. Open Visual Studio.
1. Right click the project in the Solution Explorer.
1. Click on "Manage NuGet Packages".
1. Go to the "Browse" tab.
1. Search for `Belp.Build.PseudoKeywords`.
1. Install.

### Install using .NET CLI
1. Open a terminal.
1. Navigate to the project file; for example, `Project.csproj`, `Project.vbproj`, etc.
1. Run `dotnet add package Belp.Build.PseudoKeywords`.

## Usage

### Type Aliases
```cs
// Integer Types
Console.WriteLine(typeof(int8));        // Alias for System.SByte
Console.WriteLine(typeof(uint8));       // Alias for System.Byte
Console.WriteLine(typeof(int16));       // Alias for System.Int16
Console.WriteLine(typeof(uint16));      // Alias for System.UInt16
Console.WriteLine(typeof(int32));       // Alias for System.Int32
Console.WriteLine(typeof(uint32));      // Alias for System.UInt32
Console.WriteLine(typeof(int64));       // Alias for System.Int64
Console.WriteLine(typeof(uint64));      // Alias for System.UInt64

// Floating-Point Types
Console.WriteLine(typeof(half));        // Alias for System.Half
Console.WriteLine(typeof(fp16));        // Alias for System.Half
Console.WriteLine(typeof(float16));     // Alias for System.Half
Console.WriteLine(typeof(single));      // Alias for System.Single
Console.WriteLine(typeof(fp32));        // Alias for System.Single
Console.WriteLine(typeof(float32));     // Alias for System.Single
Console.WriteLine(typeof(fp64));        // Alias for System.Double
Console.WriteLine(typeof(float64));     // Alias for System.Double

// Other Numeric Types
Console.WriteLine(typeof(bigint));      // Alias for System.Numerics.BigInteger
Console.WriteLine(typeof(complex));     // Alias for System.Numerics.Complex

// Temporal Types
Console.WriteLine(typeof(datetime));    // Alias for System.DateTime
Console.WriteLine(typeof(date));        // Alias for System.DateOnly
Console.WriteLine(typeof(time));        // Alias for System.TimeOnly
Console.WriteLine(typeof(timespan));    // Alias for System.TimeSpan

// Other Types
Console.WriteLine(typeof(boolean));     // Alias for System.Boolean
```
```cs
long num = 45L;
int64 num2 = 45L;

Console.WriteLine(num == num2);     // true
Console.WriteLine(num is int64);    // true
Console.WriteLine(num2 is long);    // true

Type t_num = num.GetType();
Type t_num2 = num2.GetType();
Console.WriteLine(t_num.IsEquivalentTo(t_num2));    // true
```

### Alternative Bool Literals
```cs
Console.WriteLine(False);   // false
Console.WriteLine(false);   // false
Console.WriteLine(True);    // true
Console.WriteLine(true);    // true

Console.WriteLine(Off); // false
Console.WriteLine(off); // false
Console.WriteLine(On);  // true
Console.WriteLine(on);  // true

Console.WriteLine(No);  // false
Console.WriteLine(no);  // false
Console.WriteLine(Yes); // true
Console.WriteLine(yes); // true
```

### Get Location
```cs
// Foo.cs
Console.WriteLine(linenum()); // 2
Console.WriteLine(currentfile()); // Foo.cs
```

### Strongly-Typed Expression Strings
```cs
int num = 3;
Console.WriteLine(nameofexpr(num)); // Prints num
Console.WriteLine(nameofexpr((int a, string b) => 3f)); // Prints (int a, string b) => 3f
```

## `Console.Write` and `Console.WriteLine` Aliases
```cs
print(2);
write(2);
Console.Write(2);
// 222

println(2);             // 2
writeln(2);             // 2
writeline(2);           // 2
Console.WriteLine(2);   // 2
```

### Get Random Number
Brief explanation of [Interval Notation](https://en.wikipedia.org/wiki/Interval_(mathematics)):

$$
\begin{flalign}
(a, b) &= \\{ x \in \mathbb{R} \mid a \lt x \lt b \\} && \\
[a, b) &= \\{ x \in \mathbb{R} \mid a \le x \lt b \\} && \\
(a, b] &= \\{ x \in \mathbb{R} \mid a \lt x \le b \\} && \\
[a, b] &= \\{ x \in \mathbb{R} \mid a \le x \le b \\} && \\
\end{flalign}
$$

```cs
// Inclusive-Inclusive Integers
Console.WriteLine(rsbyte);  // Random number in [sbyte.MinValue, sbyte.MaxValue]
Console.WriteLine(rint8);   // Random number in [sbyte.MinValue, sbyte.MaxValue]
Console.WriteLine(rbyte);   // Random number in [byte.MinValue, byte.MaxValue]
Console.WriteLine(ruint8);  // Random number in [byte.MinValue, byte.MaxValue]
Console.WriteLine(rshort);  // Random number in [short.MinValue, short.MaxValue]
Console.WriteLine(rint16);  // Random number in [short.MinValue, short.MaxValue]
Console.WriteLine(rushort); // Random number in [ushort.MinValue, ushort.MaxValue]
Console.WriteLine(ruint16); // Random number in [ushort.MinValue, ushort.MaxValue]
Console.WriteLine(rint);    // Random number in [int.MinValue, int.MaxValue]
Console.WriteLine(rint32);  // Random number in [int.MinValue, int.MaxValue]
Console.WriteLine(ruint);   // Random number in [uint.MinValue, uint.MaxValue]
Console.WriteLine(ruint32); // Random number in [uint.MinValue, uint.MaxValue]
Console.WriteLine(rlong);   // Random number in [long.MinValue, long.MaxValue]
Console.WriteLine(rint64);  // Random number in [long.MinValue, long.MaxValue]
Console.WriteLine(rulong);  // Random number in [ulong.MinValue, ulong.MaxValue]
Console.WriteLine(ruint64); // Random number in [ulong.MinValue, ulong.MaxValue]

// Inclusive-Exclusive Integers
Console.WriteLine(resbyte);     // Random number in [sbyte.MinValue, sbyte.MaxValue)
Console.WriteLine(reint8);      // Random number in [sbyte.MinValue, sbyte.MaxValue)
Console.WriteLine(rebyte);      // Random number in [byte.MinValue, byte.MaxValue)
Console.WriteLine(reuint8);     // Random number in [byte.MinValue, byte.MaxValue)
Console.WriteLine(reshort);     // Random number in [short.MinValue, short.MaxValue)
Console.WriteLine(reint16);     // Random number in [short.MinValue, short.MaxValue)
Console.WriteLine(reushort);    // Random number in [ushort.MinValue, ushort.MaxValue)
Console.WriteLine(reuint16);    // Random number in [ushort.MinValue, ushort.MaxValue)
Console.WriteLine(reint);       // Random number in [int.MinValue, int.MaxValue)
Console.WriteLine(reint32);     // Random number in [int.MinValue, int.MaxValue)
Console.WriteLine(reuint);      // Random number in [uint.MinValue, uint.MaxValue)
Console.WriteLine(reuint32);    // Random number in [uint.MinValue, uint.MaxValue)
Console.WriteLine(relong);      // Random number in [long.MinValue, long.MaxValue)
Console.WriteLine(reint64);     // Random number in [long.MinValue, long.MaxValue)
Console.WriteLine(reulong);     // Random number in [ulong.MinValue, ulong.MaxValue)
Console.WriteLine(reuint64);    // Random number in [ulong.MinValue, ulong.MaxValue)

// Non-Zero Inclusive-Inclusive Signed Integers
Console.WriteLine(rpsbyte); // Random number in [0, sbyte.MaxValue]
Console.WriteLine(rpint8);  // Random number in [0, sbyte.MaxValue]
Console.WriteLine(rpshort); // Random number in [0, short.MaxValue]
Console.WriteLine(rpint16); // Random number in [0, short.MaxValue]
Console.WriteLine(rpint);   // Random number in [0, int.MaxValue]
Console.WriteLine(rpint32); // Random number in [0, int.MaxValue]
Console.WriteLine(rplong);  // Random number in [0, long.MaxValue]
Console.WriteLine(rpint64); // Random number in [0, long.MaxValue]

// Non-Zero Inclusive-Exclusive Signed Integers
Console.WriteLine(rpesbyte);    // Random number in [0, sbyte.MaxValue)
Console.WriteLine(rpeint8);     // Random number in [0, sbyte.MaxValue)
Console.WriteLine(rpeshort);    // Random number in [0, short.MaxValue)
Console.WriteLine(rpeint16);    // Random number in [0, short.MaxValue)
Console.WriteLine(rpeint);      // Random number in [0, int.MaxValue)
Console.WriteLine(rpeint32);    // Random number in [0, int.MaxValue)
Console.WriteLine(rpelong);     // Random number in [0, long.MaxValue)
Console.WriteLine(rpeint64);    // Random number in [0, long.MaxValue)

// Floating-Point Numbers
Console.WriteLine(rfloat);  // Random number in [0, 1)
Console.WriteLine(rsingle); // Random number in [0, 1)
Console.WriteLine(rdouble); // Random number in [0, 1)

// Random.Next Aliases
Console.WriteLine(rnext(16));               // Random int in [0, 16)
Console.WriteLine(rnextint(16));            // Random int in [0, 16)
Console.WriteLine(rnextint32(16));          // Random int in [0, 16)
Console.WriteLine(rnext(120, 160));         // Random int in [120, 160)
Console.WriteLine(rnextint(120, 160));      // Random int in [120, 160)
Console.WriteLine(rnextint32(120, 160));    // Random int in [120, 160)

// Random.NextInt64 Aliases
Console.WriteLine(rnext(16L));               // Random long in [0, 16)
Console.WriteLine(rnextlong(16L));           // Random long in [0, 16)
Console.WriteLine(rnextint64(16L));          // Random long in [0, 16)
Console.WriteLine(rnext(120L, 160L));         // Random long in [120, 160)
Console.WriteLine(rnextlong(120L, 160L));     // Random long in [120, 160)
Console.WriteLine(rnextint64(120L, 160L));    // Random long in [120, 160)
```

### Get Random Index
```cs
var array = new int[] { 1, 354, 62, 45, 65, };

// Returns a random index in [0, 5)
Console.WriteLine(rnextindex(array));

// Returns a random index in [0, 5) and outputs the element at the index
Console.WriteLine(rnextindex(array, out int number));
```

### Get Random Element
```cs
var array = new int[] { 1, 25, 743, 569, 654, };

// Gets a random element in array
Console.WriteLine(rnextelement(array));

// Gets a random element in array and outputs its index
Console.WriteLine(rnextelement(array, out int index));
```

## License
This work is licensed under [MIT](https://github.com/Arthri/Belp/blob/02b63f4be263d747f3078a0568bf235bf021d0cd/LICENSE).

# IX.StandardExtensions

## Introduction

IX.StandardExtensions is a .NET library that seeks to implement various extensions in order to
standardize access to some functionality.

The motivation behind this library was introduced in .NET 4 where the
[`List<T>`](https://msdn.microsoft.com/en-us/library/6sh2ey19.aspx) class introduced the ForEach
method. Arrays have their own static ForEach method (which turns out to be extremely slow compared
to the foreach cycle), whereas IEnumerable do not have a ForEach at all.

Then came the Task Parallel Library which introduced Parallel.ForEach, which uses IEnumerable as a
parameter.

So I came up with this library that exposes extension methods which give the same ForEach approach
to enumerable and to array.

Furthermore, the ICloneable interface is recommended by MSDN to not be used at all, leaving us with
no baked-in way to define an object which can have shallow clones or an object which can have deep
clones. I had to make my own.

This is, in a nutshell, how I came up with this library.

## Documentation

Documentation is available [at this address](https://adrianmos.eu/Pages/Projects/ixstandardextensions/docs.md)
(and is currently under construction :construction: ).

## Requirements

Requirements for IX.StandardExtensions are the same across IX projects.
[This page](https://adrianmos.eu/Pages/Projects/FrameworkVersionsSupport.md) lists estimative .NET
version support information across various frameworks and OSes.

## Releases

- NuGet: [![IX.StandardExtensions NuGet](https://img.shields.io/nuget/dt/IX.StandardExtensions.svg)](https://www.nuget.org/packages/IX.StandardExtensions/)
- Latest stable: [![IX.StandardExtensions NuGet](https://img.shields.io/nuget/v/IX.StandardExtensions.svg)](https://www.nuget.org/packages/IX.StandardExtensions/)
- Latest with pre-release: [![IX.StandardExtensions NuGet pre-release](https://img.shields.io/nuget/vpre/IX.StandardExtensions.svg)](https://www.nuget.org/packages/IX.StandardExtensions/)


## Highlights

- Extension methods for arrays that aim to implement the same behavior as IEnumerable
- Extension methods for string comparison (current/invariant culture, case sensitive/insensitive,
ordinal, etc.), such as string.CurrentCultureEqualsInsensitive()
- A character set detector at IX.StandardExtensions.Globalization.CharsetDetectionEngine
- Observable and thread-safe observable collections at IX.Observable
- Classes and extensions for undo/redo
- Thread-safe and atomic classes in IX.System.Threading
- Advanced locking and synchronization classes and extension methods in IX.System.Threading
- Object pools, standardized concurrent dictionaries and invalidating lazy in IX.Efficiency
- Busy UI scope and notification-related events and delegates in IX.StandardExtensions.ComponentModel
- Contracts-oriented helper methods for requires in IX.StandardExtensions.Contracts
- Abstractions for IO operations
- Standardized entitiy interfaces
- Asynchronous-related helper methods and classes

...and many many extension methods, as well as other goodies.

## Contributing

### Guidelines

Contributing can be done by anyone, at any time and in any form, as long as the
contributor has read the [contributing guidelines](https://adimosh.github.io/contributingguidelines)
beforehand and tries their best to abide by them.

### Licenses and structure

This project uses the MIT license. [![MIT license](https://img.shields.io/github/license/adimosh/ix.standardextensions)](LICENSE)

Additionally, the character set detection engine featured at _IX.StandardExtensions.Globalization_ takes bits and pieces from various other projects, and is licensed as such.
You can find the additional licenses in [/src/IX.StandardExtensions/StandardExtensions/Globalization/CharsetDetection/Licenses](src/IX.StandardExtensions/StandardExtensions/Globalization/CharsetDetection/Licenses).
The character set detector itself is based (and imports most of the code from) [Julian Verdurmen](https://github.com/304NotModified)'s [UTF-Unknown](https://github.com/CharsetDetector/UTF-unknown) project. All applicable licenses translate to this code.
Changes from that project are:
- public classes have been made internal
- as much as possible, code has been formatted in a better way
- as much as possible, long has been used instead of int

I have made an effort to keep the original files (headers and license notice included) intact as much as possible, however, adaptations will have occurred. I do not take any credit for that part of the code, all of it goes to Julian and the respective contributors and original developers.

## Usage

The library exposes a lot of methods in an attempt to standardize the approach to code, so we'll just take a few examples.

### ForEach on an IEnumerable.

Given we have:

```csharp
IEnumerable<someClass> someCollection;
```

We would call a method for each item of the collection like this:

```csharp
foreach (var item in someCollection)
{
    someMethod(item);
}
```

With the extension method, we could call it like this:

```csharp
someCollection.ForEach(someMethod);
```

The same would hold true for an array.

Although, to be fair, if you're going to have a benchmark of:

```csharp
i++;
```

...then the foreach cycle will be faster, since you will not have an extra method invocation.

As an extra bonus, you can run them using task parallel library (.NET Standard 1.1 and above only).

```csharp
someCollection.ParallelForEach(someMethod);
```

### Sequence Equals

The next example comes from the need to compare data. Comparison on arrays or enumerables (or between an array or an IEnumerable) has always been slightly burdensome. We have a helper for that:

```csharp
if (someCollection.SequenceEquals(someOtherCollection))
{
    // Do something
}
```

### Atomic enumerator

The _AtomicEnumerator_ class is an enumerator based on another enumerator, which synchronizes data fetching (e.g. the _Next_ and _Reset_ methods), and which will fail just like a regular enumerator if the collection is changed.
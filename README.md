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

## How to get

This project is primarily available through NuGet.

The current version can be accessed by using NuGet commands:

```powershell
Install-Package IX.StandardExtensions
```

Releases: [![IX.StandardExtensions NuGet](https://img.shields.io/nuget/v/IX.StandardExtensions.svg)](https://www.nuget.org/packages/IX.StandardExtensions/)

## Contributing

### Guidelines

Contributing can be done by anyone, at any time and in any form, as long as the
contributor has read the [contributing guidelines](https://adimosh.github.io/contributingguidelines)
beforehand and tries their best to abide by them.

## Licenses and structure

Please be aware that this project is a sub-project of [IX.Framework](https://github.com/adimosh/IX.Framework). All credits and license information should be taken from there.

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
// <copyright file="CharsetDetectorDataUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.IO.Compression;
using System.Reflection;
using System.Text;

using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.Globalization;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace IX.UnitTests.StandardExtensions.Globalization;

public class CharsetDetectorDataUnitTests
{
    private readonly ITestOutputHelper outputHelper;

    public CharsetDetectorDataUnitTests(ITestOutputHelper outputHelper) => Requires.NotNull(out this.outputHelper, outputHelper);

    public static IEnumerable<object[]> AllTestFiles()
    {
        var stream = Requires.NotNull(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("IX.UnitTests.StandardExtensions.Globalization.data.zip"));

        ZipArchive za = new ZipArchive(
            stream,
            ZipArchiveMode.Read,
            true);

        return za.Entries.Select(
            p =>
            {
                var folder = Path.GetDirectoryName(p.FullName)?.Split('(').First().Trim() ?? "ascii";
                var name = p.Name;
                return new TestCase(
                    p.FullName,
                    name,
                    folder);
            }).Select(p => new object[] { p }).ToList();
    }

    [Theory(DisplayName = "Synchronous encoding stream tests")]
    [MemberData(nameof(AllTestFiles))]
    public void TestStreamSync(TestCase testCase)
    {
        Encoding expectedEncoding = CharsetDetectionEngine.GetCompatibleEncodingByShortName(testCase.ExpectedEncoding);

        var stream = Requires.NotNull(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("IX.UnitTests.StandardExtensions.Globalization.data.zip"));

        ZipArchive za = new ZipArchive(
            stream,
            ZipArchiveMode.Read,
            true);

        var result = new CharsetDetectionEngine().Read(za.Entries.First(p => p.FullName == testCase.InputFile).Open());

        Assert.NotNull(result.Encoding);
        outputHelper.WriteLine($"- {testCase.FileName} ({testCase.ExpectedEncoding}) -> {result.Encoding.WebName}");
        Assert.Equal(expectedEncoding, result.Encoding);
    }

    [Theory(DisplayName = "Asynchronous encoding stream tests")]
    [MemberData(nameof(AllTestFiles))]
    public async Task TestStreamAsync(TestCase testCase, CancellationToken cancellationToken = default)
    {
        Encoding expectedEncoding = CharsetDetectionEngine.GetCompatibleEncodingByShortName(testCase.ExpectedEncoding);

        var stream = Requires.NotNull(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("IX.UnitTests.StandardExtensions.Globalization.data.zip"));

        ZipArchive za = new ZipArchive(
            stream,
            ZipArchiveMode.Read,
            true);

        var result = await new CharsetDetectionEngine().ReadAsync(za.Entries.First(p => p.FullName == testCase.InputFile).Open(), cancellationToken);

        Assert.NotNull(result.Encoding);
        outputHelper.WriteLine($"- {testCase.FileName} ({testCase.ExpectedEncoding}) -> {result.Encoding.WebName}");
        Assert.Equal(expectedEncoding, result.Encoding);
    }

    [Theory(DisplayName = "Synchronous encoding buffer tests")]
    [MemberData(nameof(AllTestFiles))]
    public void TestBufferSync(TestCase testCase)
    {
        Encoding expectedEncoding = CharsetDetectionEngine.GetCompatibleEncodingByShortName(testCase.ExpectedEncoding);

        var stream = Requires.NotNull(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("IX.UnitTests.StandardExtensions.Globalization.data.zip"));

        ZipArchive za = new ZipArchive(
            stream,
            ZipArchiveMode.Read,
            true);

        var result = new CharsetDetectionEngine().Read(za.Entries.First(p => p.FullName == testCase.InputFile).Open().ReadAllBytes());

        Assert.NotNull(result.Encoding);
        outputHelper.WriteLine($"- {testCase.FileName} ({testCase.ExpectedEncoding}) -> {result.Encoding.WebName}");
        Assert.Equal(expectedEncoding, result.Encoding);
    }

    [Theory(DisplayName = "Asynchronous encoding buffer tests")]
    [MemberData(nameof(AllTestFiles))]
    public async Task TestBufferAsync(TestCase testCase, CancellationToken cancellationToken = default)
    {
        Encoding expectedEncoding = CharsetDetectionEngine.GetCompatibleEncodingByShortName(testCase.ExpectedEncoding);

        var stream = Requires.NotNull(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("IX.UnitTests.StandardExtensions.Globalization.data.zip"));

        ZipArchive za = new ZipArchive(
            stream,
            ZipArchiveMode.Read,
            true);

        var result = await new CharsetDetectionEngine().ReadAsync(await za.Entries.First(p => p.FullName == testCase.InputFile).Open().ReadAllBytesAsync(cancellationToken), cancellationToken);

        Assert.NotNull(result.Encoding);
        outputHelper.WriteLine($"- {testCase.FileName} ({testCase.ExpectedEncoding}) -> {result.Encoding.WebName}");
        Assert.Equal(expectedEncoding, result.Encoding);
    }

    public class TestCase : IXunitSerializable
    {
        [UsedImplicitly]
        public TestCase()
        {
        }

        public TestCase(string inputFile, string fileName, string expectedEncoding)
        {
            ExpectedEncoding = expectedEncoding;
            FileName = fileName;
            InputFile = inputFile;
        }

        public string InputFile { get; private set; }

        public string FileName { get; private set; }

        public string ExpectedEncoding { get; private set; }

        public override string ToString() => ExpectedEncoding + ": " + FileName;

        /// <summary>
        /// Called when the object should populate itself with data from the serialization info.
        /// </summary>
        /// <param name="info">The info to get the data from.</param>
        public void Deserialize(IXunitSerializationInfo info)
        {
            InputFile = info.GetValue<string>(nameof(InputFile));
            FileName = info.GetValue<string>(nameof(FileName));
            ExpectedEncoding = info.GetValue<string>(nameof(ExpectedEncoding));
        }

        /// <summary>
        /// Called when the object should store its data into the serialization info.
        /// </summary>
        /// <param name="info">The info to store the data in.</param>
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(InputFile), InputFile, typeof(string));
            info.AddValue(nameof(FileName), FileName, typeof(string));
            info.AddValue(nameof(ExpectedEncoding), ExpectedEncoding, typeof(string));
        }
    }
}
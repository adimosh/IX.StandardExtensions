// <copyright file="CharsetDetectorDataUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Globalization;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace IX.UnitTests.StandardExtensions.Globalization;

public class CharsetDetectorDataUnitTests
{
    private readonly ITestOutputHelper outputHelper;

    public CharsetDetectorDataUnitTests(ITestOutputHelper outputHelper)
    {
        Requires.NotNull(out this.outputHelper, outputHelper);
    }

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

    [Theory]
    [MemberData(nameof(AllTestFiles))]
    public void TestFile(TestCase testCase)
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
        this.outputHelper.WriteLine($"- {testCase.FileName} ({testCase.ExpectedEncoding}) -> {result.Encoding.WebName}");
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
            this.ExpectedEncoding = expectedEncoding;
            this.FileName = fileName;
            this.InputFile = inputFile;
        }

        public string InputFile { get; private set; }

        public string FileName { get; private set; }

        public string ExpectedEncoding { get; private set; }

        public override string ToString() => this.ExpectedEncoding + ": " + this.FileName;

        /// <summary>
        /// Called when the object should populate itself with data from the serialization info.
        /// </summary>
        /// <param name="info">The info to get the data from.</param>
        public void Deserialize(IXunitSerializationInfo info)
        {
            this.InputFile = info.GetValue<string>(nameof(this.InputFile));
            this.FileName = info.GetValue<string>(nameof(this.FileName));
            this.ExpectedEncoding = info.GetValue<string>(nameof(this.ExpectedEncoding));
        }

        /// <summary>
        /// Called when the object should store its data into the serialization info.
        /// </summary>
        /// <param name="info">The info to store the data in.</param>
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(this.InputFile), this.InputFile, typeof(string));
            info.AddValue(nameof(this.FileName), this.FileName, typeof(string));
            info.AddValue(nameof(this.ExpectedEncoding), this.ExpectedEncoding, typeof(string));
        }
    }
}
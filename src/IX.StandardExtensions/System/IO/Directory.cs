// <copyright file="Directory.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;
using FSDir = System.IO.Directory;

namespace IX.System.IO;

/// <summary>
///     A class for implementing <see cref="IDirectory" /> with <see cref="System.IO.Directory" />.
/// </summary>
/// <seealso cref="IX.System.IO.IDirectory" />
/// <seealso cref="System.IO.Directory" />
[PublicAPI]
public class Directory : IDirectory
{
#region Internal state

    /// <summary>
    ///     The all file default search pattern.
    /// </summary>
    private const string AllFilePattern = "*.*";

    [SuppressMessage(
        "Performance",
        "HAA0604:Delegate allocation from a method group",
        Justification = "Unavoidable, we use this cached instance to preserve running time.")]
    private static readonly Func<string, DateTime> ReferenceMethodGetCreationTimeUtc = FSDir.GetCreationTimeUtc;

    [SuppressMessage(
        "Performance",
        "HAA0604:Delegate allocation from a method group",
        Justification = "Unavoidable, we use this cached instance to preserve running time.")]
    private static readonly Func<string, DirectoryInfo> ReferenceMethodInfoCreateDirectory = FSDir.CreateDirectory;

    [SuppressMessage(
        "Performance",
        "HAA0604:Delegate allocation from a method group",
        Justification = "Unavoidable, we use this cached instance to preserve running time.")]
    private static readonly Action<string> ReferenceMethodInfoDelete = FSDir.Delete;

    [SuppressMessage(
        "Performance",
        "HAA0604:Delegate allocation from a method group",
        Justification = "Unavoidable, we use this cached instance to preserve running time.")]
    private static readonly Func<string, DateTime> ReferenceMethodInfoGetLastAccessTimeUtc = FSDir.GetLastAccessTimeUtc;

    [SuppressMessage(
        "Performance",
        "HAA0604:Delegate allocation from a method group",
        Justification = "Unavoidable, we use this cached instance to preserve running time.")]
    private static readonly Func<string, DateTime> ReferenceMethodInfoGetLastWriteTimeUtc = FSDir.GetLastWriteTimeUtc;

#endregion

#region Methods

#region Static methods

    /// <summary>
    ///     Enumerates directories.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <returns>
    ///     The The enumerated directories.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<string> EnumerateDirectoriesInternal(
        string path,
        string searchPattern,
        bool recursively)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.EnumerateDirectories(
            localPath,
            localSearchPattern,
            recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
    }

    /// <summary>
    ///     Enumerates directories asynchronously.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The enumerated directories.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Task<IEnumerable<string>> EnumerateDirectoriesInternalAsync(
        string path,
        string searchPattern,
        bool recursively,
        CancellationToken cancellationToken)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return Work.OnThreadPoolAsync(
            state => FSDir.EnumerateDirectories(
                state.Path,
                state.Pattern,
                state.Recursive),
            (Path: localPath, Pattern: localSearchPattern, Recursive: recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly),
            cancellationToken);
    }

    /// <summary>
    ///     Enumerates files.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <returns>
    ///     The The enumerated files.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<string> EnumerateFilesInternal(
        string path,
        string searchPattern,
        bool recursively)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.EnumerateFiles(
            localPath,
            localSearchPattern,
            recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
    }

    /// <summary>
    ///     Enumerates files asynchronously.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The The enumerated files.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Task<IEnumerable<string>> EnumerateFilesInternalAsync(
        string path,
        string searchPattern,
        bool recursively,
        CancellationToken cancellationToken)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return Work.OnThreadPoolAsync(
            state => FSDir.EnumerateFiles(
                state.Path,
                state.Pattern,
                state.Recursive),
            (Path: localPath, Pattern: localSearchPattern, Recursive: recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly),
            cancellationToken);
    }

    /// <summary>
    ///     Enumerates file system entries.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <returns>
    ///     The The enumerated file system entries.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<string> EnumerateFileSystemEntriesInternal(
        string path,
        string searchPattern,
        bool recursively)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.EnumerateFileSystemEntries(
            localPath,
            localSearchPattern,
            recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
    }

    /// <summary>
    ///     Enumerates file system entries.
    /// </summary>
    /// <param name="path">
    ///     The path.
    /// </param>
    /// <param name="searchPattern">
    ///     The search pattern.
    /// </param>
    /// <param name="recursively">
    ///     Whether or not to execute this operation on folders recursively.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The The enumerated file system entries.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Task<IEnumerable<string>> EnumerateFileSystemEntriesInternalAsync(
        string path,
        string searchPattern,
        bool recursively,
        CancellationToken cancellationToken)
    {
        var localPath = Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        var localSearchPattern = Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return Work.OnThreadPoolAsync(
            state => FSDir.EnumerateFileSystemEntries(
                state.Path,
                state.Pattern,
                state.Recursively),
            (Path: localPath, Pattern: localSearchPattern, Recursively: recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly),
            cancellationToken);
    }

#endregion

#region Interface implementations

    /// <summary>
    ///     Creates a new directory.
    /// </summary>
    /// <param name="path">The path of the new directory.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public void CreateDirectory(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSDir.CreateDirectory(path);
    }

    /// <summary>
    ///     Asynchronously creates a new directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task.
    /// </returns>
    public Task CreateDirectoryAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return ReferenceMethodInfoCreateDirectory.OnThreadPoolAsync(
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Deletes a directory, optionally also doing a recursive delete.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="recursive">
    ///     If set to <see langword="true" />, does a recursive delete. This is <see langword="false" /> by
    ///     default.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public void Delete(
        string path,
        bool recursive = false)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        if (recursive)
        {
            FSDir.Delete(
                path,
                true);
        }
        else
        {
            FSDir.Delete(path);
        }
    }

    /// <summary>
    ///     Asynchronously deletes a directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="recursive"><see langword="true" /> if deletion should be recursive to all subdirectories.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task.</returns>
    public Task DeleteAsync(
        string path,
        bool recursive = false,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        if (recursive)
        {
            return Work.OnThreadPoolAsync(
                state => FSDir.Delete(
                    state.Path,
                    state.Recursive),
                (Path: path, Recursive: true),
                cancellationToken);
        }

        return ReferenceMethodInfoDelete.OnThreadPoolAsync(
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Enumerates the subdirectories of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the subdirectories of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateDirectories(string path) =>
        EnumerateDirectoriesInternal(
            path,
            AllFilePattern,
            false);

    /// <summary>
    ///     Enumerates the subdirectories of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The pattern to search.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the subdirectories of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" />
    ///     or
    ///     <paramref name="searchPattern" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateDirectories(
        string path,
        string searchPattern) =>
        EnumerateDirectoriesInternal(
            path,
            searchPattern,
            false);

    /// <summary>
    ///     Asynchronously enumerates all the directories contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of directory paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateDirectoriesAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateDirectoriesInternalAsync(
            path,
            AllFilePattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Asynchronously enumerates the directories contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of directory paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateDirectoriesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateDirectoriesInternalAsync(
            path,
            searchPattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Enumerates all the directories contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of directory paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateDirectoriesRecursively(string path) =>
        EnumerateDirectoriesInternal(
            path,
            AllFilePattern,
            true);

    /// <summary>
    ///     Enumerates the directories contained at a certain directory and all the subdirectories with a specific search
    ///     pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of directory paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" />
    ///     or
    ///     <paramref name="searchPattern" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateDirectoriesRecursively(
        string path,
        string searchPattern) =>
        EnumerateDirectoriesInternal(
            path,
            searchPattern,
            true);

    /// <summary>
    ///     Enumerates all the directories contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of directory paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateDirectoriesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateDirectoriesInternalAsync(
            path,
            AllFilePattern,
            true,
            cancellationToken);

    /// <summary>
    ///     Asynchronously enumerates the directories contained at a certain directory and all the subdirectories with a
    ///     specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of directory paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateDirectoriesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateDirectoriesInternalAsync(
            path,
            searchPattern,
            true,
            cancellationToken);

    /// <summary>
    ///     Enumerates the files of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the files of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFiles(string path) =>
        EnumerateFilesInternal(
            path,
            AllFilePattern,
            false);

    /// <summary>
    ///     Enumerates the files of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The pattern to search.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the files of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFiles(
        string path,
        string searchPattern) =>
        EnumerateFilesInternal(
            path,
            searchPattern,
            false);

    /// <summary>
    ///     Asynchronously enumerates all the files contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFilesAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateFilesInternalAsync(
            path,
            AllFilePattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Asynchronously enumerates the files contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFilesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateFilesInternalAsync(
            path,
            searchPattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Enumerates all the files contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFilesRecursively(string path) =>
        EnumerateFilesInternal(
            path,
            AllFilePattern,
            true);

    /// <summary>
    ///     Enumerates the files contained at a certain directory and all the subdirectories with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFilesRecursively(
        string path,
        string searchPattern) =>
        EnumerateFilesInternal(
            path,
            searchPattern,
            true);

    /// <summary>
    ///     Asynchronously enumerates all the files contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFilesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateFilesInternalAsync(
            path,
            AllFilePattern,
            true,
            cancellationToken);

    /// <summary>
    ///     Asynchronously enumerates the files contained at a certain directory and all the subdirectories with a specific
    ///     search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFilesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateFilesInternalAsync(
            path,
            searchPattern,
            true,
            cancellationToken);

    /// <summary>
    ///     Enumerates the file system entries of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the file system entries of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFileSystemEntries(string path) =>
        EnumerateFileSystemEntriesInternal(
            path,
            AllFilePattern,
            false);

    /// <summary>
    ///     Enumerates the file system entries of a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The pattern to search.</param>
    /// <returns>
    ///     An enumerable of <c>string</c> values with the paths of the file system entries of this directory.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFileSystemEntries(
        string path,
        string searchPattern) =>
        EnumerateFileSystemEntriesInternal(
            path,
            searchPattern,
            false);

    /// <summary>
    ///     Asynchronously enumerates all the file system entries contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file system entry paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFileSystemEntriesAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateFileSystemEntriesInternalAsync(
            path,
            AllFilePattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Asynchronously enumerates the file system entries contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file system entry paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFileSystemEntriesAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateFileSystemEntriesInternalAsync(
            path,
            searchPattern,
            false,
            cancellationToken);

    /// <summary>
    ///     Enumerates all the file system entries contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFileSystemEntriesRecursively(string path) =>
        EnumerateFileSystemEntriesInternal(
            path,
            AllFilePattern,
            true);

    /// <summary>
    ///     Enumerates the file system entries contained at a certain directory and all the subdirectories with a specific
    ///     search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>An enumerable of file system entry paths.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public IEnumerable<string> EnumerateFileSystemEntriesRecursively(
        string path,
        string searchPattern) =>
        EnumerateFileSystemEntriesInternal(
            path,
            searchPattern,
            true);

    /// <summary>
    ///     Asynchronously enumerates all the file system entries contained at a certain directory and all the subdirectories.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file system entry paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFileSystemEntriesRecursivelyAsync(
        string path,
        CancellationToken cancellationToken = default) =>
        EnumerateFileSystemEntriesInternalAsync(
            path,
            AllFilePattern,
            true,
            cancellationToken);

    /// <summary>
    ///     EAsynchronously enumerates the file system entries contained at a certain directory and all the subdirectories with
    ///     a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has an enumerable of file system entry paths as result.
    /// </returns>
    public Task<IEnumerable<string>> EnumerateFileSystemEntriesRecursivelyAsync(
        string path,
        string searchPattern,
        CancellationToken cancellationToken = default) =>
        EnumerateFileSystemEntriesInternalAsync(
            path,
            searchPattern,
            true,
            cancellationToken);

    /// <summary>
    ///     Checks whether a certain sub-directory exists.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     <see langword="true" /> if the directory exists, <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public bool Exists(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.Exists(path);
    }

    /// <summary>
    ///     Asynchronously checks whether a directory exists and is accessible.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     Returns a task that has the result of a boolean of value <see langword="true" /> if the specified directory exists
    ///     and is accessible, <see langword="false" /> otherwise.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Acceptable here.")]
    public Task<bool> ExistsAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return Work.OnThreadPoolAsync(
            FSDir.Exists,
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Gets a specific directory's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public DateTime GetCreationTime(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetCreationTimeUtc(path);
    }

    /// <summary>
    ///     Asynchronously gets a specific directory's creation time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    public Task<DateTime> GetCreationTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return ReferenceMethodGetCreationTimeUtc.OnThreadPoolAsync(
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Gets the current directory.
    /// </summary>
    /// <returns>The current directory.</returns>
    public string GetCurrentDirectory() => FSDir.GetCurrentDirectory();

    /// <summary>
    ///     Gets a specific directory's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public DateTime GetLastAccessTime(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetLastAccessTimeUtc(path);
    }

    /// <summary>
    ///     GAsynchronously gets a specific directory's last access time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    public Task<DateTime> GetLastAccessTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return ReferenceMethodInfoGetLastAccessTimeUtc.OnThreadPoolAsync(
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Gets a specific directory's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> in UTC.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public DateTime GetLastWriteTime(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetLastWriteTimeUtc(path);
    }

    /// <summary>
    ///     Asynchronously gets a specific directory's last write time, in UTC.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A task that has a <see cref="DateTime" /> in UTC.
    /// </returns>
    public Task<DateTime> GetLastWriteTimeAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return ReferenceMethodInfoGetLastWriteTimeUtc.OnThreadPoolAsync(
            path,
            cancellationToken);
    }

    /// <summary>
    ///     Moves a directory to another location.
    /// </summary>
    /// <param name="sourceDirName">The source directory name.</param>
    /// <param name="destDirName">The destination directory name.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="destDirName" /> or <paramref name="sourceDirName" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public void Move(
        string sourceDirName,
        string destDirName)
    {
        Requires.NotNullOrWhiteSpace(
            sourceDirName,
            nameof(sourceDirName));
        Requires.NotNullOrWhiteSpace(
            destDirName,
            nameof(destDirName));

        FSDir.Move(
            sourceDirName,
            destDirName);
    }

    /// <summary>
    ///     Asynchronously moves a directory to another location.
    /// </summary>
    /// <param name="sourceDirectoryName">The source directory name.</param>
    /// <param name="destinationDirectoryName">The destination directory name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task.</returns>
    public Task MoveAsync(
        string sourceDirectoryName,
        string destinationDirectoryName,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            sourceDirectoryName,
            nameof(sourceDirectoryName));
        Requires.NotNullOrWhiteSpace(
            destinationDirectoryName,
            nameof(destinationDirectoryName));

        return Work.OnThreadPoolAsync(
            state => FSDir.Move(
                state.Source,
                state.Destination),
            (Source: sourceDirectoryName, Destination: destinationDirectoryName),
            cancellationToken);
    }

    /// <summary>
    ///     Sets the directory's creation time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public void SetCreationTime(
        string path,
        DateTime creationTime)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSDir.SetCreationTime(
            path,
            creationTime);
    }

    /// <summary>
    ///     Asynchronously sets the directory's creation time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="creationTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task.</returns>
    public Task SetCreationTimeAsync(
        string path,
        DateTime creationTime,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return Work.OnThreadPoolAsync(
            state => FSDir.SetCreationTime(
                state.Path,
                state.CreationTime),
            (Path: path, CreationTime: creationTime),
            cancellationToken);
    }

    /// <summary>
    ///     Sets the directory's last access time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public void SetLastAccessTime(
        string path,
        DateTime lastAccessTime)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSDir.SetLastAccessTime(
            path,
            lastAccessTime);
    }

    /// <summary>
    ///     Asynchronously sets the directory's last access time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastAccessTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task.</returns>
    public Task SetLastAccessTimeAsync(
        string path,
        DateTime lastAccessTime,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return Work.OnThreadPoolAsync(
            state => FSDir.SetLastAccessTime(
                state.Path,
                state.LastAccessTime),
            (Path: path, LastAccessTime: lastAccessTime),
            cancellationToken);
    }

    /// <summary>
    ///     Sets the directory's last write time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public void SetLastWriteTime(
        string path,
        DateTime lastWriteTime)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        FSDir.SetLastWriteTime(
            path,
            lastWriteTime);
    }

    /// <summary>
    ///     Asynchronously sets the directory's last write time.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="lastWriteTime">A <see cref="DateTime" /> with the directory attribute to set.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task.</returns>
    public Task SetLastWriteTimeAsync(
        string path,
        DateTime lastWriteTime,
        CancellationToken cancellationToken = default)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return Work.OnThreadPoolAsync(
            state => FSDir.SetLastWriteTime(
                state.Path,
                state.LastWriteTime),
            (Path: path, LastWriteTime: lastWriteTime),
            cancellationToken);
    }

#endregion

    /// <summary>
    ///     Lists all the directories contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An array of directory paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public string[] GetDirectories(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetDirectories(path);
    }

    /// <summary>
    ///     Lists all the directories contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>
    ///     An array of directory paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public string[] GetDirectories(
        string path,
        string searchPattern)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.GetDirectories(
            path,
            searchPattern);
    }

    /// <summary>
    ///     Lists all the files contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An array of file paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public string[] GetFiles(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetFiles(path);
    }

    /// <summary>
    ///     Lists all the files contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>
    ///     An array of file paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public string[] GetFiles(
        string path,
        string searchPattern)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.GetFiles(
            path,
            searchPattern);
    }

    /// <summary>
    ///     Lists all the file-system entries contained at a certain directory.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>
    ///     An array of file-system entry paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public string[] GetFileSystemEntries(string path)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));

        return FSDir.GetFileSystemEntries(path);
    }

    /// <summary>
    ///     Lists all the file-system entries contained at a certain directory with a specific search pattern.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <param name="searchPattern">The search pattern to use.</param>
    /// <returns>
    ///     An array of file-system entries paths.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="path" /> or <paramref name="searchPattern" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public string[] GetFileSystemEntries(
        string path,
        string searchPattern)
    {
        Requires.NotNullOrWhiteSpace(
            path,
            nameof(path));
        Requires.NotNullOrWhiteSpace(
            searchPattern,
            nameof(searchPattern));

        return FSDir.GetFileSystemEntries(
            path,
            searchPattern);
    }

#endregion
}
// <copyright file="ObservableUndoTransactionUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Guaranteed;
using IX.Observable;
using Xunit;

namespace IX.UnitTests.Observable;

/// <summary>
///     Unit tests for explicit transactions.
/// </summary>
public class ObservableUndoTransactionUnitTests
{
    /// <summary>
    ///     ObservableList complete explicit undo transaction block.
    /// </summary>
    [Fact(DisplayName = "ObservableList complete explicit undo transaction block")]
    public void UnitTest1()
    {
        // ARRANGE
        using (var list = new ObservableList<int>(new[] { 1, 2, 3, 4, 5 }))
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                4,
                list.Count);

            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            _ = Assert.Single(list);

            list.Undo();

            Assert.Equal(
                4,
                list.Count);

            list.Redo();

            _ = Assert.Single(list);
        }
    }

    /// <summary>
    ///     ObservableList incomplete explicit undo transaction block, throws exception.
    /// </summary>
    [Fact(DisplayName = "ObservableList incomplete explicit undo transaction block, throws exception")]
    public void UnitTest2()
    {
        // ARRANGE
        using (var list = new ObservableList<int>(new[] { 1, 2, 3, 4, 5 }))
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                4,
                list.Count);

#pragma warning disable IDISP004 // Don't ignore return value of type IDisposable. - Ignoring it here is the point of the unit test
            _ = list.StartExplicitUndoBlockTransaction();
#pragma warning restore IDISP004 // Don't ignore return value of type IDisposable.

            list.RemoveAt(0);
            list.RemoveAt(0);
            list.RemoveAt(0);

            _ = Assert.Single(list);

            try
            {
                list.Undo();
            }
            catch (Exception ex)
            {
                _ = Assert.IsType<InvalidOperationException>(ex);
            }
        }
    }

    /// <summary>
    ///     ObservableList complete explicit undo transaction block then other undoable action.
    /// </summary>
    [Fact(DisplayName = "ObservableList complete explicit undo transaction block then other undoable action")]
    public void UnitTest3()
    {
        // ARRANGE
        using (var list = new ObservableList<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }))
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                7,
                list.Count);

            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            Assert.Equal(
                4,
                list.Count);

            list.Undo();

            Assert.Equal(
                7,
                list.Count);

            list.Redo();

            Assert.Equal(
                4,
                list.Count);

            list.RemoveAt(0);

            Assert.Equal(
                3,
                list.Count);

            list.Undo();

            Assert.Equal(
                4,
                list.Count);

            list.Redo();

            Assert.Equal(
                3,
                list.Count);

            list.Undo();
            list.Undo();
            list.Undo();

            Assert.Equal(
                8,
                list.Count);
        }
    }

    /// <summary>
    ///     ObservableList complete explicit undo transaction block single.
    /// </summary>
    [Fact(DisplayName = "ObservableList complete explicit undo transaction block single")]
    public void UnitTest4()
    {
        // ARRANGE
        using (var list = new ObservableList<int>(new[] { 1, 2, 3, 4, 5 }))
        {
            // ACT & ASSERT
            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            _ = Assert.Single(list);

            list.Undo();

            Assert.Equal(
                5,
                list.Count);

            list.Redo();

            _ = Assert.Single(list);
        }
    }

    /// <summary>
    ///     ObservableList complete explicit undo transaction block with captured item.
    /// </summary>
    [Fact(DisplayName = "ObservableList complete explicit undo transaction block with captured item")]
    public void UnitTest5()
    {
        // ARRANGE
        using (var list = new ObservableList<CapturedItem>(
                   new[]
                   {
                       new CapturedItem { TestProperty = "1" },
                       new CapturedItem { TestProperty = "2" },
                       new CapturedItem { TestProperty = "3" },
                       new CapturedItem { TestProperty = "4" },
                       new CapturedItem { TestProperty = "5" },
                   })
               {
                   AutomaticallyCaptureSubItems = true,
               })
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                4,
                list.Count);

            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            _ = Assert.Single(list);

            list.Undo();

            Assert.Equal(
                4,
                list.Count);

            list.Redo();

            _ = Assert.Single(list);
        }
    }

    /// <summary>
    ///     ObservableList incomplete explicit undo transaction block, throws exception with captured item.
    /// </summary>
    [Fact(
        DisplayName =
            "ObservableList incomplete explicit undo transaction block, throws exception with captured item")]
    public void UnitTest6()
    {
        // ARRANGE
        using (var list = new ObservableList<CapturedItem>(
                   new[]
                   {
                       new CapturedItem { TestProperty = "1" },
                       new CapturedItem { TestProperty = "2" },
                       new CapturedItem { TestProperty = "3" },
                       new CapturedItem { TestProperty = "4" },
                       new CapturedItem { TestProperty = "5" },
                   })
               {
                   AutomaticallyCaptureSubItems = true,
               })
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                4,
                list.Count);

#pragma warning disable IDISP004 // Don't ignore return value of type IDisposable. - Ignoring it here is the point of the unit test
            _ = list.StartExplicitUndoBlockTransaction();
#pragma warning restore IDISP004 // Don't ignore return value of type IDisposable.

            list.RemoveAt(0);
            list.RemoveAt(0);
            list.RemoveAt(0);

            _ = Assert.Single(list);

            try
            {
                list.Undo();
            }
            catch (Exception ex)
            {
                _ = Assert.IsType<InvalidOperationException>(ex);
            }
        }
    }

    /// <summary>
    ///     ObservableList complete explicit undo transaction block then other undoable action with captured item.
    /// </summary>
    [Fact(
        DisplayName =
            "ObservableList complete explicit undo transaction block then other undoable action with captured item")]
    public void UnitTest7()
    {
        // ARRANGE
        using (var list = new ObservableList<CapturedItem>(
                   new[]
                   {
                       new CapturedItem { TestProperty = "1" },
                       new CapturedItem { TestProperty = "2" },
                       new CapturedItem { TestProperty = "3" },
                       new CapturedItem { TestProperty = "4" },
                       new CapturedItem { TestProperty = "5" },
                       new CapturedItem { TestProperty = "6" },
                       new CapturedItem { TestProperty = "7" },
                       new CapturedItem { TestProperty = "8" },
                   })
               {
                   AutomaticallyCaptureSubItems = true,
               })
        {
            // ACT & ASSERT
            list.RemoveAt(0);

            Assert.Equal(
                7,
                list.Count);

            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            Assert.Equal(
                4,
                list.Count);

            list.Undo();

            Assert.Equal(
                7,
                list.Count);

            list.Redo();

            Assert.Equal(
                4,
                list.Count);

            list.RemoveAt(0);

            Assert.Equal(
                3,
                list.Count);

            list.Undo();

            Assert.Equal(
                4,
                list.Count);

            list.Redo();

            Assert.Equal(
                3,
                list.Count);

            list.Undo();
            list.Undo();
            list.Undo();

            Assert.Equal(
                8,
                list.Count);
        }
    }

    /// <summary>
    ///     ObservableList complete explicit undo transaction block single with captured item.
    /// </summary>
    [Fact(DisplayName = "ObservableList complete explicit undo transaction block single with captured item")]
    public void UnitTest8()
    {
        // ARRANGE
        using (var list = new ObservableList<CapturedItem>(
                   new[]
                   {
                       new CapturedItem { TestProperty = "1" },
                       new CapturedItem { TestProperty = "2" },
                       new CapturedItem { TestProperty = "3" },
                       new CapturedItem { TestProperty = "4" },
                       new CapturedItem { TestProperty = "5" },
                   })
               {
                   AutomaticallyCaptureSubItems = true,
               })
        {
            // ACT & ASSERT
            using (OperationTransaction tc = list.StartExplicitUndoBlockTransaction())
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);

                tc.Success();
            }

            _ = Assert.Single(list);

            list.Undo();

            Assert.Equal(
                5,
                list.Count);

            list.Redo();

            _ = Assert.Single(list);
        }
    }
}
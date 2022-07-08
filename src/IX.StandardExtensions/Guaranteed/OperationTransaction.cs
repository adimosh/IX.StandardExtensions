// <copyright file="OperationTransaction.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.Guaranteed;

/// <summary>
/// A base class for a local, in-process, in-memory transaction.
/// </summary>
/// <remarks>
/// <para>This class is in no way related to transactions or distributed transactions, and will not promote a transaction scope to a distributed transaction.</para>
/// </remarks>
/// <seealso cref="IX.StandardExtensions.ComponentModel.DisposableBase" />
[PublicAPI]
public abstract class OperationTransaction : DisposableBase
{
    private readonly List<Tuple<Action<object>, object>> revertSteps;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationTransaction"/> class.
    /// </summary>
    protected OperationTransaction()
    {
        revertSteps = new List<Tuple<Action<object>, object>>();
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="OperationTransaction"/> is successful.
    /// </summary>
    /// <value><see langword="true"/> if successful; otherwise, <see langword="false"/>.</value>
    public bool Successful { get; private set; }

    /// <summary>
    /// Declares this operation transaction a success.
    /// </summary>
    public void Success() => Successful = true;

    /// <summary>
    /// Adds a revert step.
    /// </summary>
    /// <param name="action">The revert action.</param>
    /// <param name="state">The state object to pass to the revert action.</param>
    protected void AddRevertStep(Action<object> action, object state)
        => revertSteps.Add(
            new Tuple<Action<object>, object>(
                action,
                state));

    /// <summary>
    /// Gets invoked when the transaction commits and is successful.
    /// </summary>
    protected abstract void WhenSuccessful();

    /// <summary>
    /// Disposes in the general (managed and unmanaged) context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        base.DisposeGeneralContext();

        if (Successful)
        {
            WhenSuccessful();
        }
        else
        {
            foreach (Tuple<Action<object>, object> revertStep in revertSteps)
            {
                revertStep.Item1(revertStep.Item2);
            }
        }

        revertSteps.Clear();
    }
}
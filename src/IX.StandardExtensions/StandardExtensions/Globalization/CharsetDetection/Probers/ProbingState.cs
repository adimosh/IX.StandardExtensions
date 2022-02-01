#pragma warning disable SA1633 // File should have header - This is an imported file,

// original header with license shall remain the same

namespace UtfUnknown.Core.Probers;

internal enum ProbingState
{
    /// <summary>
    /// No sure answer yet, but caller can ask for confidence
    /// </summary>
    Detecting = 0, //

    /// <summary>
    /// Positive answer
    /// </summary>
    FoundIt = 1,

    /// <summary>
    /// Negative answer
    /// </summary>
    NotMe = 2
}
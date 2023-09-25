// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace HamedStack.RuleEngine;

/// <summary>
/// Represents an error encountered during rule execution by the <see cref="RuleEngine{T}"/>.
/// </summary>
public class RuleEngineError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuleEngineError"/> class.
    /// </summary>
    /// <remarks>
    /// This class represents an error that occurred during rule execution, including error messages.
    /// </remarks>
    public RuleEngineError()
    {
        Errors = new List<string>();
    }

    /// <summary>
    /// Gets or sets a list of errors associated with the rule execution error.
    /// </summary>
    /// <remarks>
    /// This list contains detailed error messages explaining the error that occurred.
    /// </remarks>
    public IList<string> Errors { get; set; }

    /// <summary>
    /// Gets or sets the name of the rule that produced the error.
    /// </summary>
    /// <remarks>
    /// This property stores the name of the rule that resulted in this error.
    /// </remarks>
    public string Name { get; set; } = null!;
}
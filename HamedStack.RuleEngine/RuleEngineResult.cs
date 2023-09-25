// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace HamedStack.RuleEngine;

/// <summary>
/// Represents the result of rule execution by the <see cref="RuleEngine{T}"/>.
/// </summary>
public class RuleEngineResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuleEngineResult"/> class.
    /// </summary>
    /// <remarks>
    /// This class represents the outcome of executing rules, including errors and the overall success status.
    /// </remarks>
    public RuleEngineResult()
    {
        Errors = new List<RuleEngineError>();
    }

    /// <summary>
    /// Gets or sets a list of errors encountered during rule execution.
    /// </summary>
    /// <remarks>
    /// This list contains details of errors that occurred while executing rules.
    /// </remarks>
    public IList<RuleEngineError> Errors { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the rule execution was successful.
    /// </summary>
    /// <remarks>
    /// This flag indicates whether all rules were executed successfully without errors.
    /// </remarks>
    public bool IsSuccessful { get; set; }
}
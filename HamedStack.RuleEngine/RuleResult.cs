// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace HamedStack.RuleEngine;

/// <summary>
/// Represents the result of rule validation.
/// </summary>
public class RuleResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuleResult"/> class.
    /// </summary>
    /// <remarks>
    /// This class represents the outcome of rule validation, including validation errors and validity status.
    /// </remarks>
    public RuleResult()
    {
        Errors = new List<string>();
    }

    /// <summary>
    /// Gets or sets a list of validation errors.
    /// </summary>
    /// <remarks>
    /// This list contains error messages indicating why the validation failed.
    /// </remarks>
    public IList<string> Errors { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the validation was successful.
    /// </summary>
    /// <remarks>
    /// This flag indicates whether the data passed validation according to the rule's criteria.
    /// </remarks>
    public bool IsValid { get; set; }

    /// <summary>
    /// Gets or sets the name of the rule.
    /// </summary>
    /// <remarks>
    /// This property stores the name of the rule to which this validation result belongs.
    /// </remarks>
    public string Name { get; set; } = null!;
}
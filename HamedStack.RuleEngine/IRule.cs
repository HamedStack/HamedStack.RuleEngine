// ReSharper disable UnusedMember.Global

namespace HamedStack.RuleEngine;

/// <summary>
/// Represents a rule that can be executed and validated on data of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of data to apply the rule to.</typeparam>
public interface IRule<in T>
{
    /// <summary>
    /// Gets or sets the name of the rule.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Executes the rule on the specified data.
    /// </summary>
    /// <param name="data">The data to be processed by the rule.</param>
    /// <remarks>
    /// This method performs an action on the data based on the rule's logic.
    /// </remarks>
    void Execute(T data);

    /// <summary>
    /// Validates the specified data using the rule.
    /// </summary>
    /// <param name="data">The data to be validated.</param>
    /// <returns>A <see cref="RuleResult"/> indicating whether the validation was successful.</returns>
    /// <remarks>
    /// This method evaluates the data against the rule's criteria and returns a result indicating
    /// whether the data is valid according to the rule.
    /// </remarks>
    RuleResult Validate(T data);
}
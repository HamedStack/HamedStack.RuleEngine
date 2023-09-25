namespace HamedStack.RuleEngine;

/// <summary>
/// Specifies the cascade mode for rule execution in the <see cref="RuleEngine{T}"/>.
/// </summary>
public enum RuleEngineCascadeMode
{
    /// <summary>
    /// Execution stops on the first failure encountered.
    /// </summary>
    StopOnFirstFailure,

    /// <summary>
    /// All rules are executed regardless of their validation status.
    /// </summary>
    RunAllPossible,

    /// <summary>
    /// Rules are executed only if they are valid.
    /// </summary>
    RunIfValid
}
// ReSharper disable UnusedMember.Global

// ReSharper disable UnusedType.Global

namespace HamedStack.RuleEngine;

/// <summary>
/// Represents a rule engine that can apply a collection of rules to data of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of data to which the rules will be applied.</typeparam>
public class RuleEngine<T>
{
    private readonly RuleEngineCascadeMode _cascadeMode;
    private readonly List<IRule<T>> _rules;

    /// <summary>
    /// Initializes a new instance of the <see cref="RuleEngine{T}"/> class with the specified cascade mode.
    /// </summary>
    /// <param name="cascadeMode">The cascade mode for rule execution.</param>
    /// <remarks>
    /// The cascade mode determines how the rules are executed, e.g., stopping on the first failure or running all rules.
    /// </remarks>
    public RuleEngine(RuleEngineCascadeMode cascadeMode)
    {
        _cascadeMode = cascadeMode;
        _rules = new List<IRule<T>>();
    }

    /// <summary>
    /// Adds a rule to the rule engine.
    /// </summary>
    /// <param name="rule">The rule to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rule"/> is null.</exception>
    /// <remarks>
    /// Use this method to add individual rules to the rule engine.
    /// </remarks>
    public void AddRule(IRule<T> rule)
    {
        if (rule == null) throw new ArgumentNullException(nameof(rule));
        _rules.Add(rule);
    }

    /// <summary>
    /// Adds multiple rules to the rule engine.
    /// </summary>
    /// <param name="rules">The rules to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rules"/> is null.</exception>
    /// <remarks>
    /// Use this method to add multiple rules to the rule engine at once.
    /// </remarks>
    public void AddRules(params IRule<T>[] rules)
    {
        if (rules == null) throw new ArgumentNullException(nameof(rules));
        foreach (var rule in rules)
        {
            _rules.Add(rule);
        }
    }

    /// <summary>
    /// Adds multiple rules to the rule engine.
    /// </summary>
    /// <param name="rules">The rules to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="rules"/> is null.</exception>
    /// <remarks>
    /// Use this method to add a collection of rules to the rule engine.
    /// </remarks>
    public void AddRules(IEnumerable<IRule<T>> rules)
    {
        if (rules == null) throw new ArgumentNullException(nameof(rules));
        foreach (var rule in rules)
        {
            _rules.Add(rule);
        }
    }

    /// <summary>
    /// Applies all the added rules to the specified data.
    /// </summary>
    /// <param name="data">The data to which the rules will be applied.</param>
    /// <returns>A <see cref="RuleEngineResult"/> indicating the result of rule application.</returns>
    /// <remarks>
    /// This method iterates through all the added rules, executing and validating them according to the cascade mode.
    /// </remarks>
    public RuleEngineResult ApplyRules(T data)
    {
        var result = new RuleEngineResult
        {
            IsSuccessful = true
        };
        foreach (var rule in _rules)
        {
            var ruleResult = rule.Validate(data);
            var status = ruleResult.IsValid;

            if (!status && result.IsSuccessful)
            {
                result.IsSuccessful = false;
            }

            if (!status && _cascadeMode == RuleEngineCascadeMode.StopOnFirstFailure)
            {
                result.Errors.Add(new RuleEngineError
                {
                    Name = rule.Name,
                    Errors = ruleResult.Errors,
                });
                break;
            }
            if (status && _cascadeMode == RuleEngineCascadeMode.RunIfValid)
            {
                rule.Execute(data);
            }
            if (_cascadeMode == RuleEngineCascadeMode.RunAllPossible)
            {
                if (!status)
                {
                    result.Errors.Add(new RuleEngineError
                    {
                        Name = rule.Name,
                        Errors = ruleResult.Errors,
                    });
                }
                else
                {
                    rule.Execute(data);
                }
            }
        }
        return result;
    }
}
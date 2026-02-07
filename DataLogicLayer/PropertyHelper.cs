using System.Linq.Expressions;

namespace DataLogicLayer;
public class ExpressionValidator<T>
{
    private readonly List<(Expression<Func<T, bool>> Rule, string Message)> _rules = new();

    public ExpressionValidator<T> AddRule(
        Expression<Func<T, bool>> rule,
        string errorMessage)
    {
        _rules.Add((rule, errorMessage));
        return this;
    }

    public ValidationResult Validate(T instance)
    {
        var errors = new List<string>();
        foreach (var (rule, message) in _rules)
        {
            var func = rule.Compile();
            if (!func(instance))
            {
                errors.Add(message);
            }
        }
        return new ValidationResult
        {
            IsValid = errors.Count == 0,
            Errors = errors
        };
    }
}
public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; }
}
public class User
{
    public int Age { get; set; }
    public string? Name { get; set; }
}

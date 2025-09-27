using System;
using System.Collections.Generic;

namespace CoffeeOrder
{
    public sealed class ValidationResult
    {
        public bool IsValid { get; }
        public IReadOnlyList<string> Errors { get; }

        public ValidationResult(bool isValid, IEnumerable<string> errors)
        {
            IsValid = isValid;
            Errors = new List<string>(errors);
        }

        public static ValidationResult Ok() =>
            new ValidationResult(true, Array.Empty<string>());

        public static ValidationResult Fail(params string[] errors) =>
            new ValidationResult(false, errors);
    }
}

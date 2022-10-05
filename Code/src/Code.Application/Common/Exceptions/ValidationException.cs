﻿using FluentValidation.Results;

namespace Code.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("One or more validation failure have ocuured")
    {
        Errors = new Dictionary<string, string[]>();
    }
    public ValidationException(IEnumerable<ValidationFailure> failures):this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failurGroup => failurGroup.Key, failurGroup => failurGroup.ToArray());
    }
    public IDictionary<string, string[]> Errors { get; }
}

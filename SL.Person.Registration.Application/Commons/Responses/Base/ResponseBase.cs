﻿using SL.Person.Registration.Application.Commons.Responses.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SL.Person.Registration.Application.Commons.Responses.Base;

public abstract class ResponseBase
{
    [JsonIgnore]
    public ErrorType ErrorType { get; private set; }

    [JsonIgnore]
    public bool IsSuccess { get { return !Errors.Any(); } }

    public List<string> Errors { get; private set; } = new List<string>();

    public void AddErrors(string error)
    {
        Errors ??= new List<string>();

        if (!string.IsNullOrWhiteSpace(error) && !Errors.Contains(error))
            Errors.Add(error);
    }

    public void SetErrorType(ErrorType errorType)
        => ErrorType = errorType;
}

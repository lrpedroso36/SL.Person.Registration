using System.Diagnostics.CodeAnalysis;

namespace SL.Person.Registration.Application.Results;

[ExcludeFromCodeCoverage]
public class FindLookupResult
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

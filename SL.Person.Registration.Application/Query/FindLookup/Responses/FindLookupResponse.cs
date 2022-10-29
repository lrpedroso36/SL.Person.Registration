using System.Diagnostics.CodeAnalysis;

namespace SL.Person.Registration.Application.Query.FindLookup.Responses;

[ExcludeFromCodeCoverage]
public class FindLookupResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

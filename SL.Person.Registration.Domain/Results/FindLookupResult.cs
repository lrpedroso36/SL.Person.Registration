using System.Diagnostics.CodeAnalysis;

namespace SL.Person.Registration.Domain.Results
{
    [ExcludeFromCodeCoverage]
    public class FindLookupResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

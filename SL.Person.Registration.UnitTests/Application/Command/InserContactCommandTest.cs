using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.Requests;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class InserContactCommandTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { 0,null },
            new object[] { 123456789,Builder<ContactRequest>.CreateNew().Build() },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(long documentNumber, ContactRequest request)
        {
            //arrange
            //act 
            var command = new InsertOrUpdateContactCommand(documentNumber, request);

            //assert
            command.DocumentNumber.Should().Be(documentNumber);
            command.Contact.Should().BeEquivalentTo(request);
        }
    }
}

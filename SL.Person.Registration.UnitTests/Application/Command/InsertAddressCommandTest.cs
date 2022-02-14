using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.Requests;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class InsertAddressCommandTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { 0, null },
            new object[] { 1234567890, Builder<AddressRequest>.CreateNew().Build() },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(long documentNumber, AddressRequest request)
        {
            //arrange
            //act 
            var command = new InsertOrUpdateAddressCommand(documentNumber, request);

            //assert
            command.Address.Should().BeEquivalentTo(request);
            command.DocumentNumber.Should().Be(documentNumber);
        }
    }
}

using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command.Person.Update;
using SL.Person.Registration.Application.Commons.Requests;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class UpdatePersonCommandTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new UpdatePersonCommand(null), null },
            new object[] { new UpdatePersonCommand(Builder<PersonRequest>.CreateNew().Build()), Builder<PersonRequest>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(UpdatePersonCommand command, PersonRequest personRequest)
        {
            //arrange
            //act
            //assert
            command.Person.Should().BeEquivalentTo(personRequest);
        }
    }
}

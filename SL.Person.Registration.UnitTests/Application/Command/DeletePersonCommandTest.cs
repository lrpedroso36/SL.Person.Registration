﻿using FluentAssertions;
using SL.Person.Registration.Application.Command.DeletePerson;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class DeletePersonCommandTest
    {
        [Fact]
        public void Should_set_laborer_document()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            //act
            var command = new DeletePersonCommand(id);

            //assert
            command.Id.Should().Be(id);
        }
    }
}

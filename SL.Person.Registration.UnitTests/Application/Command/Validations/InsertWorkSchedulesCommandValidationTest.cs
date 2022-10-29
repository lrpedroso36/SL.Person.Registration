using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command.InsertWorkSchedules;
using SL.Person.Registration.Application.Command.InsertWorkSchedules.Extensions;
using SL.Person.Registration.Application.Commons.Exceptions;
using System;
using System.Linq;
using Xunit;
using static SL.Person.Registration.Application.Command.InsertWorkSchedules.InsertWorkSchedulesCommand;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertWorkSchedulesCommandValidationTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasdasd")]
        public void Should_request_invalid_id(string id)
        {
            //arrange
            var request = new InsertWorkSchedulesCommand(id, Builder<WorkScheduleCommand>.CreateListOfSize(2).Build().ToList());

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new InsertWorkSchedulesCommand(Guid.NewGuid().ToString(), Builder<WorkScheduleCommand>.CreateListOfSize(2).Build().ToList());

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}

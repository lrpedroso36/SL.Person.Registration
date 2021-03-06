using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static SL.Person.Registration.Application.Command.InsertWorkSchedulesCommand;

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
            var request = new InsertWorkSchedulesCommand()
            {
                Id = id,
                Works = Builder<WorkScheduleCommand>.CreateListOfSize(2).Build().ToList()
            };

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new InsertWorkSchedulesCommand()
            {
                Id = Guid.NewGuid().ToString(),
                Works = Builder<WorkScheduleCommand>.CreateListOfSize(2).Build().ToList()
            };

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}

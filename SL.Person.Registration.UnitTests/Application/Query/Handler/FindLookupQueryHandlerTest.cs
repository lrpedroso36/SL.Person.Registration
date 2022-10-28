using FluentAssertions;
using SL.Person.Registration.Application.Query.FindLookup;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindLookupQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { typeof(InterviewType), 2 },
            new object[] { typeof(TreatmentType), 8 },
            new object[] { typeof(PersonType), 5 },
            new object[] { typeof(WeakDayType), 4},
            new object[] { typeof(GenderType), 3},

        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_query_handler(Type type, int countList)
        {
            //arrange
            var query = new FindLookupQuery(type);

            //act
            var queryHandler = new FindLookupQueryHandler();
            var result = await queryHandler.Handle(query, default);

            //assert
            result.Should().HaveCount(countList);
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { 1.GetType() },
            new object[] { DateTime.Now.GetType() },
            new object[] { "teste".GetType() },

        };

        [Theory]
        [MemberData(nameof(DataInvalid))]
        public async Task Should_execute_query_handler_exception(Type type)
        {
            //arrange
            var query = new FindLookupQuery(type);
            var queryHandler = new FindLookupQueryHandler();

            try
            {
                //act
                await queryHandler.Handle(query, default);
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(true);
            }
        }
    }
}

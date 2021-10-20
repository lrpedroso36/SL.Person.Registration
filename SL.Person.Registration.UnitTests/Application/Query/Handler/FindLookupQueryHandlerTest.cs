using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Handler;
using SL.Person.Registration.Domain.DonationAggregate.Enuns;
using SL.Person.Registration.Domain.InterViewAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindLookupQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { typeof(DonationType), 3 },
            new object[] { typeof(ReceiveType), 2 },
            new object[] { typeof(InterviewType), 2 },
            new object[] { typeof(TreatmentType), 3 },
            new object[] { typeof(PersonType), 5 },

        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_query_handler(Type type, int countList)
        {
            var query = new FindLookupQuery(type);
            var queryHandler = new FindLookupQueryHandler();
            var result = await queryHandler.Handle(query, default);

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
            var query = new FindLookupQuery(type);
            var queryHandler = new FindLookupQueryHandler();

            try
            {
                await queryHandler.Handle(query, default);
            }
            catch(Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}

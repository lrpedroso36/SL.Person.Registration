using System;
using System.Collections.Generic;
using FluentAssertions;
using SL.Person.Registration.Domain.DonationAggregate;
using SL.Person.Registration.Domain.DonationAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.DonationAggregate
{
    public class DonationTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { DonationType.Compra, ReceiveType.Beneficiado, new DateTime(2021,10,20), "name", "descricao" }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(DonationType type, ReceiveType receive, DateTime date, string name, string description)
        {
            var donation = Donation.CreateInstance(type, receive, date, name, description);

            donation.Type.Should().Be(type);

            donation.Receive.Should().Be(receive);

            donation.Date.Should().Be(date);

            donation.Name.Should().Be(name);
            donation.Name.Should().BeOfType(typeof(string));

            donation.Description.Should().Be(description);
            donation.Description.Should().BeOfType(typeof(string));
        }
    }
}

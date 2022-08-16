using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Requests;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Requests
{
    public class PersonRequestTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { Builder<PersonRequest>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_get_person(PersonRequest personRequest)
        {
            //arrange
            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Types.Should().BeEquivalentTo(personRequest.Types);
            person.Name.Should().Be(personRequest.Name.ToUpper());
            person.Gender.Should().Be(personRequest.Gender);
            person.BithDate.Should().Be(personRequest.BirthDate);
            person.DocumentNumber.Should().Be(personRequest.DocumentNumber);
            person.Contact.DDD.Should().Be(personRequest.DDD);
            person.Contact.PhoneNumber.Should().Be(personRequest.PhoneNumber);
            person.Address.ZipCode.Should().Be(personRequest.ZipCode);
            person.Address.Street.Should().Be(personRequest.Street.ToUpper());
            person.Address.Number.Should().Be(personRequest.Number.ToUpper());
            person.Address.Neighborhood.Should().Be(personRequest.Neighborhood.ToUpper());
            person.Address.Complement.Should().Be(personRequest.Complement.ToUpper());
            person.Address.City.Should().Be(personRequest.City.ToUpper());
            person.Address.State.Should().Be(personRequest.State.ToUpper());
        }

        [Theory]
        [InlineData(11, 0)]
        [InlineData(0, 123456789)]
        [InlineData(11, 123456789)]
        public void Should_get_contact_person(int ddd, long phoneNumber)
        {
            //arrange
            var personRequest = Builder<PersonRequest>.CreateNew().Build();
            personRequest.DDD = ddd;
            personRequest.PhoneNumber = phoneNumber;

            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Contact.Should().NotBeNull();
        }

        [Fact]
        public void Should_get_contact_person_is_null()
        {
            //arrange
            var personRequest = Builder<PersonRequest>.CreateNew().Build();
            personRequest.DDD = 0;
            personRequest.PhoneNumber = 0;

            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Contact.Should().BeNull();
        }

        [Theory]
        [InlineData("123456789", "", "", "", "", "", "")]
        [InlineData("", "rua", "", "", "", "", "")]
        [InlineData("", "", "numero", "", "", "", "")]
        [InlineData("", "", "", "bairro", "", "", "")]
        [InlineData("", "", "", "", "cidade", "", "")]
        [InlineData("", "", "", "", "", "estado", "")]
        public void Should_get_address_person(string zipCode, string street, string number, string neighborhood, string city, string state, string complement)
        {
            //arrange
            var personRequest = Builder<PersonRequest>.CreateNew().Build();
            personRequest.ZipCode = zipCode;
            personRequest.Street = street;
            personRequest.Number = number;
            personRequest.Neighborhood = neighborhood;
            personRequest.City = city;
            personRequest.State = state;
            personRequest.Complement = complement;

            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Address.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_get_address_person_is_null(string value)
        {
            //arrange
            var personRequest = Builder<PersonRequest>.CreateNew().Build();
            personRequest.ZipCode = value;
            personRequest.Street = value;
            personRequest.Number = value;
            personRequest.Neighborhood = value;
            personRequest.City = value;
            personRequest.State = value;
            personRequest.Complement = value;

            //act
            var person = personRequest.GetPersonRegistration();

            //assert
            person.Address.Should().BeNull();
        }
    }
}

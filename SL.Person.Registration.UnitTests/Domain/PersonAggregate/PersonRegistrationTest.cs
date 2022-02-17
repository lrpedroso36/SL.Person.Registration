using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class PersonRegistrationTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890
            },
            new object[]
            {
                new List<PersonType> { PersonType.Assistido },
                "nome",
                GenderType.Masculino,
                33,
                1234567890
             }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Shoud_set_properties(List<PersonType> types,
             string name,
             GenderType gender,
             int yeasOld,
             long documentNumber)
        {
            //arrange
            //act
            var person = PersonRegistration.CreateInstance(types, name, gender, yeasOld, documentNumber);

            //assert
            person.Types.Should().BeEquivalentTo(types);

            person.Name.Should().Be(name);
            person.Name.Should().BeOfType(typeof(string));

            person.Gender.Should().Be(gender);

            person.YearsOld.Should().Be(yeasOld);
            person.YearsOld.Should().BeOfType(typeof(int));

            person.DocumentNumber.Should().Be(documentNumber);
            person.DocumentNumber.Should().BeOfType(typeof(long));

            person.Address.Should().BeNull();

            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Should_set_properties_short_instace()
        {
            //arrange
            var id = Guid.NewGuid();
            var types = new List<PersonType> { PersonType.Assistido };
            var name = "Nome";
            var documentNumber = 123456789L;

            //act
            var person = PersonRegistration.CreateInstance(id, types, name, documentNumber);

            //asserts
            person._id.Should().Be(id);
            person.Types.Should().BeEquivalentTo(types);
            person.Name.Should().Be(name);
            person.DocumentNumber.Should().Be(documentNumber);

            person.Gender.Should().Be(0);
            person.YearsOld.Should().Be(0);
            person.Address.Should().BeNull();
            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Should_add_person_type()
        {
            //arrange
            var personType = PersonType.Palestrante;
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddPersonType(personType);

            //assert
            person.Types.Should().Contain(personType);
        }

        [Fact]
        public void Should_not_add_person_type()
        {
            //arrage
            var personType = PersonType.Palestrante;
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddPersonType(personType);
            person.AddPersonType(personType);

            //assert
            person.Types.Should().HaveCount(1);
            person.Types.Should().Contain(personType);
        }

        [Fact]
        public void Should_add_address()
        {
            //arrange
            var address = Builder<Address>.CreateNew().Build();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddAdress(address);

            //assert
            person.Address.Should().BeEquivalentTo(address);
        }

        [Fact]
        public void Should_add_contact()
        {
            //arrange 
            var contact = Builder<Contact>.CreateNew().Build();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddContact(contact);

            //assert
            person.Contact.Should().BeEquivalentTo(contact);
        }

        [Fact]
        public void Should_set_presence_tratament()
        {
            //arrange
            var person = Builder<PersonRegistration>.CreateNew().Build();
            var personInterviewer = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Entrevistador }, "nome", 123456789);
            var personLaborer = PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Tarefeiro }, "nome", 123456789);
            person.AddInterview(Interview.CreateInstance(TreatmentType.TratamentoEspiritual, WeakDayType.Sabado, InterviewType.Primeira, new DateTime(2022, 2, 5), personInterviewer, 1, "opnião"));

            var tramentCompare = Tratament.CreateInstance(new DateTime(2022, 2, 10), personLaborer, true);

            //act
            person.SetPresenceTratament(new DateTime(2022, 2, 10), personLaborer);

            //assert
            var interview = person.Interviews.FirstOrDefault();
            var tratament = interview.Trataments.FirstOrDefault();
            tratament.Should().BeEquivalentTo(tramentCompare);
        }

        public static List<object[]> DateAssignment = new List<object[]>
        {
            new object[] { true, new DateTime(2022,2,12) },
            new object[] { false, new DateTime(2022,2,12) }
        };

        [Theory]
        [MemberData(nameof(DateAssignment))]
        public void Should_set_presence_assgment(bool presence, DateTime date)
        {
            //arrange
            var person = Builder<PersonRegistration>.CreateNew().Build();
            var list = new List<Assignment>() { Assignment.CreateInstance(date, presence) };

            //act
            person.SetPresenceAssignment(date, presence);

            //assert
            person.Assignments.Should().HaveCount(1);
            person.Assignments.Should().BeEquivalentTo(list);

        }
    }
}

﻿using FizzWare.NBuilder;
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
        [Fact]
        public void Shoud_set_properties()
        {
            //arrange
            var types = new List<PersonType> { PersonType.Assistido() };
            var name = "Nome";
            var gender = GenderType.Masculino;
            var birthDate = new DateTime(1988, 04, 29);
            var documentNumber = 123456789L;

            //act
            var person = PersonRegistration.CreateInstance(types, name, gender, birthDate, documentNumber);

            //assert
            var personTypes = person.PersonRegistrationPersonTypes.Select(x => x.PersonType);
            personTypes.Should().BeEquivalentTo(types);
            person.Name.Should().Be(name);
            person.Name.Should().BeOfType(typeof(string));
            person.Gender.Should().Be(gender);
            person.BithDate.Should().Be(birthDate);
            person.DocumentNumber.Should().Be(documentNumber);
            person.DocumentNumber.Should().BeOfType(typeof(long));
            person.IsExcluded.Should().BeFalse();

            person.Address.Should().BeNull();
            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Shoud_set_properties_update_instance()
        {
            //arrange
            var id = Guid.NewGuid();
            var types = new List<PersonType> { PersonType.Assistido() };
            var name = "Nome";
            var gender = GenderType.Masculino;
            var birthDate = new DateTime(1988, 04, 29);
            var documentNumber = 123456789L;
            var interviews = Builder<Interview>.CreateListOfSize(1).Build().ToList();
            var assignments = Builder<Assignment>.CreateListOfSize(1).Build().ToList();
            var workSchedules = Builder<WorkSchedule>.CreateListOfSize(1).Build().ToList();

            //act
            var person = PersonRegistration.CreateUpdateInstance(id, types, name, gender, birthDate, documentNumber, interviews, assignments, workSchedules);

            //assert
            var personTypes = person.PersonRegistrationPersonTypes.Select(x => x.PersonType);
            personTypes.Should().BeEquivalentTo(types);
            person.Name.Should().Be(name);
            person.Name.Should().BeOfType(typeof(string));
            person.Gender.Should().Be(gender);
            person.BithDate.Should().Be(birthDate);
            person.DocumentNumber.Should().Be(documentNumber);
            person.DocumentNumber.Should().BeOfType(typeof(long));
            person.IsExcluded.Should().BeFalse();

            person.Interviews.Should().NotBeNull();
            person.Assignments.Should().NotBeNull();
            person.WorkSchedules.Should().NotBeNull();

        }

        [Fact]
        public void Should_set_properties_instance_simple()
        {
            //arrange
            var id = Guid.NewGuid();
            var types = new List<PersonType> { PersonType.Assistido() };
            var name = "Nome";
            var documentNumber = 123456789L;

            //act
            var person = PersonRegistration.CreateInstanceSimple(id, types, name, documentNumber);

            //asserts
            person.Id.Should().Be(id);
            var personTypes = person.PersonRegistrationPersonTypes.Select(x => x.PersonType);
            personTypes.Should().BeEquivalentTo(types);
            person.Name.Should().Be(name);
            person.DocumentNumber.Should().Be(documentNumber);
            person.IsExcluded.Should().BeFalse();

            person.Gender.Should().Be(0);
            person.BithDate.Should().Be(null);
            person.Address.Should().BeNull();
            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Should_add_person_type()
        {
            //arrange
            var personType = PersonType.Assistido();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddPersonType(personType);

            //assert
            var personTypes = person.PersonRegistrationPersonTypes.Select(x => x.PersonType);
            personTypes.Should().Contain(personType);
        }

        [Fact]
        public void Should_not_add_person_type()
        {
            //arrage
            var personType = PersonType.Assistido();
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddPersonType(personType);
            person.AddPersonType(personType);

            //assert
            var personTypes = person.PersonRegistrationPersonTypes.Select(x => x.PersonType);
            personTypes.Should().HaveCount(1);
            personTypes.Should().Contain(personType);
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
        public void Should_not_add_address()
        {
            //arrange
            Address address = null;
            var person = Builder<PersonRegistration>.CreateNew().Build();
            //act
            person.AddAdress(address);

            //assert
            person.Address.Should().BeNull();
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
        public void Should_not_add_contact()
        {
            //arrange 
            Contact contact = null;
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.AddContact(contact);

            //assert
            person.Contact.Should().BeNull();
        }

        [Fact]
        public void Should_set_presence_tratament()
        {
            //arrange
            var person = Builder<PersonRegistration>.CreateNew().Build();
            var personInterviewer = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido() }, "nome", 123456789);
            var personLaborer = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido() }, "nome", 123456789);
            person.AddInterview(Interview.CreateInstance(TreatmentType.TratamentoEspiritual, WeakDayType.Sabado, InterviewType.Primeira, new DateTime(2022, 2, 5), personInterviewer, 1, "opnião"));

            var tramentCompare = Tratament.CreateInstance(new DateTime(2022, 2, 10), true);

            //act
            person.SetPresenceTratament(new DateTime(2022, 2, 10));

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

        public static List<object[]> DateWorkSchedule = new List<object[]>
        {
            new object[] { WeakDayType.SextaFeira, new DateTime(2022,2,12), true },
            new object[] { WeakDayType.SextaFeira, new DateTime(2022,2,12), false }
        };

        [Theory]
        [MemberData(nameof(DateWorkSchedule))]
        public void Should_set_work_schedule(WeakDayType weakDayType, DateTime date, bool doTheReading)
        {
            //arrange
            var person = Builder<PersonRegistration>.CreateNew().Build();
            var list = new List<WorkSchedule>() { WorkSchedule.CreateInstance(weakDayType, date, doTheReading) };

            //act
            person.SetWorkSchedules(weakDayType, date, doTheReading);

            //assert
            person.WorkSchedules.Should().HaveCount(1);
            person.WorkSchedules.Should().BeEquivalentTo(list);
        }

        public static List<object[]> Precenses = new List<object[]>
        {
            new object[] { PersonType.Tarefeiro(), true },
            new object[] { PersonType.Assistido(), false },
            new object[] { PersonType.Palestrante(), false },
            new object[] { PersonType.Entrevistador(), false }
        };

        [Theory]
        [MemberData(nameof(Precenses))]
        public void Should_Enable_Laborer_Presence(PersonType personType, bool resultBe)
        {
            //arrange
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { personType }, "nome", 123456789);

            //act
            var result = person.EnabledLaborerPresence();

            //assert
            result.Should().Be(resultBe);
        }

        [Fact]
        public void Should_set_is_excluded()
        {
            //arrange
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            person.SetIsExcluded();

            //assert
            person.IsExcluded.Should().BeTrue();
        }

        [Fact]
        public void Should_laborer_presence_confirmed_is_true()
        {
            //arrage
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.SetPresenceAssignment(DateTime.Now, true);

            //act
            var result = person.LaborerPresenceConfirmed();

            //assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_laborer_presence_confirmed_is_false_with_assignment_is_null()
        {
            //arrage
            var person = Builder<PersonRegistration>.CreateNew().Build();

            //act
            var result = person.LaborerPresenceConfirmed();

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_laborer_presence_confirmed_is_false_with_assignment_date_not_equals()
        {
            //arrage
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.SetPresenceAssignment(new DateTime(2022, 06, 23), true);

            //act
            var result = person.LaborerPresenceConfirmed();

            //assert
            result.Should().BeFalse();
        }
    }
}

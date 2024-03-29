﻿using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command.InsertInterview;
using SL.Person.Registration.Application.Commons.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class InsertInterviewCommandTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), null), null },
            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Builder<InterviewRequest>.CreateNew().Build()), Builder<InterviewRequest>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(InsertInterviewCommand command, InterviewRequest interviewRequest)
        {
            //arrange
            //act
            //asserts
            command.Interview.Should().BeEquivalentTo(interviewRequest);
        }
    }
}

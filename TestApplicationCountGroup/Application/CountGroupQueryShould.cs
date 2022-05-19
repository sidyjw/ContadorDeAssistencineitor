using Application.Contracts.Repositories;
using Application.CountGroup.Queries;
using Domain;
using Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace TestApplicationCountGroup.Application
{
    public class CountGroupQueryShould
    {
        private CountGroup _groupCount;

        public CountGroupQueryShould()
        {
            List<GroupMember> groupMembers = new()
            {
                new() { Name = "Sidiney" }
            };
            var guid = Guid.NewGuid();
            _groupCount = new CountGroup { Guid = guid, GroupMembers = groupMembers };
        }

        [Fact]
        public async void QueryHandler_ValidGuid_ReturnResultSuccess()
        {
            //arrange          
            var mockRepo = new Mock<ICountGroup>();
            mockRepo.Setup(repo => repo.GetAsync(_groupCount.Guid))
                .ReturnsAsync(_groupCount);

            //act
            var queryHandler = new GetCountGroup.Handler(mockRepo.Object);
            var result = await queryHandler.Handle(new GetCountGroup.Query { Guid = _groupCount.Guid }, CancellationToken.None);

            //assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Sidiney", result?.Value?.CountGroup[0].Name);
        }

       [Fact]
        public async void QueryHandler_InvalidGuid_ReturnResultFailed()
        {
            //arrange          
            var mockRepo = new Mock<ICountGroup>();
            mockRepo.Setup(repo => repo.GetAsync(_groupCount.Guid))
                .ReturnsAsync(_groupCount);

            //act
            var queryHandler = new GetCountGroup.Handler(mockRepo.Object);
            var result = await queryHandler.Handle(new GetCountGroup.Query { Guid = Guid.NewGuid() }, CancellationToken.None);

            //assert
            Assert.False(result.IsSuccess);
            Assert.False(string.IsNullOrEmpty(result.Message));
        }
    }
}
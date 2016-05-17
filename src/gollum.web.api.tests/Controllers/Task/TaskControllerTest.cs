using Xunit;
using Moq;
using gollum.web.api.Controllers;
using gollum.web.api.Repositories.Task;
using System;

namespace gollum.web.api.tests.Controllers.Task
{
    public class TaskControllerTest
    {
        private Mock<ITaskRepository> mockedRepo = new Mock<ITaskRepository>();
        private TaskController controller;

        public TaskControllerTest()
        {
            controller = new TaskController(mockedRepo.Object);
        }

        [Fact]
        public void ShouldReturnListOfTasksWhenGETForAll()
        {
            Guid aId = Guid.NewGuid();
            // Arrange
            var expectedResult = MockDataProvider.MockTaskList(15);
            mockedRepo.Setup(t => t.GetAll(aId)).Returns(expectedResult);
            
            // Act
            var actualResponse = controller.GetAll(aId);

            // Assert
            Assert.Equal(expectedResult, actualResponse);
        }

    }
}

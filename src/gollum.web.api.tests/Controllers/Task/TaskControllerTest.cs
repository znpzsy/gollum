using Xunit;
using Moq;
using gollum.web.api.Repositories;
using gollum.web.api.Controllers;
using gollum.web.common.Models.Task;

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
            // Arrange
            var expectedResult = MockDataProvider.MockTaskList(15);
            mockedRepo.Setup(t => t.GetAll()).Returns(expectedResult);
            
            // Act
            var actualResponse = controller.GetAll();

            // Assert
            Assert.Equal(expectedResult, actualResponse);
        }

    }
}

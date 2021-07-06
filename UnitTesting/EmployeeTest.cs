using Moq;
using UnitTest_Mock.Controllers;
using UnitTest_Mock.Model;
using UnitTest_Mock.Services;
using Xunit;

namespace UnitTesting
{
   public class EmployeeTest
    {
        #region Property
        public Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
        #endregion

        [Fact]
        public async void GetEmployeebyId()
        {
            // Arrange
            mock.Setup(p => p.GetEmployeebyId(1)).ReturnsAsync("Koka");
            
            // Act
            var emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(1);

            // Assert
            Assert.Equal("Koka", result);
        }
        [Fact]
        public async void GetEmployeeDetails()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "Koka",
                Position = "Developer"
            };
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);

            var emp = new EmployeeController(mock.Object);
            var result = await emp.GetEmployeeDetails(2);

            Assert.True(employeeDTO.Equals(result));
        }
    }
}

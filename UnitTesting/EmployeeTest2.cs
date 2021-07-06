using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Mock.Model;
using UnitTest_Mock.Repositories;
using Xunit;

namespace UnitTesting
{
    public class EmployeeTest2
    {
        [Fact]
        public async void GetByIdAsync_Returns_Employee()
        {
            // Arrange
            var dbContextMock = new Mock<AppDbContext>();
            var dbSetMock = new Mock<DbSet<Employee>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>())).Returns(new ValueTask<Employee>(Task.FromResult(new Employee())));
            dbContextMock.Setup(s => s.Set<Employee>()).Returns(dbSetMock.Object);

            //Act
            var employeeRepository = new EmployeeRepository(dbContextMock.Object);
            var employee = await employeeRepository.GetByIdAsync(1);

            //Assert  
            Assert.NotNull(employee);
            Assert.IsAssignableFrom<Employee>(employee);
        }

        [Fact]
        public async Task GetByIdAsync_Throws_NotFoundException()
        {
            var dbContextMock = new Mock<AppDbContext>();

            var dbSetMock = new Mock<DbSet<Employee>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>())).Returns(new ValueTask<Employee>(Task.FromResult<Employee>(null)));

            dbContextMock.Setup(s => s.Set<Employee>()).Returns(dbSetMock.Object);
            var employeeRepository = new EmployeeRepository(dbContextMock.Object);

            var employee = await employeeRepository.GetByIdAsync(1);
            Assert.Null(employee);

        }
    }
}

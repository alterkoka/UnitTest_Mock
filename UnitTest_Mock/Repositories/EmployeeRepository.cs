using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTest_Mock.Model;

namespace UnitTest_Mock.Repositories
{
    public class EmployeeRepository
    {
        DbContext dbContext;
        public EmployeeRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Employee> GetByIdAsync(int id)
        {
            return await this.dbContext.Set<Employee>().FindAsync(id);
        }
    }
}

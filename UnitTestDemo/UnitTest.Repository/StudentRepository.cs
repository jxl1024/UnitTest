using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Data;
using UnitTest.IRepository;
using UnitTest.Model;

namespace UnitTest.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// 通过构造函数实现依赖注入
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> Add(Student entity)
        {
            _dbContext.Students.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int?> Delete(Student entity)
        {
            _dbContext.Students.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetList()
        {
            List<Student> list = new List<Student>();

            list = await Task.Run<List<Student>>(() => 
            {
                return _dbContext.Students.ToList();
            });
          
            return list;
        }

        public async Task<int?> Update(Student entity)
        {
            Student student = _dbContext.Students.Find(entity.ID);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Age = entity.Age;
                student.Gender = entity.Gender;
                _dbContext.Entry<Student>(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}

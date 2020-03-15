using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTest.IRepository;
using UnitTest.Model;

namespace UnitTestDemo.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        /// <summary>
        /// 通过构造函数注入
        /// </summary>
        /// <param name="repository"></param>
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return await _repository.GetList();
        }

        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Post([FromBody]Student entity)
        {
            int? result = await _repository.Add(entity);
            if(result==null)
            {
                return false;
            }
            else
            {
                return result > 0 ? true : false;
            }
            
        }
    }
}
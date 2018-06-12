using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMakerFree.Api.ViewModels;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFree.Api.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        public List<QuizViewModel> SampleQuizze { get;  set; }
        public QuizController()
        {
            SampleQuizze = new List<QuizViewModel>();
        }

        #region RESTful conventions methods
        /// <summary>
        /// GET: api/quiz/{}id
        /// Retrieves the Quiz with the given {id}
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        /// <returns>the Quiz with the given {id}</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // create a sample quiz to match the given request
            var v = new QuizViewModel()
            {
                Id = id,
                Title = String.Format("Sample quiz with id {0}", id),
                Description = "Not a real quiz: it's just a sample!",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            // output the result in JSON format
            return new JsonResult(
            v,
            new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
        #endregion

        #region Attribute-based routing methods
        /// <summary>
        /// GET: api/quiz/latest
        /// Retrieves the {num} latest Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>the {num} latest Quizzes</returns>
        // GET: api/values
        [HttpGet("Latest/{num?}")]
        public IActionResult Latest(int num = 10)
        {
            RawData(num);
            var jsonSerialized = new JsonResult(SampleQuizze, new JsonSerializerSettings() { Formatting = Formatting.Indented });
            return jsonSerialized;
        }
        #endregion

        // GET api/values/5
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num)
        {
            RawData(num);
            return new JsonResult(SampleQuizze.OrderByDescending(x => x.Description).ToList(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [HttpGet("Random/{num}")]
        public IActionResult Random(int num=10)
        {
            RawData(num);
            //https://stackoverflow.com/questions/41487665/what-is-guid-newguid-doing-in-linq-to-entities/41487705
            return new JsonResult(SampleQuizze.OrderBy
                (x => Guid.NewGuid()).ToList(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        private void RawData(int num)
        {
            for (int i = 0; i < num; i++)
            {
                SampleQuizze.Add(new QuizViewModel
                {
                    Id = i + 1,
                    Title = String.Format("Sample Quiz {0}", i + 1),
                    Description = ($"{i + 1}: This is a sample quiz"),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

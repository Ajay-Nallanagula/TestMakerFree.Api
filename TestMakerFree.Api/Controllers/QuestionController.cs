using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFree.Api.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFree.Api.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        // GET: api/values
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleQuestions = new List<QuestionViewModel>();
            sampleQuestions = RawData(sampleQuestions,quizId);
            return new JsonResult(sampleQuestions, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        private List<QuestionViewModel> RawData(IList<QuestionViewModel> sampleQuestions,int quizId)
        {
            for (int i = 0; i < 10; i++)
            {
                sampleQuestions.Add(new QuestionViewModel
                {
                    Id = i + 1,
                    QuizId = quizId,
                    Text = "What do you value most in your life?",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now

                });
            }
            return sampleQuestions.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

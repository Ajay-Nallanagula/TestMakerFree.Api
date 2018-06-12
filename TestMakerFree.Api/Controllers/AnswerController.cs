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
    public class AnswerController : Controller
    {
        // GET: api/values
        [HttpGet("All/{questionId}")]
        public IActionResult All(int questionId)
        {
            var answerList = new List<AnswerViewModel>();
            answerList = RawData(answerList, questionId);
            return new JsonResult(answerList, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        private List<AnswerViewModel> RawData(IList<AnswerViewModel> answerList, int questionId)
        {
            for (int i = 0; i < 10; i++)
            {
                answerList.Add(new AnswerViewModel
                {
                    Id = i + 1,
                    QuestionId = questionId,
                    Text = "Friends and family",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            return answerList.ToList();
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

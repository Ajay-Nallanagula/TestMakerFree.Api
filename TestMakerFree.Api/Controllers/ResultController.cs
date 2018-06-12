using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMakerFree.Api.ViewModels;
using Newtonsoft.Json;

namespace TestMakerFree.Api.Controllers
{
    
    [Route("api/Result")]
    public class ResultController : Controller
    {
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var resultList = new List<ResultViewModel>();
            resultList = RawData(resultList, quizId);
            return new JsonResult(resultList, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        private List<ResultViewModel> RawData(List<ResultViewModel> resultList, int quizId)
        {
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ResultViewModel()
                {
                    Id = i + 1,
                    QuizId = quizId,
                    Text = "What do you value most in your life?",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            return resultList.ToList();
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
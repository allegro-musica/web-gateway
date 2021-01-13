using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.API;
using Web.API.Services;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly QuizService _service;

        public TestController(QuizService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task Test()
        {
            await _service.CreateNewQuiz(new QuizCreateRequest()
            {
                Title = "test",
                Quiz = new QuizData()
                {
                    Description = "test",
                    ImageUrl = "test",
                    Title = "test",
                    Questions = { }
                }
            });
        }
    }
}

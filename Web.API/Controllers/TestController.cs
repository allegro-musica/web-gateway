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
        public async Task<IActionResult> Test()
        {
            var quiz = await _service.CreateNewQuiz(new QuizCreateRequest()
            {
                Title = "test",
                Quiz = new QuizData()
                {
                    Description = "test",
                    ImageUrl = "test",
                    Title = "test",
                    Questions =
                    {
                        new QuestionData()
                        {
                            Title = "What's the biggest animal in the world?"
                        },
                        new QuestionData()
                        {
                            Title = "Which country is brie cheese originally from?"
                        }
                    }
                }
            });

            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            return new JsonResult(quiz);
        }
    }
}

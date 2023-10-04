using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyScout.Models;
using SurveyScout.Services;

namespace SurveyScout.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class AnswersController : Controller
{
   private readonly ILogger<AnswersController> _logger;
   private readonly ICosmosDbService _cosmosDbService;
   
   public AnswersController(ILogger<AnswersController> logger, ICosmosDbService cosmosDbService)
   {
      _logger = logger;
      _cosmosDbService = cosmosDbService;
   }
    
   //Create Answers
   [HttpPost("createAnswers", Name = "CreateAnswers")]
   public async Task<ActionResult<AnswersModel>> CreateAnswerAsync(AnswersModel answers)
   {
      return await _cosmosDbService.CreateAnswersAsync(answers);
   }
   
}
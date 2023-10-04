using SurveyScout.Models;

namespace SurveyScout.Services;

public interface ICosmosDbService
{
    Task<AnswersModel> CreateAnswersAsync(AnswersModel answer);

}
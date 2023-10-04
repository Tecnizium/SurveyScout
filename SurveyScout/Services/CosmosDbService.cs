using Microsoft.Azure.Cosmos;
using SurveyScout.Models;

namespace SurveyScout.Services;

public class CosmosDbService : ICosmosDbService
{
    private readonly ILogger<CosmosDbService> _logger;
    private readonly Container _answers;
    
    public CosmosDbService(ILogger<CosmosDbService> logger, IConfiguration config)
    {
        _logger = logger;
        var client = new CosmosClient(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? config["CosmosDb:ConnectionString"]);
        var database = client.GetDatabase(config["CosmosDb:DatabaseName"]);
        _answers = database.GetContainer(config["CosmosDb:AnswersContainerName"]);
    }
    
    //Create Answers
    public async Task<AnswersModel> CreateAnswersAsync(AnswersModel answers)
    {
        var response = await _answers.CreateItemAsync(answers);
        return response.Resource;
    }
}
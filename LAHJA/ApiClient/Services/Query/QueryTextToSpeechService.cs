using Domain.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.Data.UI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text.Json;


namespace LAHJA.ApiClient.Services.Query
{

    public interface IQueryTextToSpeechService
    {
         Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequestTextToSpeech requestData);
    }
    public class QueryTextToSpeechService: IQueryTextToSpeechService
    {


        private readonly IJSRuntime _JSRuntime;

        public QueryTextToSpeechService(IJSRuntime jSRuntime)
        {
            _JSRuntime = jSRuntime;
        }



        public async Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequestTextToSpeech requestData)
        {
            try
            {
                //var requestData = new QueryRequestTextToSpeech { Data = inputText, TagId = "OutputPlayerId" };
                string json = JsonSerializer.Serialize(requestData);
                if (!string.IsNullOrEmpty(json))
                {
                    var response = await _JSRuntime.InvokeAsync<string>("queryModelTextToSpeech",json);
                    if (response != null)
                    {
                        if (response == "222")
                            return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result= response });
                        else
                            return Result<ServiceAIResponse>.Fail("333");
                    }
                }
        
                return Result<ServiceAIResponse>.Fail("Error !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Result<ServiceAIResponse>.Fail(ex.Message);
            }

        }



    }
}

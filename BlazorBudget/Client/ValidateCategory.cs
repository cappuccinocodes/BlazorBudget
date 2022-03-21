using System.Net;
using System.Net.Http.Json;
using BlazorBudget.Shared.Models;

public class ValidateCategory : IValidateCategory
{
    private readonly HttpClient _http;

    public ValidateCategory(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> CheckIfUnique(string category, CancellationToken token)
    {
        var categoryList = await _http.GetFromJsonAsync<List<Category>>("api/Category", token);
        var isUnique = categoryList.Any(x => x.Name == category);

        return isUnique;
    }
}
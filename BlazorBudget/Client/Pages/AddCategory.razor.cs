using System.Net;
using System.Net.Http.Json;
using BlazorBudget.Client.Shared;
using BlazorBudget.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorBudget.Client.Pages
{
    public class AddCategoryModalBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        ILogger<Category> Logger { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }   

        [Parameter]
        public int CategoryId { get; set; }
        protected string Title = "Add";
        protected Category Category = new();

        protected CustomFormValidator customFormValidator;

        protected bool isRegistrationSuccess = false;

        protected override async Task OnParametersSetAsync()
        {
            if (CategoryId != 0)
            {
                Title = "Edit";
                Category = await Http.GetFromJsonAsync<Category>("api/Category/" + CategoryId);
            }
        }
        protected async Task SaveCategory()
        {
            customFormValidator.ClearFormErrors();
            isRegistrationSuccess = false;

            Category.Records = new List<Record>();

            try
            {
                if (Category.CategoryId != 0)
                {
                    var response = await Http.PutAsJsonAsync("api/Category", Category);
                    var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();

                    if (response.StatusCode == HttpStatusCode.BadRequest && errors.Count > 0)
                    {
                        customFormValidator.DisplayFormErrors(errors);
                        throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                    }
                    else
                    {
                        isRegistrationSuccess = true;
                        Logger.LogInformation("The registration is successful");
                    }
                }
                else
                {
                    var response = await Http.PostAsJsonAsync("api/Category", Category);
                    var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();

                    if (response.StatusCode == HttpStatusCode.BadRequest && errors.Count > 0)
                    {
                        customFormValidator.DisplayFormErrors(errors);
                        throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                    }
                    else
                    {
                        isRegistrationSuccess = true;
                        Logger.LogInformation("The registration is successful");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }

            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}

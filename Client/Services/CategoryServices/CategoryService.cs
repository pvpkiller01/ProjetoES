using ESProjeto.Client.Pages;
using ESProjeto.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace ESProjeto.Client.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; }

        public List<CategoryMovie> MoviesReference { get; set; }

        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/category");
            if (result != null)
                Categories = result;

        }
        public async Task GetAllMovies()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CategoryMovie>>("api/categoryMovies");
            if (result != null)
                MoviesReference = result;

        }
        public async Task<Category> GetSingleCategory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Category>($"api/category/{id}/categories");
            if (result != null)
                return result;
            throw new Exception("Competition not found.");
        }
        public async Task<List<CategoryMovie>> GetMoviesFromCategories( int id) 
        {
            var result = await _httpClient.GetFromJsonAsync<List<CategoryMovie>>($"api/category/{id}");
            if (result != null)
                MoviesReference = result;
            return result;

        }
        public async Task VoteOnCategory(int categoryId, int MovieReference)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/category/{MovieReference}/votes", categoryId);
            result.EnsureSuccessStatusCode();
        }
        public async Task UpdateAllVotes(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/category/{category.Id}/CategoryVotes", category);
            result.EnsureSuccessStatusCode();
        }
        public async Task UpdateCategory(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/category/{category.Id}", category);
            result.EnsureSuccessStatusCode();
        }
        public async Task CreateCategory(Category category){
            var result = await _httpClient.PostAsJsonAsync("api/category", category);
            result.EnsureSuccessStatusCode();
        }
        public async Task DeleteCategory(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/category/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Category>>();

            if (response != null)
                Categories = response;
        }
    }
}

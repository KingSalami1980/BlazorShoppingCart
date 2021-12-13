using Shop.DataModels.CustomModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace Shop.Admin.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly HttpClient _httpClient;

        public AdminPanelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseModel> AdminLogin(LoginModel loginModel)
        {
            return await _httpClient.PostJsonAsync<ResponseModel>("api/admin/AdminLogin", loginModel);
        }

        public async Task<CategoryModel> SaveCategory(CategoryModel newCategory)
        {
            return await _httpClient.PostJsonAsync<CategoryModel>("api/admin/SaveCategory", newCategory);
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _httpClient.GetJsonAsync<List<CategoryModel>>("api/admin/GetCategories");
        }

        public async Task<bool> UpdateCategory(CategoryModel categoryToUpdate)
        {
            return await _httpClient.PostJsonAsync<bool>("api/admin/UpdateCategory", categoryToUpdate);
        }

        public async Task<bool> DeleteCategory(CategoryModel categoryToDelete)
        {
            return await _httpClient.PostJsonAsync<bool>("api/admin/DeleteCategory", categoryToDelete);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return await _httpClient.GetJsonAsync<List<ProductModel>>("api/admin/GetProducts");
        }

        public async Task<bool> DeleteProduct(ProductModel productToDelete)
        {
            return await _httpClient.PostJsonAsync<bool>("api/admin/DeleteProduct", productToDelete);
        }
        public async Task<ProductModel> SaveProduct(ProductModel newProduct)
        {
            return await _httpClient.PostJsonAsync<ProductModel>("api/admin/SaveProduct", newProduct);
        }
    }
}
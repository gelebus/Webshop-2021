using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Webshop2021.Logic.ViewModels;

namespace Webshop2021.Logic
{
    public class ApiCalls
    {
        public ApiCalls()
        {
            ApiHelper.init();
        }

        public async Task<AdminProductViewmodel> CreateProduct(ProductViewmodel productvm)
        {
            productvm.Value = productvm.Value.Replace('.', ',');
            AdminProductViewmodel requestvm = new AdminProductViewmodel
            {
                Name = productvm.Name,
                Description = productvm.Description,
                Value = Convert.ToDecimal(productvm.Value)
            };

            HttpResponseMessage response = await ApiHelper.Client.PostAsJsonAsync(
            "products", requestvm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AdminProductViewmodel>();
        }
        public async Task<IEnumerable<AdminProductViewmodel>> GetProducts()
        {
            HttpResponseMessage response = await ApiHelper.Client.GetAsync("Products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<AdminProductViewmodel>>();
        }
        public async Task<AdminProductViewmodel> GetProduct(int id)
        {
            HttpResponseMessage response = await ApiHelper.Client.GetAsync($"Products/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AdminProductViewmodel>();
        }
        public async Task<bool> RemoveProduct(int id)
        {
            HttpResponseMessage response = await ApiHelper.Client.DeleteAsync($"Products/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<bool>();
        }
        public async Task<AdminProductViewmodel> UpdateProduct(AdminProductViewmodel product)
        {
            HttpResponseMessage response = await ApiHelper.Client.PutAsJsonAsync(
                "Products", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AdminProductViewmodel>();
        }
    }
}

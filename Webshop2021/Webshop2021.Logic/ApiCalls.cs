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
        //Products
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

        //Stocks
        public async Task<IEnumerable<StockViewModel>> GetStocks(int productId)
        {
            HttpResponseMessage response = await ApiHelper.Client.GetAsync($"Stocks/{productId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<StockViewModel>>();
        }
        public async Task<IEnumerable<StockViewModel>> UpdateStocks(IEnumerable<StockViewModel> stocks)
        {
            HttpResponseMessage response = await ApiHelper.Client.PutAsJsonAsync(
                "Stocks", stocks);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<StockViewModel>>();
        }
        public async Task<bool> RemoveStock(int id)
        {
            HttpResponseMessage response = await ApiHelper.Client.DeleteAsync($"Stocks/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<bool>();
        }
        public async Task<StockViewModel> CreateStock(StockViewModel stockvm)
        {
            HttpResponseMessage response = await ApiHelper.Client.PostAsJsonAsync(
            "Stocks", stockvm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<StockViewModel>();
        }
    }
}

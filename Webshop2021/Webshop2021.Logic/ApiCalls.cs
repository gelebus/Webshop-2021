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

        public async Task CreateProduct(ProductViewmodel productvm)
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
        }
        public async Task<IEnumerable<AdminProductViewmodel>> GetProducts()
        {
            HttpResponseMessage response = await ApiHelper.Client.GetAsync("Products");
            response.EnsureSuccessStatusCode();
            return (IEnumerable<AdminProductViewmodel>)response.Content;
        }
    }
}

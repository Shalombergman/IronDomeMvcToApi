using System.Net.Http;
using IronDomMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IronDomMvc.Controllers
{
    public class LoginController1 : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public LoginController1()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<ActionResult> UserLogin()
        {

            var result = await this._httpClient.GetStringAsync($"http://localhost:5168/login");
            var login = JsonConvert.DeserializeObject<List<LoginObject>>(result);
            if (result != null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

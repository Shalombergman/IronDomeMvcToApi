using Microsoft.AspNetCore.Mvc;
using IronDomMvc.Models;
using Newtonsoft.Json;

namespace IronDomMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttackController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public AttackController()
        {
            this._httpClient = new HttpClient();
        }
        
        public async Task<ActionResult> GetAllAttacks()
        {

            var result = await this._httpClient.GetStringAsync($"http://localhost:5168/api/Attacks");
            var attacks = JsonConvert.DeserializeObject<List<Attack>>(result);

            if (attacks == null)
            {
                return NotFound();
            }
            return View(attacks);


        }
    }
}

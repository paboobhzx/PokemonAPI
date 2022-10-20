using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using mywebapi.Classes;
using mywebapi.Data;
using Newtonsoft.Json;

namespace mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly DataContext _context;

        public PokemonsController(DataContext context)
        {
            _context = context;
        }

        // GET: https://pokeapi.co/api/v2/pokemon/?offset=30&limit=30
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> Get_pokemons()
        {
            string json = string.Empty;
            int limit = 30;
            string url = $"https://pokeapi.co/api/v2/pokemon/?offset={limit}&limit={limit}";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    BaseResults myDeserializedClass = JsonConvert.DeserializeObject<BaseResults>(json);
                    if(myDeserializedClass != null)
                    {
                        foreach(var result in myDeserializedClass.results)
                        {
                            using (HttpClient insideclient = new HttpClient())
                            {
                                insideclient.BaseAddress = new Uri(result.url);
                                response = await insideclient.GetAsync(result.url);
                                if(response.IsSuccessStatusCode)
                                {
                                    json = await response.Content.ReadAsStringAsync();
                                    //AbilitiesRoot currPokeAbilities = JsonConvert.DeserializeObject<AbilitiesRoot>(json);
                                    Pokemon currPoke = JsonConvert.DeserializeObject<Pokemon>(json);
                                    if(currPoke != null)
                                    {

                                    }

                                }
                            }

                        }
                    }
                }
            }

                return await _context._pokemons.ToListAsync();
        }
      

  

        
    }
}

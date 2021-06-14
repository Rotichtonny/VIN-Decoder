using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace VINDecoder.Controllers
{
    [RoutePrefix("vin")]
    [Authorize]
    public class VinController : ApiController
    {
        #region Decode Vin
        // Decode Vehicle Vin
        // GET: vin/decode
        [HttpGet]
        [AllowAnonymous]
        [Route("decode/{vin}")]
        public async Task<IHttpActionResult> DecodeAsync(string vin)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://vindecoder.p.rapidapi.com/decode_vin?vin=" + vin),
                    Headers =
                    {
                        { "x-rapidapi-key", "5a73cf53bbmsh1a3b0e2221240a5p1bd41bjsn8a5e80a368ec" },
                        { "x-rapidapi-host", "vindecoder.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return Ok(body);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}

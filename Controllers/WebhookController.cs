using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace botchat.Controllers
{
  [Route("/[controller]")]
  [ApiController]
  public class WebhookController : ControllerBase
  {
    public System.Collections.Specialized.NameValueCollection QueryString { get; }
    private string ACCESS_TOKEN = "cafrotosyeuthocon";

    // GET /webhook
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      var verify_token = Request.Query["hub.verify_token"];
      var hub_challenge = Request.Query["hub.challenge"];
      if (verify_token == ACCESS_TOKEN)
      {
        return hub_challenge;
      }
      else return new string[] { "ERROR" };
    }

    // POST api/webhook
    [HttpPost]
    public ActionResult<IEnumerable<string>> Post([FromBody] string value)
    {
      return new string[] { value };
    }
  }
}

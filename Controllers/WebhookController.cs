using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using botchat.Models;

namespace botchat.Controllers
{
  [Route("/[controller]")]
  [ApiController]
  public class WebhookController : ControllerBase
  {
    public System.Collections.Specialized.NameValueCollection QueryString { get; }
    private const string ACCESS_TOKEN = "cafrotosyeuthocon";
    private const string PAGE_ACCESS_TOKEN = "EAAJNZAWQZCfOwBALkmwAbDBih0DJuS3QPWLPwDOSLAEDFj2kIZBTdHvsdb3NdxlxgZBa5FhyFcmDe3mIBTbx5fGexuvbpD2vw8ZBnSCEyKAWwfjtWZAvOdrGLm1KJ7YezXGJbP79Be2MlGgcCGHyQ3rSBbcTZAm9pVch92qvt51EgZDZD";
    // private const string PAGE_ACCESS_TOKEN = "EAAFAvnelb1cBAJUykhYTKtViTBbBjZCRQHeaeU0LlU9bbBZAyC2oytKEdagq1ZAjAwG3eS4TLpST3s0X9fXfZCFnvNjYoij7ANnvCQulHgXYKlHd4LjH7ovGzHb3SVGJ64eUZAIQaAZCEldrwBOLNzYHTZCwJZBVC4QaQJgEDXhaLwZDZD";
    // GET /webhook
    [HttpGet]
    public ActionResult<string> Get()
    {
      var verify_token = Request.Query["hub.verify_token"];
      var hub_challenge = Request.Query["hub.challenge"].ToString();
      if (verify_token == ACCESS_TOKEN)
      {
        return hub_challenge;
      }
      else return "ERROR";
    }

    // POST api/webhook
    [HttpPost]
    public ActionResult<string> Post([FromBody] FacebookEntries body)
    {
      var client = new HttpClient();
      client.BaseAddress = new Uri("https://graph.facebook.com/v2.6/me/messages");
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      var entries = body.entry;
      for (int i = 0; i < entries.Length; i++)
      {
        var messaging = entries[i].messaging;
        for (int j = 0; j < messaging.Length; j++)
        {
          var content = new Dictionary<string, string> {
            {"recipient", "{id:" + messaging[i].sender.id + "}"},
            {"message", "{text: \" "+ messaging[i].message.text + "\"}"}
          };
          HttpResponseMessage response = client.PostAsJsonAsync("?access_token=" + PAGE_ACCESS_TOKEN, content).Result;
        }
      }
      return "Oke";
    }
  }
}

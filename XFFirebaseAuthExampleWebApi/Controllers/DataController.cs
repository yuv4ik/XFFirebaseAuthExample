using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XFFirebaseAuthExampleWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get() => "Protected data";

    }
}

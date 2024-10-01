using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sistem_informasi_produksi_backend.Helper;
using System.Data;
using System.Runtime.Versioning;

namespace sistem_informasi_produksi_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UtilitiesController(IConfiguration configuration) : Controller
    {
        //readonly PolmanAstraLibrary.PolmanAstraLibrary lib = new(PolmanAstraLibrary.PolmanAstraLibrary.Decrypt(configuration.GetConnectionString("DefaultConnection"), "PoliteknikAstra_ConfigurationKey"));
        readonly PolmanAstraLibrary.PolmanAstraLibrary lib = new(configuration.GetConnectionString("DefaultConnection"));
        DataTable dt = new();
        //readonly LDAPAuthentication adAuth = new(configuration);

        [HttpPost]
        [SupportedOSPlatform("windows")]
        public IActionResult Login([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                //bool isAuthenticated = adAuth.IsAuthenticated(EncodeData.HtmlEncodeObject(value)[0], EncodeData.HtmlEncodeObject(value)[1]);
                //if (isAuthenticated)
                //{
                    dt = lib.CallProcedure("sso_getAuthenticationSustainibility", EncodeData.HtmlEncodeObject(value));
                    if (dt.Rows.Count == 0)
                        return Ok(JsonConvert.SerializeObject(new { Status = "LOGIN FAILED" }));
                    return Ok(JsonConvert.SerializeObject(dt));
                //}
                //return Ok(JsonConvert.SerializeObject(new { Status = "LOGIN FAILED" }));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListMenu([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("all_getListMenu", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListProvinsi([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("pro_getListProvinsi", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListKabupaten([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("pro_getListKabupaten", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListKecamatan([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("pro_getListKecamatan", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListKelurahan([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("pro_getListKelurahan", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult GetListKaryawan([FromBody] dynamic data)
        {
            try
            {
                JObject value = JObject.Parse(data.ToString());
                dt = lib.CallProcedure("pro_getListKaryawan", EncodeData.HtmlEncodeObject(value));
                return Ok(JsonConvert.SerializeObject(dt));
            }
            catch { return BadRequest(); }
        }
    }
}

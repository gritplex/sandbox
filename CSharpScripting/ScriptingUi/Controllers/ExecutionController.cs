using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScriptingBase;
using ScriptingUi.Models;

namespace ScriptingUi.Controllers
{
    [Produces("application/json")]
    [Route("api/Execution")]
    public class ExecutionController : Controller
    {
        [HttpPost]
        public async Task<object> ExecuteScriptAsync([FromBody]ScriptModel model)
        {
            var s = new Script();

            var sb = new StringBuilder();
            sb.AppendJoin(' ', model.SourceCode);
            
            return await s.ExecuteAsync(sb.ToString());
        }
    }
}

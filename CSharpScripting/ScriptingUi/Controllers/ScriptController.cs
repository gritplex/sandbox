using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScriptingUi.Helpers;
using ScriptingUi.Models;

namespace ScriptingUi.Controllers
{
    public class ScriptController : Controller
    {
        private ScriptCache _cache;

        public ScriptController(ScriptCache cache)
        {
            _cache = cache;
        }

        public ActionResult Index(Guid id)
        {
            ViewBag.CurrentId = id.ToString();
            return View(_cache.GetById(id));
        }
        
        
        public ActionResult Update(Guid id, [FromBody]ScriptModel model)
        {
            bool error = _cache.Update(id, model); // todo: notify user of error
            return RedirectToAction(nameof(Index), new { id = id });
        }
    }
}

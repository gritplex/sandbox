using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScriptingUi.Helpers;

namespace ScriptingUi.Controllers
{
    public class ScriptCollectionController : Controller
    {
        private ScriptCache _cache;
        public ScriptCollectionController(ScriptCache cache)
        {
            _cache = cache;
        }

        // GET: Script
        public ActionResult Index()
        {
            return View(_cache.Get());
        }

        public ActionResult Add(string name)
        {
            _cache.Add(new Models.ScriptModel()
            {
                Name = name,
                SourceCode = new string[0]
            });

            return RedirectToAction(nameof(Index));
        }
    }
}

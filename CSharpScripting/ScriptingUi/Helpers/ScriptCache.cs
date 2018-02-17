using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ScriptingUi.Models;

namespace ScriptingUi.Helpers
{
    public class ScriptCache
    {
        private ConcurrentDictionary<Guid, ScriptModel> _dictionary;

        public ScriptCache()
        {
            _dictionary = new ConcurrentDictionary<Guid, ScriptModel>();
        }

        public ScriptModel GetById(Guid id)
        {
            if (_dictionary.TryGetValue(id, out ScriptModel model))
                return model;

            return null;
        }

        public bool Update(Guid id, ScriptModel update)
        {
            _dictionary.TryGetValue(id, out ScriptModel comparisonModel);
            if (comparisonModel != default(ScriptModel))
               return  _dictionary.TryUpdate(id, update, comparisonModel);

            return false;
        }

        public Guid? Add(ScriptModel model)
        {
            var guid = Guid.NewGuid();
            if (_dictionary.TryAdd(guid, model))
                return null;

            return guid;
        }        

        public IReadOnlyDictionary<Guid, ScriptModel> Get()
        {
            return new ReadOnlyDictionary<Guid, ScriptModel>(_dictionary);
        }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatClient.Core
{
    class JsonController
    {
        private const string nameJsonFile = "json.json";

        public Json JsonStart()
        {
            //var Json = new Json();
            var Json = File.Exists(nameJsonFile) ? JsonConvert.DeserializeObject<Json>(File.ReadAllText(nameJsonFile)) : new Json();

            string objectSerialized = JsonConvert.SerializeObject(Json);
            File.WriteAllText(nameJsonFile, objectSerialized);
            return Json;
        }

        public void JsonSave(Json json)
        {
            File.WriteAllText(nameJsonFile, JsonConvert.SerializeObject(json));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWhisper
{
    public class Config
    {
        [JsonProperty("binary_path")]
        public string BinaryPath { get; set; }

        [JsonProperty("model_path")]
        public string ModelPath { get; set; }

        [JsonProperty("port")]
        public int ServerPort { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}

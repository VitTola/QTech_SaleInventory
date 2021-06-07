using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Helpers
{
    public class JsonNetSerializer : IRestSerializer
    {
        JsonSerializerSettings _setting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
            Culture = new CultureInfo("en-US")
        };
        public string Serialize(object obj) => JsonConvert.SerializeObject(obj, _setting);

        public string Serialize(BodyParameter bodyParameter) => JsonConvert.SerializeObject(bodyParameter.Value,  _setting);

        public string Serialize(Parameter parameter) => JsonConvert.SerializeObject(parameter.Value,_setting); 

        public T Deserialize<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content,  _setting);
        public T DeserializeObject<T>(string value) => JsonConvert.DeserializeObject<T>(value,  _setting);
        public T DeserializeObject<T>(Stream stream)
        {
            using (var sr = new StreamReader(stream)) 
            using (var reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = JsonSerializer.Create(_setting);
                return serializer.Deserialize<T>(reader);
            }
        }


        public string[] SupportedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }

    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private Newtonsoft.Json.JsonSerializer serializer;

        public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public string ContentType
        {
            get { return "application/json"; } // Probably used for Serialization?
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static NewtonsoftJsonSerializer Default
        {
            get
            {
                return new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    Culture = new CultureInfo("en-US")
                });
            }
        }
    }
}

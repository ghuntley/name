using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Name
{
    public class ListDomains
    {
        public DateTime create_date { get; set; }
        public string domainname { get; set; }

        public DateTime expire_date { get; set; }

        public string tld { get; set; }

        public WhoisPrivacy whois_privacy { get; set; }
    }

    public class ListDomainsJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (ListDomainsResponse);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader); 

            JToken resultToken = jsonObject["result"];
            var result = JsonConvert.DeserializeObject<Result>(resultToken.ToString());

            var domains = new List<ListDomains>();
            List<JToken> domainTokens = jsonObject["domains"].Children().ToList();


            foreach (JProperty domainToken in domainTokens)
            {

                var domain = JsonConvert.DeserializeObject<ListDomains>(domainToken.Value.ToString());
                domain.domainname = domainToken.Name;

                domains.Add(domain);
            }


            return new ListDomainsResponse()
            {
                Result = result,
                domains = domains
            };
        }

        public override
            void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw
                new
                    NotImplementedException();
        }
    }

    [JsonConverter(typeof (ListDomainsJsonConverter))]
    public class ListDomainsResponse : ResponseBase
    {
        public List<ListDomains> domains { get; set; }
    }

    public class WhoisPrivacy
    {
        public bool enabled { get; set; }
        public DateTime expire_date { get; set; }
    }
}
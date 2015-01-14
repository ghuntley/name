using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Name
{
    public class CheckDomainAvailabilityDomains
    {
        public bool avail { get; set; }
        public bool backorder { get; set; }

        public string domainname { get; set; }

        public bool premium { get; set; }

        public decimal? price { get; set; }

        public string tld { get; set; }
    }

    public class CheckDomainAvailabilityJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (CheckDomainAvailabilityDomains);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            JToken resultToken = jsonObject["result"];
            var result = JsonConvert.DeserializeObject<Result>(resultToken.ToString());

            var domains = new List<CheckDomainAvailabilityDomains>();
            List<JToken> domainTokens = jsonObject["domains"].Children().ToList();


            foreach (JProperty domainToken in domainTokens)
            {
                var domain = JsonConvert.DeserializeObject<CheckDomainAvailabilityDomains>(domainToken.Value.ToString());
                domain.domainname = domainToken.Name;

                domains.Add(domain);
            }

            //var suggested = new List<CheckDomainAvailabilityDomains>();
            //List<JToken> suggestedTokens = jsonObject["suggested"].Children().ToList();


            //foreach (JProperty suggestedToken in suggestedTokens)
            //{
            //    var suggestion =
            //        JsonConvert.DeserializeObject<CheckDomainAvailabilityDomains>(suggestedToken.Value.ToString());
            //    suggestion.domainname = suggestedToken.Name;

            //    suggested.Add(suggestion);
            //}


            return new CheckDomainAvailabilityResponse()
            {
                Result = result,
                domains = domains,
                //suggested = suggested
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

    [JsonConverter(typeof (CheckDomainAvailabilityJsonConverter))]
    public class CheckDomainAvailabilityResponse : ResponseBase
    {
        public List<CheckDomainAvailabilityDomains> domains { get; set; }
        public List<CheckDomainAvailabilityDomains> suggested { get; set; }
    }
}
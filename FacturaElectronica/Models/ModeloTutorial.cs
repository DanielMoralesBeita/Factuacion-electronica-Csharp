using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FacturaElectronica.Models
{
    public class ModeloTutorial
    {

        private const string URL = "https://sub.domain.com/objects.json";
        private string urlParameters = "?api_key=123";
        private static String IDP_URI = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect";
        private static String IDP_CLIENT_ID = "api-stag";
        private static String usuario = "cpf-01-1419-0372@stag.comprobanteselectronicos.go.cr";
        private static String password = "%M2n-+!{OCs3]/-Q:Yj%";
        
        public String acessToken;
        public String refreshToken;
        private static String URI2 = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/";

        public bool EstaResultado { get; set; }

        public async void Autenticacion()
        {
            EstaResultado = true;
               //HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(uri);
               //Se crea un cliente Http
               HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(IDP_URI + "/token");
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", usuario),
                        new KeyValuePair<string, string>("password", password),
                         new KeyValuePair<string, string>("client_id", IDP_CLIENT_ID)
                    };
            // FormUrlEncodedContent formurl = new FormUrlEncodedContent(values);
            var result = await client.PostAsync(new Uri(IDP_URI + "/token"), new FormUrlEncodedContent(values));
            var json = JsonConvert.SerializeObject(result);
            String contents = await result.Content.ReadAsStringAsync();
            JObject json2 = JObject.Parse(contents);
            acessToken = json2.GetValue("access_token").ToString();
            refreshToken = json2.GetValue("refresh_token").ToString();
            EstaResultado = false;
            //String acessToken = JObject.Parse(contents)["access_token"];
            //String refreshToken = json2.Value["refresh_token"];
            //string nuevo = json.ToString();
            // De la respuesta procedemos a leer el access y refresh token
            //   String acessToken = json.getString("access_token");
            //  String refreshToken = json.getString("refresh_token");
            //HttpResponseMessage response = await httpClient.PostAsync(urlPath, );
            //    response.EnsureSuccessStatusCode();
            //    var responseString = await response.Content.ReadAsStringAsync();
            //    // Add an Accept header for JSON format.
            //    client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            //    // List data response.
            //    HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Parse the response body.
            //        var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            //        foreach (var d in dataObjects)
            //        {
            //            Console.WriteLine("{0}", d.Name);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //    }

            //    //Make any other calls using HttpClient here.

            //    //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //    client.Dispose();
        }

    }
}
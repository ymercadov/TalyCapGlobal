using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Datos.AgenteServicios
{
   
    public class FabricaPeticiones : IFabricaPeticiones
    {
        private readonly IHttpClientFactory _httpClientFactory;
      
        public FabricaPeticiones(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Realiza peticiones sobre Api's externas
        /// </summary>
        /// <param name="url">Endpoint o Url donde se esncuntra el recurso</param>
        /// <param name="Metodo">Tipo de peticion a realizar
        /// GET 
        /// POST
        /// DELETE
        /// PUT
        /// </param>
        /// <returns>alguna cadena</returns>
        public string RealizarPeticion(string url, string Metodo)
        {

            //string url = @"https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json";
            //string url = @"https://fakerestapi.azurewebsites.net/api/v1/Activities";
            //string Metodo = "GET";

            /*
            var client = this._httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(url);
            string result = await client.GetStringAsync("");

            return result;
            */

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            string json;

            try
            {
                //Meteorologia meteorologia;
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = Metodo;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException we)
                {

                    if (we != null)
                    {
                        response = (HttpWebResponse)we.Response;
                    }
                }

                stream = response.GetResponseStream();
                using (StreamReader _reader = new StreamReader(stream, Encoding.UTF8))
                {
                    json = _reader.ReadToEnd();
                    _reader.Close();
                    stream.Close();
                }

                return json;
            }
            catch (Exception ex)
            {
                return "Error " + ex.ToString();
            }
            finally
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (stream != null) stream.Close();
            }
        }
    }
}

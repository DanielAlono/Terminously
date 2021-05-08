using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class ApiRestService
    {
        #region Metodos GET
        public ObservableCollection<Diccionario> GetBBDDS()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Diccionarios", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Diccionario>>(response.Content);
        }
        public ObservableCollection<Termino> GetTerminos()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Terminos", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Termino>>(response.Content);
        }
        public ObservableCollection<Ficha> GetFichas()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Fichas", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Ficha>>(response.Content);
        }
        public ObservableCollection<Idioma> GetIdiomas()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Idiomas", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Idioma>>(response.Content);
        }
        #endregion
        #region Metodos POST
        public IRestResponse PostBBDD(Diccionario bbdd)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Diccionarios", Method.POST);
            string data = JsonConvert.SerializeObject(bbdd);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Post(request);
            return response;
        }
        public IRestResponse PostTermino(Termino termino)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Terminos", Method.POST);
            string data = JsonConvert.SerializeObject(termino);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse PostFicha(Ficha ficha)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Fichas", Method.POST);
            string data = JsonConvert.SerializeObject(ficha);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse PostIdioma(Idioma idioma)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("Idiomas", Method.POST);
            string data = JsonConvert.SerializeObject(idioma);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        #endregion
        #region Metodos PUT
        public IRestResponse PutBBDD(Diccionario bbdd)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Diccionarios/{bbdd.IdDiccionario}", Method.PUT);
            string data = JsonConvert.SerializeObject(bbdd);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse PutTermino(Termino termino)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Terminos/{termino.IdTermino}", Method.PUT);
            string data = JsonConvert.SerializeObject(termino);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse PutFicha(Ficha ficha)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Fichas/{ficha.IdFicha}", Method.PUT);
            string data = JsonConvert.SerializeObject(ficha);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse PutIdioma(Idioma idioma)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Idiomas/{idioma.IdIdioma}", Method.PUT);
            string data = JsonConvert.SerializeObject(idioma);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        #endregion
        #region Metodos DELETE
        public IRestResponse DeleteBBDD(Diccionario bbdd)
        {
            foreach(Termino termino in GetTerminos())
                if (termino.IdDiccionario.Equals(bbdd.IdDiccionario))
                    DeleteTermino(termino);
            
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Diccionarios/{bbdd.IdDiccionario}", Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse DeleteTermino(Termino termino)
        {
            foreach (Ficha ficha in GetFichas())
                if (ficha.IdTermino.Equals(termino.IdTermino))
                    DeleteFicha(ficha);

            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Terminos/{termino.IdTermino}", Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse DeleteFicha(Ficha ficha)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Fichas/{ficha.IdFicha}", Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse DeleteIdioma(Idioma idioma)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"Idiomas/{idioma.IdIdioma}", Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
        #endregion
    }
}

using Client.Response;
using Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.WebApi
{
    public class DWebApi
    {
        private string baseUrl = "http://localhost:54581";
        //private string token_type;
        //private string access_token;

        public DWebApi()
        {

        }

        //public DWebApi(string token_type, string access_token)
        //{
        //    this.token_type = token_type;
        //    this.access_token = access_token;
        //}

        public T Execute<T>(RestRequest request, out string message) where T : new()
        {
            message = null;
            var client = new RestClient();
            client.BaseUrl = new Uri(baseUrl);
            var response = client.Execute<T>(request);
            if (response.Data == null)
            {
                message = response.ErrorMessage;
            }
            return response.Data;
        }

        public ResponseToken GetToken(string username, string password, out string message)
        {
            var request = new RestRequest("token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("UserName", username);
            request.AddParameter("Password", password);
            var response = Execute<ResponseToken>(request, out message);
            return response;
        }

        //public Order GetOrder(int id, out string message)
        //{
        //    var request = new RestRequest("api/orders", Method.GET);
        //    request.AddHeader("Authorization", UserClient.Client.TokenType + " " + UserClient.Client.AccessToken);
        //    request.AddParameter("Id", id);
        //    var response = Execute<Order>(request, out message);
        //    return response;
        //}

        public OrderInfo GetOrders(OrderInfo order, out string message)
        {
            var request = new RestRequest("api/orders/select", Method.POST);
            request.AddHeader("Authorization", UserClient.Client.TokenType + " " + UserClient.Client.AccessToken);
            request.AddObject(order);
            var response = Execute<OrderInfo>(request, out message);
            return response;
        }

        //public Response Register(string username, string password)
        //{
        //    var request = new RestRequest("api/account/register", Method.POST);
        //    request.AddParameter("UserName", username);
        //    request.AddParameter("Password", password);

        //    return Execute<Response>(request);
        //}

        public Order CreateOder(Order order, out string message)
        {
            var request = new RestRequest("api/orders", Method.PUT);
            request.AddObject(order);
            request.AddHeader("Authorization", UserClient.Client.TokenType + " " + UserClient.Client.AccessToken);
            return Execute<Order>(request, out message);
        }

        public Order DeleteOder(int id, out string message)
        {
            var request = new RestRequest("api/orders", Method.DELETE);
            request.AddParameter("Id", id);
            request.AddHeader("Authorization", UserClient.Client.TokenType + " " + UserClient.Client.AccessToken);
            return Execute<Order>(request, out message);
        }

        public Order UpdateOder(Order order, out string message)
        {
            var request = new RestRequest("api/orders", Method.POST);
            request.AddObject(order);
            request.AddHeader("Authorization", UserClient.Client.TokenType + " " + UserClient.Client.AccessToken);
            return Execute<Order>(request, out message);
        }

        //public ResponseOrder GetOrder(string username, string password)
        //{
        //    var request = new RestRequest("api/orders", Method.GET);
        //    var res = Execute<Response>(request);
        //    if (res.IsSuccess)
        //    {
        //        return res as ResponseOrder;
        //    }
        //    return res.c;
        //}

    }
}

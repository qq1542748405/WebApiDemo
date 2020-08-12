using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var client = new RestClient("http://localhost:54581");
            //var requestPost = new RestRequest("api/account/register", Method.POST);
            //var info = new UserModel { UserName = "601", Password = "111111" };

            //var a = new DWebApi().Register("604", "111111");
            //textBox1.AppendText(a.IsSuccess + ";" + a.Content);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //var client = new RestClient("http://127.0.0.1:7789");
            //var requestPost = new RestRequest("CustomerNumberInfoCreate/Info", Method.POST);
            //UserCustomer info = new UserCustomer
            //{
            //    Username = "admin",
            //    Password = "123456",
            //    CustomerId = 1,
            //};
            //var json = JObject.FromObject(info);
            //requestPost.AddParameter("application/json", json, ParameterType.RequestBody);
            //IRestResponse responsePost = client.Execute(requestPost);
            //var contentPost = responsePost.Content;
            //textBox1.AppendText(contentPost + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var client = new RestClient("http://127.0.0.1:7788");
            //var requestPost = new RestRequest("CustomerInfoCreate/Info", Method.POST);
            //Customer info = new Customer
            //{
            //    CustomerCode = 656,
            //    Account = new Account(),
            //    Address = new Address
            //    {
            //        Country = "CN",
            //        Province = "GuangDong",
            //        City = "ShenZhen",
            //        District = "LongGang",
            //        Address1 = "YuanShan",
            //        Address2 = "HeAo",
            //        Name = "JiangHong",
            //        CompanyName = "TianJi",
            //        Phone = "1234567890",
            //        PostCode = "000000",
            //        Title = "五",
            //        Type = 0,
            //    },
            //};

            //info.CustomerNumbers.Add(new UserCustomer { Username = "admin", Password = "123456" });

            //var json = JObject.FromObject(info);
            //requestPost.AddParameter("application/json", json, ParameterType.RequestBody);
            //IRestResponse responsePost = client.Execute(requestPost);
            //var contentPost = responsePost.Content;
            //textBox1.AppendText(contentPost + Environment.NewLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //token = new DWebApi().GetToken(textBox2.Text, "111111");
            //textBox1.AppendText($"{token}" + Environment.NewLine);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //var client = new RestClient("http://localhost:54581");
            //var requestPost = new RestRequest("token", Method.POST);
            //var info = new { UserName = "admin", Password = "111111" };
            //var json = JObject.FromObject(info);
            //requestPost.AddParameter("grant_type", "password");
            //requestPost.AddParameter("UserName", "admin");
            //requestPost.AddParameter("Password", "111111");
            //IRestResponse responsePost = client.Execute(requestPost);
            //if (responsePost.ErrorException != null)
            //{
            //    MessageBox.Show(responsePost.ErrorMessage);
            //    return;
            //}
            //var res = client.Execute<ResponseToken>(requestPost);
            //ResponseToken response = res.Data;

            //var token = new DWebApi().GetToken(textBox2.Text, "111111");
            //if (token.access_token == null)
            //{
            //    MessageBox.Show(token.error + ":" + token.error_description);
            //    return;
            //}
            //var order = new ResponseOrder()
            //{
            //    CustomerName = "601",
            //    IsShipped = false,
            //    ShipperCity = "SZ"
            //};
            //var orders = new DWebApi(token.token_type, token.access_token).CreateOder(order);

            //var tool = new RestSharp.Deserializers.JsonDeserializer();
            //tool.RootElement = "Content";
            //var a = tool.Deserialize<ResponseToken>(responsePost);
            //string token_type = JObject.Parse(responsePost.Content).GetValue("token_type").ToString();
            //string access_token = JObject.Parse(responsePost.Content).GetValue("access_token").ToString();
            //var requestGet = new RestRequest("api/orders", Method.GET);
            //requestGet.AddHeader("Authorization", token_type + " " + access_token);
            //var res = client.Execute(requestGet);
            //ResponseToken response = res.Data;
            //if (responseGet.ErrorException != null)
            //{
            //    MessageBox.Show(responseGet.ErrorMessage);
            //    return;
            //}
            //textBox1.AppendText(responseGet.Content + Environment.NewLine);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //var model = new Model.Model();
            //Order myEntity = new Order { Id = 2, Name = "Jack" };
            //model.MyEntities.Add(myEntity);
            //var a = model.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //var token = new DWebApi().GetToken(textBox2.Text, "111111");
            //if (token == null)
            //{
            //    return;
            //}
            //if (token.access_token == null)
            //{
            //    MessageBox.Show(token.error + ":" + token.error_description);
            //    return;
            //}
            //var orders = new DWebApi(token.token_type, token.access_token).GetOrders();
            //dataGridView1.DataSource = orders;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //var model = new Model.Model();
            //var order = model.MyEntities.Find(Convert.ToInt32(textBox3.Text));
            //if (order != null)
            //{
            //    model.MyEntities.Remove(order);
            //    model.SaveChanges();
            //}
            //dataGridView1.DataSource = model.MyEntities.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //var model = new Model.Model();
            //var order = model.MyEntities.Find(Convert.ToInt32(textBox3.Text));
            //if (order != null)
            //{
            //    order.Name = textBox2.Text;
            //    model.SaveChanges();
            //}
            //dataGridView1.DataSource = model.MyEntities.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //var token = new DWebApi().GetToken(textBox2.Text, "111111");
            //if (token == null || token.access_token == null)
            //{
            //    return;
            //}
            //if (token.access_token == null)
            //{
            //    MessageBox.Show(token.error + ":" + token.error_description);
            //    return;
            //}

            //var list = new List<ResponseOrder>();
            //var order = new DWebApi("bearer", "SGycGqua3EBeRYf-HO4RXv2EFQ7kkntibpz6hXeNHdFHvN1_26IGY5w8ZUdmwHxRzu_wTB4mjt6NuEEBD-j3RV9cdxFcuvTA2Hh2bipQgsGdxiRoOUWfgHlDTUsUYeMqk0_KxWlLNev55o8JaeKWn16iGjtXFu-rT8pN6qzl68heUpIoFTVoIbRg1yd5l6uaFHtJpGfebs5ik0AY4-dlpzD_lnWETJuoWjnxlEhf1SI").GetOrder(Convert.ToInt32(textBox3.EditValue));
            //if (order == null)
            //{
            //    return;
            //}
            //list.Add(order);
            //dataGridView1.DataSource = list;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class UserModel
    {
        public string UserName;
        public string Password;
        //public string grant_type = "password";
    }


    

    //public class ResponseOrders
    //{
    //    public  Orders { get; set; }
    //}

    public class ResponseOrder
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string ShipperCity { get; set; }

        public bool IsShipped { get; set; }
    }
}

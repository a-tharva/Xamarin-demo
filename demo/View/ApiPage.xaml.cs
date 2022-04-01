using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();
        }

        public async void ApiCall(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var URL = "https://icanhazdadjoke.com/slack";
                string response = client.GetStringAsync(URL).Result;
                JObject jobj = JObject.Parse(response);
                
                //JArray attachments = (JArray)jobj["attachments"];
                //var item = jobj.attachments;
                //Console.WriteLine((string)jobj["attachments"][0]["text"]);
                

                //Console.WriteLine(response);
                //List<joke> responseans = JsonConvert.DeserializeObject<List<joke>>(response);


                ApiAnswer.Children.Clear();
                Label ans = new Label();
                ans.Text = (string)jobj["attachments"][0]["text"];
                ApiAnswer.Children.Add(ans);
                //foreach (var item in responseans)
                //{
                //    Label ans = new Label();
                //    ans.Text = item.text;
                //    ApiAnswer.Children.Add(ans);
                //}
            }
        }

    }

    class joke
    {
        //public List<text> Tables { get; set; }
        public string attachments { get; set; }
        public string text { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void getJokes(object sender, EventArgs args)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://icanhazdadjoke.com/");
                //client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var response = client.GetAsync("todos").Result;
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(response);
                var URL = "https://jsonplaceholder.typicode.com/todos";
                string response = client.GetStringAsync(URL).Result;
                //Console.WriteLine(response);

                List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(response);

                ApiAnswer.Children.Clear();
                foreach (var item in todo)
                {
                    //Console.WriteLine(item.title);
                    Label newans = new Label();
                    newans.Text = item.title;
                    ApiAnswer.Children.Add(newans);
                }
            }
        }
    }

    class Todo
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}

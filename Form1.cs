using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;


namespace ProjRoboTech23
{
    public partial class Form1 : Form
    {
        OptionForm f = new OptionForm();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async Task button1_ClickAsync(object sender, EventArgs e)
        {
            //   label2.Text = "JOke nigga";
            // label2.Refresh();

            // Replace "YOUR_API_KEY" with your actual API key
            string apiUrl = "https://v2.jokeapi.dev/joke/Any?type=single&safe-mode";
            string apiKey = "f44047a381e642dfbc30c0840df72521";
            string url = $"{apiUrl}&apiKey={apiKey}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var joke = JsonConvert.DeserializeObject<Joke>(jsonResponse);

                    if (joke != null && joke.joke != null)
                    {
                        label2.Text = joke.joke;
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve joke. Status code: {response.StatusCode}");
                }
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //   string apiUrl = "https://v2.jokeapi.dev/joke/Any?type=single&safe-mode";
            string apiKey = "f44047a381e642dfbc30c0840df72521";
            // string url = $"{apiUrl}&apiKey={apiKey}";
            string jokes = "";

            
        
                string flags = "";
                if (f.ChkNSFW) flags += "nsfw,";
                if (f.ChkReligious) flags += "religious,";
                if (f.ChkPolitical) flags += "political,";
                if (f.ChkRacist) flags += "racist,";
                if (f.ChkSexist) flags += "sexist,";
                if (f.ChkExplicit) flags += "explicit,";

                // Remove the last comma from the flags string
                if (flags.Length > 0)
                {
                    flags = flags.Remove(flags.Length - 1);
                }


                // Call the joke API with the selected flags
                string apiUrl = $"https://v2.jokeapi.dev/joke/Any?blacklistFlags={flags}";
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response;
                string jsonResponse;
                Joke joke;
                do
                {
                    response = await httpClient.GetAsync(apiUrl);
                    jsonResponse = await response.Content.ReadAsStringAsync();
                    joke = JsonConvert.DeserializeObject<Joke>(jsonResponse);
                }
                while (joke.joke == null);

                // Display the joke in the label
                label5.Text = joke.joke;

                /*
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var joke = JsonConvert.DeserializeObject<Joke>(jsonResponse);

                        if (joke != null && joke.joke != null)
                        {
                            label5.Text = joke.joke;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to retrieve joke. Status code: {response.StatusCode}");
                    }
                }
                */
            }
            

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void options_Click(object sender, EventArgs e)
        {
            OptionForm optionsForm = new OptionForm();
            optionsForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class Joke
    {
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public Flags flags { get; set; }
        public int? id { get; set; }
        public bool error { get; set; }
    }

    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        
}

}


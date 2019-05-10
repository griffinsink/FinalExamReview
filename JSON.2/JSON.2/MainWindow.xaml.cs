using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net.Http;

namespace JSON._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client=new HttpClient())
            {
                var respose = client.GetAsync($"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;

                if (respose.IsSuccessStatusCode)
                {
                    var content = respose.Content.ReadAsStringAsync().Result;
                    var movie = JsonConvert.DeserializeObject<List<IMDB>>(content);

                    foreach(var m in movie)
                    {
                        if (m.num_voted_users >= 350000)
                        {
                            movieVotes.Items.Add(m.movie_title);
                        }
                    }

                    int total = 0;
                    foreach(var m in movie)
                    {
                        if(m.director_name=="Anthony Russo")
                        {
                            total++;
                        }
                    }
                    anthonyRusso
                }
            }
        }
    }
}

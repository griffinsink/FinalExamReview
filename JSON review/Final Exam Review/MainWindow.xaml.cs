using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


namespace Final_Exam_Review
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

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var movies = JsonConvert.DeserializeObject<List<IMDB>>(content);

                    foreach(var m in movies)
                    {
                        if (m.num_voted_users > 350000)
                        {
                            votes.Items.Add(m.movie_title);
                        }
                    }

                    int total = 0;
                    foreach(var m in movies)
                    {
                        if(m.director_name == "Anthony Russo")
                        {
                            total++;
                        }

                    }
                    anthony.Items.Add(total);

                    double score = 0;
                    string name = "";
                    foreach(var m in movies)
                    {
                        if (m.imdb_score > score)
                        {
                            score = m.imdb_score;
                            name = m.movie_title;
                        }
                    }
                    highestMovie.Items.Add(name);

                    
                    foreach(var m in movies)
                    {
                        var gs = m.genres.Split('|');
                        foreach(var g in gs)
                        {
                            g.Trim();

                            if (!genres.Items.Contains(g))
                            {
                                genres.Items.Add(g);
                            }
                        }
                    }

                    int add = 0;
                    foreach(var m in movies)
                    {
                        if(m.actor_1_name == "Robert Downey Jr.")
                        {
                            add++;
                        }
                    }

                    robert.Items.Add(add);


                    
                }

            }
        }
    }
}

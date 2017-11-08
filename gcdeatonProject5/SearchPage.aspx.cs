using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace gcdeatonProject5
{
    public partial class SearchPage : System.Web.UI.Page
    {
        StringBuilder initialURL = new StringBuilder("http://www.omdbapi.com/?s=");
        StringBuilder IDURL = new StringBuilder("http://www.omdbapi.com/?i=");


        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string movie = txtbMovieSearch.Text;
            initialURL.Append(movie);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(initialURL.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            response.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SearchList));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            SearchList searchResults = (SearchList)js.ReadObject(stream);

            foreach(InitialSearch item in searchResults.Search)
            {
                
                Button movieLink = new Button();
                movieLink.CssClass = "movieLink";
                movieLink.ID = item.imdbID;
                movieLink.Text = item.Title;
                movieLink.Click += new EventHandler(MovieLink_Click);
                form1.Controls.Add(movieLink);
                Session[item.imdbID] = item;
            }
        }

        private void MovieLink_Click(object sender, EventArgs e)
        {
           
            Button selectedMovie = (Button)sender;
            IDURL.Append(selectedMovie.ID);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(IDURL.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            response.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Movie));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            Movie movie = (Movie)js.ReadObject(stream);

            Response.Write(movie.Title);
            Response.Write(movie.Released);
            Response.Write(movie.Genre);
            Response.Write(movie.Runtime);
            Response.Write(movie.Plot);
            Response.Write(movie.Metascore);
            //Response.Write(movie.RottenTomatoes);

        }
    }
}
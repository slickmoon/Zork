using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZorkSite
{
    public partial class Highscores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ZorkScoresEntities db = new ZorkScoresEntities()) //get database context
            {
                
                Highscore art = db.Highscores.Where((x) => x.Name == "Nick").FirstOrDefault(); //make an object of the table type and fill it with the results of the where query
               
                DataTable dt = new DataTable();
                var results = from Highscores in dt.AsEnumerable() select Highscores;
                
                Tournament.DataSource = dt;
                Tournament.DataBind();

                Response.Write(art.Score.ToString()); //push data into the page

            }

            using (ZorkScoresEntities db = new ZorkScoresEntities()) //get database context
            {
                var newscore = db.Set<Highscore>(); //make an object to represent the table we are using
                newscore.Add(new Highscore { Name = "Timmy", Score = 99, SubmitDateTime = DateTime.UtcNow }); //add a new row with an new object of the table type with these values

                db.SaveChanges();  //commit data to table
            }

        }
    }
}
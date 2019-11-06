using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZorkSite
{
    public partial class Highscores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ZorkScoresEntities db = new ZorkScoresEntities())
            {
                
                Highscore art = db.Highscores.Where((x) => x.Name == "Nick").FirstOrDefault();

                Response.Write(art.Score.ToString());

            }

            using (ZorkScoresEntities db = new ZorkScoresEntities())
            {
                var newscore = db.Set<Highscore>();
                newscore.Add(new Highscore { Name = "Timmy", Score = 99, SubmitDateTime = DateTime.UtcNow });

                db.SaveChanges();
            }

        }
    }
}
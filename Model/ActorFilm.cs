using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ActorFilm
{
    public long ActorId { get; set; } 
    public int FilmId { get; set; } 

    public Actor Actor { get; set; }
    public Film Film { get; set; }
}

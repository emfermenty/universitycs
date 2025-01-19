using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Film
{
    private int _FilmId;
    public int FilmId
    {
        get { return _FilmId; }
        set { _FilmId = value;}
    }
    private string _Title;
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    private int _GenreId;
    public int GenreId
    {
        get { return _GenreId; }
        set { _GenreId = value; }
    }
    private Genre _Genre;
    public Genre Genre { 
        get { return _Genre; } 
        set { _Genre =  value; }
    }
    private ICollection<Actor> actors { get; set; } = new List<Actor>();
    public ICollection<Actor> Actors { 
        get { return actors; } 
        set { actors = value; }}
}
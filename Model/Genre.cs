using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Genre
{
    private int _GenreId { get; set; }
    public int GenreId { get {  return _GenreId; } 
    set { _GenreId = value; }
    }
    private string _Name { get; set; }
    public string Name { 
        get { return _Name; } 
        set { _Name = value; }
    }
    private ICollection<Film> _films { get; set; } = new List<Film>();
    public ICollection<Film> Films
    {
        get { return _films; }
        set { _films = value; }
    }
}
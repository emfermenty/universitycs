using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Actor
{
    [Key]
    public long Id { get; set; } 

    [Column(TypeName = "character varying(70)")] 
    public string Name { get; set; } 

    [Column(TypeName = "date")] 
    public DateTime BirthDay { get; set; } 

    public ICollection<ActorFilm> ActorFilms { get; set; } = new List<ActorFilm>(); 
    //public Actor(string name, DateTime birthday)
    //{
     //   this.Name = name;
      //  this.BirthDay = birthday;
    //}
}
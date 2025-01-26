using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Film
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string? Description { get; set; } 
    public short Year { get; set; } 
    public TimeSpan? Duration { get; set; } 
    public decimal? CashCollection { get; set; } 
    public float? Grade { get; set; } 
    public bool? eighteenplus {get;set; }
    public short? GenreId { get; set; } 
    public Genre? Genre { get; set; }
    public ICollection<ActorFilm>? ActorFilms { get; set; } = new List<ActorFilm>(); 
}
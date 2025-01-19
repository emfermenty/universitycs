public class Actor
{
    private int _ActorId;
    public int ActorId
    {
        get { return _ActorId; }
        set { _ActorId = value; }
    }
    private string _Name;
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private ICollection<Film> _Films { get; set; } = new List<Film>();
    public ICollection<Film> Films
    {
        get { return _Films; }
        set { _Films = value; }
    }
}
namespace Model 
{ 

public class User
{
    public User(string navn)
    {
        this.Navn = navn;
    }
    public long UserId { get; set; }
    public string? Navn { get; set; }
}

}

public class Admin: Person{
    private string ID;
    
    public Admin(string username, string password, string ID)
    : base(username, password){
        this.ID=ID;
    }

    public string GetID(){
        return this.ID;
    }
}
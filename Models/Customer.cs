public class Customer: Person{
    private string name;
    private string surname;
    
    public Customer(string username, string password, string name, string surname)
    : base(username, password){
        this.name = name;
        this.surname = surname;
    }

    public string GetName(){
        return this.name;
    }

    public string GetSurname(){
        return this.surname;
    }

    
}
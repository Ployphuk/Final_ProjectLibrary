public abstract class Person {
    private string username;
    private string password;

    public Person(string username, string password) {
        this.username = username;
        this.password = password;
    }

    public string GetUsername() {
        return this.username;
    }

    public string GetPassword() {
        return this.password;
    }


}
class CsvUser
{
    private string name;
    private string nickName;
    private string position;

    public CsvUser(string name, string nickName, string position)
    {
        this.name = name;
        this.nickName = nickName;
        this.position = position;
    }

    public string GetPersonInfo()
    {
        return String.Format("{0},{1},{2}", this.name, this.nickName, this.position);
    }

    public static string InputPersonInfo()
    {
        Console.WriteLine("Please input name, nickname and position: ");
        CsvUser csvUser = new CsvUser(
            Console.ReadLine(),
            Console.ReadLine(),
            Console.ReadLine()
        );

        return csvUser.GetPersonInfo();
    }
}
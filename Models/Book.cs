public class Book
{
    private string serialNumber;
    private string BookName;

    public Book(string serialNumber,string BookName)
    {
        this.serialNumber = serialNumber;
        this.BookName = BookName;
    }

    public string GetSerialNumber()
    {
        return this.serialNumber;
    }

    public string GetBookName()
    {
        return this.BookName;
    }
}
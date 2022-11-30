using System;

class BorrowBook: Book{
    string username;
    public BorrowBook(string username, string serialNumber, string BookName)
    :base(serialNumber,BookName){
        this.username = username;
    }

    public string GetUsername() {
        return this.username;
    }
}
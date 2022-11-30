using System;
using System.Collections.Generic;

class PersonList{
    private List<Person> personList;
    private List<BorrowBook> borrowinfo;

    public PersonList(){
        this.personList = new List<Person>();
        this.borrowinfo = new List<BorrowBook>();
    }

    public void AddUser(Person person){
        this.personList.Add(person);
    }

    public void AddBook(BorrowBook borrowBook){
        this.borrowinfo.Add(borrowBook);
    }


    public bool GetRegisterInfo(string username, string password){
        foreach(Person person in personList){
            if(person is Admin admin){
                if(admin.GetUsername().Equals(username)&& admin.GetPassword().Equals(password)){
                    return false;
                }
            } else if (person is Customer customer){
                if(customer.GetUsername().Equals(username)&&customer.GetPassword().Equals(password)){
                    return false;
                }
            }
        }

        return true;
    }

    public bool GetLoginInfo(string username, string password){
        if(personList.Count == 0){
            return false;
        }
        else if(personList.Count>0){
            foreach(Person person in personList){
                if(person is Admin admin){
                if(admin.GetUsername().Equals(username)&& admin.GetPassword().Equals(password)){
                    return true;
                }
            } else if (person is Customer customer){
                if(customer.GetUsername().Equals(username)&&customer.GetPassword().Equals(password)){
                    return true;
                }
            }
            }
        }
        return false;
    }

    public bool CheckStatus(string username, string password){
        foreach(Person person in personList){
                if(person is Admin admin){
                if(admin.GetUsername().Equals(username)&& admin.GetPassword().Equals(password)){
                    return true;
                }
            } else if (person is Customer customer){
                if(customer.GetUsername().Equals(username)&&customer.GetPassword().Equals(password)){
                    return false;
                }
            }
            }
        return CheckStatus(username,password);
    }

    public void FetchUser(){
        int count = 0;
        foreach(Person person in personList){
            count++;
            if(person is Customer customer){
                Console.WriteLine("{0}, Name {1} surname : {2}",count,customer.GetUsername(),customer.GetName());
            }
        }
    }



    






    
    
}
using System;
using System.IO;
using System.Drawing;

enum MenuMain{
    Register = 1,
    Login = 2,
}

enum RegisterMenu{
    Customer = 1,
    Admin = 2,
}

enum CustomerChoice{
    cartoon =1,
    study = 2,
}
enum RentDays{
    seven = 1,
    fiftyfive = 2,
}

class Program{
    private List<Person> personList;
    static PersonList list;
    private const int OutputImageSize = 256;
    private const string OutputImageFilePath = "output.bmp";
    private static Random rnd = new Random();

    public static void Main(){
        LoadPersonList();
        PrintMenu();
    }

    public static void PrintMenu(){
        Console.Clear();
        Console.WriteLine("Welcome ");
        Console.WriteLine("Press 1 : Register");
        Console.WriteLine("Press 2 : Login");

        ChooseMenu();
    }
    public static void ChooseMenu(){
        Console.Write("Enter : ");
        MenuMain main = (MenuMain)(int.Parse(Console.ReadLine()));

        ShowMenuScreen(main);
    }

    public static void ShowMenuScreen(MenuMain main){
        switch(main){
            case MenuMain.Login : PrintLogin();
            break;
            case MenuMain.Register : PrintRegister();
            break;
        }
    }

    static void PrintRegister(){
        Console.Clear();
        Console.WriteLine("Register Menu");
        Console.WriteLine("Press 1 : Customer");
        Console.WriteLine("Press 2 : Admin");

        PrintRegisterMenu();
    }

    static void PrintRegisterMenu(){
        Console.Write("Input : ");
        RegisterMenu regis = (RegisterMenu)(int.Parse(Console.ReadLine()));

        SwitchRegisMenu(regis);
    }

    static void SwitchRegisMenu(RegisterMenu regis){
        switch(regis){
            case RegisterMenu.Customer : CreateCustomerAccout();
            break;
            case RegisterMenu.Admin : CreateAdminAccout();
            break;
        }
    }
    
    ////register
    static void CreateCustomerAccout(){
        Console.Clear();

        string username = GetInputUserName();
        string password = GetInputPassword();
        Customer customer = new Customer(username,password,GetInputName(),GetInputSurname());

        bool account = list.GetRegisterInfo(username,password);
        if(account == true){
            Program.list.AddUser(customer);
            PrintMenu();
        } else if (account == false){
            Console.WriteLine(" Please input again");
            Console.ReadLine();

            CreateCustomerAccout();
        }

    }

    static void CreateAdminAccout(){
        Console.Clear();

        string username = GetInputUserName();
        string password = GetInputPassword();
        Admin admin = new Admin(username,password,GetInputID());

        bool account = list.GetRegisterInfo(username,password);
        if(account == true){
            Program.list.AddUser(admin);
            PrintMenu();
        } else if(account == false){
            Console.Clear();
            Console.WriteLine(" Please input again");
            Console.ReadLine();

            CreateAdminAccout();
        }
        
    }


    //login

    static void PrintLogin(){
        Console.Clear();
        Console.WriteLine("Log in Part");
        Console.Write("Username : ");
        string username = Console.ReadLine();
        Console.Write("Password : ");
        string password = Console.ReadLine();

        if(list.GetLoginInfo(username,password) == true){
            if(list.CheckStatus(username,password)== false){
                CustomerMenu(username,password);
                
            }else if(list.CheckStatus(username,password) == true){
                AdminMenu(username,password);
            }
        }
    }

    //shoppart

     static void CustomerMenu(string username, string password){
        Console.Clear();
        Console.WriteLine("Welcone to our shop");
        Console.WriteLine("Press 1 : for comic book");
        Console.WriteLine("Press 2 : for textbook ");
        Console.Write("Input : ");
        CustomerChoice choice = (CustomerChoice)(int.Parse(Console.ReadLine()));

        CustomerBook(choice);
     }
    
     static void CustomerBook(CustomerChoice choice){
        switch(choice){
            case CustomerChoice.cartoon: 
            ShowComic();
            DateInform();
            break;
            case CustomerChoice.study: 
            ShowTextBook();
            DateInform();
            break;
        }
     }


    //calculateday
    static void DateInform(){
        Console.WriteLine("Choose day to use");
        Console.WriteLine(" Press 1 : 7 days");
        Console.WriteLine(" Press 2 : 15 Days ");
        Console.Write(" Choose : ");
        RentDays days = (RentDays)(int.Parse(Console.ReadLine()));

        PrintDays(days);
    }

    static void PrintDays(RentDays days){
        switch(days){
            case RentDays.seven:
                DateTime todays7 = DateTime.Now;
                Console.WriteLine("| ---------------------------- 7 days ---------------------------");
                Console.WriteLine("|");
                Console.WriteLine("| Book borrowing date : {0}",todays7);
                DateTime Deadline7 = todays7.AddDays(7);
                Console.WriteLine("| Book return date (7 days) : {0}",Deadline7);
                Console.WriteLine("|");
                Console.WriteLine("| --------------- Thank you for using the service. --------------");
                NewMenu();
            break;
            case RentDays.fiftyfive:
                DateTime todays15 = DateTime.Now;
                Console.WriteLine("| ---------------------------- 15 days --------------------------");
                Console.WriteLine("|");
                Console.WriteLine("| Book borrowing date : {0}",todays15);
                DateTime Deadline15 = todays15.AddDays(15);
                Console.WriteLine("| Book return date (15 days) : {0}",Deadline15);
                Console.WriteLine("|");
                Console.WriteLine("| --------------- Thank you for using the service. --------------");
                NewMenu();
            break;
        }
    }

  //adminmenu
    static void AdminMenu(string username, string password){
        Console.WriteLine("---------- Admin Menu ----------");
        Console.WriteLine("1. Read CSV");
        Console.WriteLine("2. Write CSV");
        Console.Write("Please input menu ( 1 / 2 ) : ");

        int menuIndex = int.Parse(Console.ReadLine());
        if(menuIndex == 1)
        {
            UserList();
           
        }
        else if(menuIndex == 2)
        {
            WriteUserList();
        }
        
    }

    //csv
    static void UserList(){
        Console.Clear();
        list.FetchUser();
        NewMenu();
    }

    static void ReadUserInfo(){
        Console.Write("Please input csv file path to read: ");
        string csvFilePath = Console.ReadLine();

        string[] lines = File.ReadAllLines(csvFilePath);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }

        NewMenu();
    }
    static void WriteUserList(){
        Console.Clear();
        Console.WriteLine("BlackList Program");
        Console.Write("Please input csv file path to write: ");
        string csvFilePath = Console.ReadLine();

        Console.WriteLine("Input number of user to add :");
        int num = int.Parse(Console.ReadLine());


        List<string> lines = new List<string>();
        
        lines.Add(CsvUser.InputPersonInfo());
        while(num > 0){
        File.WriteAllLines(csvFilePath, lines);
        }
        NewMenu();
    }



    //GetinPut Part
    static string GetInputUserName(){
        Console.Write("Input username : ");
        return Console.ReadLine();
    }

    static string GetInputPassword(){
        Console.Write("Input Password :");
        return Console.ReadLine();
    }

    static string GetInputName(){
        Console.Write("Input Name :");
        return Console.ReadLine();
    }
    static string GetInputSurname(){
        Console.Write("Input Surname :");
        return Console.ReadLine();
    }

    static string GetInputID(){
        Console.Write("Input ID :");
        return Console.ReadLine();
    }
    

    static void LoadPersonList(){
        Program.list = new PersonList();
    }

    //infomation
    static void NewMenu(){
        string back;
        Console.WriteLine(" Enter to Back to MainMenu ");
        back = Console.ReadLine();
        PrintMenu();
    }

    static void ShowTextBook(){
        Console.WriteLine("---------- Textbook ----------");
        Console.WriteLine("1. T001 Calculus");
        Console.WriteLine("2. T002 Physics");

        int menuIndex = int.Parse(Console.ReadLine());

        if(menuIndex == 1)
        {
            DateInform();
        }
        else if(menuIndex == 2)
        {
            DateInform();
        }
    }

    static void ShowComic(){
        Console.WriteLine("---------- Comic book ----------");
        Console.WriteLine("1. Goodnight Punpun");
        Console.WriteLine("2. SPY x Family");

         Console.Write("Please input menu ( 1 / 2 ) : ");
        int menuIndex = int.Parse(Console.ReadLine());

        if(menuIndex == 1)
        {
            GNPunpun();
        }
        else if(menuIndex == 2)
        {
            SPYxFam();
        }
        
    }

    static void GNPunpun()
    {
        Console.Clear();
        Console.WriteLine("---------- Goodnight Punpun ----------");
        Console.WriteLine("1. C001 Goodnight Punpun vol.1");
        Console.WriteLine("2. C002 Goodnight Punpun vol.2");
        Console.WriteLine("3. C003 Goodnight Punpun vol.3");
        Console.Write("Please input menu ( 1 / 2 / 3 ) : ");
        int menuIndex = int.Parse(Console.ReadLine());

        if(menuIndex == 1 || menuIndex == 2 || menuIndex == 3)
        {
            DateInform();
        }
    }

     static void SPYxFam()
    {
        Console.Clear();
        Console.WriteLine("---------- SPY x Family ----------");
        Console.WriteLine("1. C011 SPY x Family vol.1");
        Console.WriteLine("2. C012 SPY x Family vol.2");
        Console.WriteLine("3. C013 SPY x Family vol.3");
        Console.WriteLine("4. C014 SPY x Family vol.4");
        Console.WriteLine("5. C015 SPY x Family vol.5");
        Console.WriteLine("6. C016 SPY x Family vol.6");
        Console.WriteLine("7. C017 SPY x Family vol.7");
        Console.WriteLine("8. C018 SPY x Family vol.8");
        Console.WriteLine("9. C019 SPY x Family vol.9");
        Console.Write("Please input menu ( 1 - 9 ) : ");
        int menuIndex = int.Parse(Console.ReadLine());

        if(menuIndex == 1 || menuIndex == 2 || menuIndex == 3 
        || menuIndex == 4 || menuIndex == 5 || menuIndex == 6 
        || menuIndex == 7 || menuIndex == 8 || menuIndex == 9)
        {
            DateInform();
        }
    }



    
    
}
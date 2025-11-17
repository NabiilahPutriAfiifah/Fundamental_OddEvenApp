using System;

namespace BasicProgramming;

// PascalCase < Naming Convention -> C#
// CamelCase
// LowerCase
// UpperCase
// snakecase
class Program
{
    static string Fullname(string firstname, string lastname)
    {
        var name = firstname + " " + lastname;
        return name;
    }

    static void Age()
    {
        // return 21;
        Console.WriteLine("20");
    }
    static void Main(string[] args)
    {
        Employee<string> nabila = new Employee<string>("10001");
        Employee<int> putri = new Employee<int>(10002);

        nabila.FullName = "Nabiilah Putri Afiifah";
        nabila.Salary = 86.000f;
        nabila.Job = "orang kaya";

        nabila.Introduction();

        putri.FullName = "Putri Cantika";
        putri.Salary = 86.000f;
        putri.Job = "orang cantik";

        putri.Introduction();



        var joko = new Manager<int>(10003);
        joko.FullName = "Joko Susilo";
        joko.Salary = 8000000f;
        joko.Introduction();
        joko.Allowance = 2000000;

        
        var Moana = new Manager<string>("10003");
        Moana.FullName = "Moana Sisunto";
        Moana.Salary = 8000000f;
        Moana.Introduction();
        Moana.Allowance = 2000000;


        var a8 = new Audi();
        a8.IsManual = false;
        a8.MaxGear = 0;
        a8.TopSpeed = 200;

        a8.OpenDoor();
        a8.OpenWindow();
        a8.Move();
        a8.Break();

        // Console.WriteLine("=============================");
        var crv = new Honda();
        crv.IsManual = true;
        crv.MaxGear = 0;
        crv.TopSpeed = 500;

        Console.WriteLine("=============================");
        Console.WriteLine("          Honda CRV          ");
        Console.WriteLine("=============================");
        crv.OpenDoor();
        crv.OpenWindow();
        crv.Move();
        crv.Break();

        Console.WriteLine("=============================");

        // Interface (abstraction)
        IMachine icrv = new Honda();
        System.Console.WriteLine();
        icrv.Break();


        var age = 18;
        // var name = "Nabiilah Putri Afiifah";

        age = 21;

        Console.WriteLine("Name: " + Fullname("Nabiilah", "Afiifah"));
        Console.WriteLine("Age: ");

        if (age > 30)
        {
            Console.WriteLine("Tua");
        }
        else if (age < 10)
        {
            Console.WriteLine("Kemudaan");
        }
        else
        {
            Console.WriteLine("Muda");
        }


        switch (age)
        {
            case 20:
                break;
            case 30:
                break;
            default:
                break;
        }

        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("================");

        List<int> numbers = new List<int>() { 1, 2, 3 };
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);

        numbers.Remove(4); // angka 4 / angka yang sesuai
        numbers.RemoveAt(4); //index nya ke 4

        foreach(var i in numbers) {
            Console.WriteLine(i);
        }

        List<Employee<string>> employees = new List<Employee<string>>() { };
        // employees.Add(0, "Addinda", 0965f, "asabsba");
        employees.Add (new Employee<string>("10004")
        {
          FullName = "Addinda",
          Salary = 98,
          Job = "Fullstack"
        });

         employees.Add (new Employee<string>("10005")
        {
          FullName = "Imam",
          Salary = 87,
          Job = "Fullstack"
        });


        foreach (var i in employees)
        {
            i.Introduction();
        }
    }
}
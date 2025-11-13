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
        var age = 18;
        // var name = "Nabiilah Putri Afiifah";

        age = 21;
        
        Console.WriteLine("Name: " + Fullname("Nabiilah", "Afiifah"));
        Console.WriteLine("Age: ");

        if(age > 30){
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
            if ( i % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
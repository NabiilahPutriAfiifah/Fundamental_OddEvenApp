using System.Diagnostics;

namespace OddEventApp;

class Program
{
    /*
     * Menampilkan Menu
     */
    static void Menu()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("         MENU GANJIL GENAP         ");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil/Genap Dengan Limit");
        Console.WriteLine("3. Exit");
        Console.WriteLine("----------------------------------");

    }

    /*
     * ex: PrintEvenOdd(5, "Genap"') ;
     * output 2, 4
     * x: PrintEvenOdd(5, "Ganjil");
     * output 1, 3, 5
     * @PARAM Limit: Batas akhir. minimal 1, tidak boleh O atau negatif.
     * @PARAM choice: Pilihan, hanya boleh "Even" atau "Odd". Selain itu invalid
     */

    static bool IsNotBelowThanOne(int limit)
    {
        return limit < 1;
    }

    static bool IsChoiceNotEvenOrOdd(string choice)
    {
        return choice != "Genap" && choice != "Ganjil";
    }


    static void PrintEvenOdd(int limit, string choice)
    {
        if (IsNotBelowThanOne(limit))
        {
            Console.WriteLine("Input Limit Tidak Valid");
            Console.WriteLine("===================================");
        }

        if (IsChoiceNotEvenOrOdd(choice))
        {
            Console.WriteLine("Input Pilihan Tidak Valid");
            Console.WriteLine("===================================");
            return;
        }



        int modularResult = 1;
        if (choice == "Genap")
        {
            modularResult = 0;
        }

        Console.Write($"Print Bilangan 1 - {limit}: ");
        for (int i = 1; i <= limit; i++)
        {
            if (i % 2 != modularResult)
            {
                continue;
            }

            if (i == limit || i == limit - 1)
            {
                Console.Write(i);
            }
            else
            {
                Console.Write(i + ",");
            }
        }

        Console.WriteLine();
        Console.WriteLine("===================================");
    }



    /*
     * ex: EvenOddCheck(5);
     * output "Even"
     * @PARAM input: Angka yang akan dicek. minimal 1, tidak boleh O atau negatif.
     * @RETURN "Genap" jika input genap, "Ganjil". jika input ganjil, selain itu Invalid Input!! jika input tidak sesuai pada @PARAM input
     */
    static string CheckEvenOrOdd(int input)
    {
        if (input < 1)
        {
            return "Input Pilihan Tidak Valid";
        }
        else if (input % 2 == 1)
        {
            return "Ganjil";
        }
        else if (input % 2 == 0)
        {
            return "Genap";
        }
        return "invalid";

    }

    static void Main()
    {
        int pilihan;
        int angka;
        int limit;
        string choice;

        while (true)
        {
            Menu();
            Console.WriteLine("Pilihan : ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (pilihan)
                {
                    case 1:
                        Console.Write("Masukkan angka: ");
                        angka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(CheckEvenOrOdd(angka));

                        break;
                    case 2:
                        Console.Write("Pilih Ganjil/Genap: ");
                        choice = Console.ReadLine() ?? "";
                        Console.Write("Masukkan limit: ");
                        limit = Convert.ToInt32(Console.ReadLine());
                        PrintEvenOdd(limit, choice);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("INVALID!!");
            }
        }
    }
}

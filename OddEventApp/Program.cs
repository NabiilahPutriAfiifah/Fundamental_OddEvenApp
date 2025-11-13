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
    static void PrintEvenOdd(int limit, string choice)
    {
        if (limit >= 1) {
            if (choice == "Ganjil")
            {
                Console.Write($"Pilih Ganjil/Genap 1 - {limit}: ");
                for (int i = 1; i <= limit; i++)
                {
                    if (i % 2 == 1)
                    {
                        if (i == limit || i == limit - i)
                        {
                            Console.Write(i);
                        }
                        else
                        {
                            Console.Write(i + ",");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("===================================");
            }
            else if (choice == "Genap")
            {
                Console.Write($"Pilih Ganjil/Genap 1 - {limit} : ");
                for (int i = 1; i <= limit; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (i == limit || i == limit - i)
                        {
                            Console.Write(i);
                        }
                        else
                        {
                            Console.Write(i + ",");
                        }
                    }

                }
                Console.WriteLine();
                Console.WriteLine("===================================");
            }
            else
            {
                Console.WriteLine("Input Pilihan Tidak Valid");
                Console.WriteLine("===================================");
            }

        }
        else 
        {
            Console.WriteLine("Input Limit Tidak Valid");
            Console.WriteLine("===================================");
        }
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

    static void Main(string[] args)
    {
        int pilihan;
        int angka;
        int limit;
        string choice;

        do
        {
            Menu();
            Console.WriteLine("Pilihan : ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    try
                    {
                        Console.Write("Masukkan angka: ");
                        angka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(CheckEvenOrOdd(angka));
                    }
                    catch (FormatException) {
                        Console.WriteLine("INVALID!!");
                    }
                    break;
                case 2:
                    try {
                        Console.Write("Pilih Ganjil/Genap: ");
                        choice = Console.ReadLine();
                        Console.Write("Masukkan limit: ");
                        limit = Convert.ToInt32(Console.ReadLine());
                        PrintEvenOdd(limit, choice);
                    }
                    catch 
                        (FormatException) {
                        Console.WriteLine("INVALID!!");
                    }
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }

        } while (pilihan != 3);


    }
}

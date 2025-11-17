/*
 * BAGIAN 4: Program
 * TUJUAN: UI (User Interface) Layer. Hanya bertanggung jawab untuk:
 * 1. Menampilkan UI (via DrawUI).
 * 2. Menerima input user.
 * 3. Memanggil VendingMachine (engine/core).
 * 4. Menangani (catch) semua exception dari VendingMachine.
 */
using VendingMachineApp;

class Program
{
    /*
     * @METHOD Main(string[] args)
     * @DESCRIPTION Titik awal program. Berisi "Game Loop" utama (while true).
     */
    static void Main(string[] args)
    {
        // TODO: Inisialisasi VendingMachine disini
        VendingMachine vm = new VendingMachine();

        string statusMessage = ""; // Untuk menyimpan pesan error/sukses

        while (true)
        {
            // TODO: Panggil DrawUI(vm, statusMessage);
            DrawUI(vm, statusMessage);

            statusMessage = ""; // Reset pesan setiap loop

            Console.Write("ENTER COMMAND: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1].ToUpper() : "";

            /*
             * BAGIAN INI: Logika Pemrosesan Perintah & Error Handling
             */

            /*
             * TODO: Implementasi Logika Transaksi (Try-Catch & Switch)
             *
             * 1. Mulai Blok 'try':
             * Bungkus seluruh logika switch-case di bawah ini ke dalam blok 'try'.
             * Ini wajib agar kita bisa menangkap error dari VendingMachine.
             *
             * 2. Buat Switch Statement (berdasarkan variabel 'command'):
             *
             * CASE "insert":
             * - Logika: User ingin memasukkan uang.
             * - Langkah:
             * a. Parsing string 'argument' menjadi tipe decimal (gunakan decimal.Parse).
             * b. Panggil method untuk menambahkan uang di vending machine
             *
             * CASE "select":
             * - Logika: User ingin membeli item.
             * - Langkah:
             * a. Panggil method untuk membeli item di vending machine.
             * b. Tampilkan pesan sukses/saldo sisa, lalu 'Console.ReadLine()' untuk jeda.
             *
             * CASE "refund":
             * - Logika: User meminta uang kembali.
             * - Langkah:
             * a. Panggil method refund di vending machine
             * b. Tampilkan jumlah uang yang dikembalikan ke user.
             * c. Beri jeda (Console.ReadLine).
             *
             * CASE "quit":
             * - Logika: Keluar program.
             * - Langkah: Panggil 'return;' (ini akan menghentikan method Main).
             *
             * DEFAULT:
             * - Logika: User mengetik perintah aneh.
             * - Langkah: Set variabel 'statusMessage' = "Perintah tidak dikenal".
             *
             * 3. Buat Blok 'catch' (Multiple Catch):
             * Setelah blok 'try' selesai, buatlah serangkaian blok 'catch' untuk menangkap exception.
             * Di dalam setiap catch, set variabel 'statusMessage' dengan pesan error (ex.Message).
             *
             * - catch (InsufficientFundsException ex): Untuk error uang kurang.
             * - catch (OutOfStockException ex): Untuk error stok habis.
             * - catch (KeyNotFoundException ex): Untuk error kode item salah (misal pilih "Z9").
             * - catch (FormatException ex): Untuk error parsing angka (misal insert "abc").
             * - catch (Exception ex): "Catch-all" untuk error sistem yang tidak terduga.
             */

            try
            {
                switch (command)
                {
                    case "insert":
                        decimal amount = decimal.Parse(argument);
                        vm.InsertMoney(amount);
                        statusMessage = $"Uang berhasil dimasukkan {amount:0.00}";
                        break;

                    case "select":
                        decimal balanceAfter = vm.PurchaseItem(argument);
                        statusMessage = $"Berhasil membeli {argument}. Sisa saldo: ${balanceAfter : 0.00}";

                        Console.WriteLine("\nTekan ENTER untuk lanjut...");
                        Console.ReadLine();
                        break;

                    case "refund":
                       decimal refunded = vm.Refund();
                        statusMessage = $"Uang dikembalikan: ${refunded:0.00}";

                        Console.WriteLine("\nTekan ENTER untuk lanjut...");
                        Console.ReadLine();
                        break;

                    case "quit":
                        return;

                    default:
                        statusMessage = "ERROR: Perintah tidak dikenal.";
                        break;
                }
            }
            catch (InsufficientFundsException ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
            catch (OutOfStockException ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
            catch (KeyNotFoundException ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
            catch (FormatException ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
            catch (Exception ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
        }
    }

    /*
     * @METHOD DrawUI(VendingMachine vm, string message)
     * @DESCRIPTION Menggambar seluruh "layar" UI di konsol.
     * @PARAM vm: Objek VendingMachine untuk mengambil inventory dan saldo.
     * @PARAM message: Pesan error atau status untuk ditampilkan di atas.
     */
    static void DrawUI(VendingMachine vm, string message)
    {
        Console.Clear();
        Console.WriteLine("=====================================================");
        Console.WriteLine("===          THE OOP VENDING MACHINE              ===");
        Console.WriteLine("=====================================================");
        Console.WriteLine("");

        // Print Status Message (Red if error)
        if (!string.IsNullOrEmpty(message))
        {
            if (message.Contains("ERROR")) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {message}");
            Console.ResetColor();
            Console.WriteLine("");
        }

        // Print Inventory
        foreach (var entry in vm.GetInventory())
        {
            string code = entry.Key;
            Item item = entry.Value;

            // Formatting: {0,-5} means align left 5 spaces
            string stockDisplay = item.Quantity > 0 ? $"[Qty: {item.Quantity}]" : "[SOLD OUT]";

            // Visual cue: Gray out the sold out items
            if (item.Quantity == 0) Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine($"  [{code}] {item.Name,-12} (${item.Price:0.00}) {stockDisplay}");

            Console.ResetColor();
        }

        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"  CURRENT BALANCE: ${vm.CurrentBalance:0.00}");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("  COMMANDS:");
        Console.WriteLine("    > insert [amount]  (e.g., 'insert 1.50')");
        Console.WriteLine("    > select [code]    (e.g., 'select A1')");
        Console.WriteLine("    > refund           (Get your money back)");
        Console.WriteLine("    > quit             (Exit the program)");
        Console.WriteLine("");
    }
}
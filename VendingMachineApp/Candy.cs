
/*
 * BAGIAN 2.1: Implementasi konkret dari 'Item'.
 * TUJUAN: Inherit 'Item' dan menyediakan implementasi 'override' untuk metode 'Dispense()'.
 */

/*
 * TODO: Buat Class 'Drink', 'Chip', dan 'Candy'
 *
 * Ulangi langkah-langkah berikut untuk membuat TIGA class terpisah (Drink, Chip, dan Candy):
 *
 * 1. Definisi Class:
 * - Buat class public (misalnya 'public class Chip').
 * - @INHERIT: Class ini HARUS inherit dari class 'Item'.
 *
 * 2. Buat Constructor:
 * - @ACCESS: public.
 * - @PARAMS: Menerima (string name, decimal price, int quantity).
 * - @LOGIC: Panggil constructor parent/base menggunakan syntax 'base'.
 * Body constructor biarkan kosong saja.
 *
 * 3. Override Method 'Dispense':
 * - @ACCESS: public override void.
 * - @LOGIC: Gunakan 'Console.WriteLine' untuk menampilkan suara/pesan unik item tersebut.
 * - Contoh Chip: "*Rattle*... *Crunch*..."
 * - Contoh Candy: "*Thud*... (Sweet!)"
 * - Contoh Drink: "*Glug glug*... *Fizz*"
 */
// ===============================================================================================


namespace VendingMachineApp;

public class Candy : Item
{
    public Candy(string name, decimal price, int quantity) : base(name, price, quantity)
    {
        
    }

    public override void Dispense()
    {
        Console.WriteLine("*Thud*... (Sweet!)");
    }

}

/*
 * BAGIAN 2: 'Item' (abstract)
 * TUJUAN: Blueprint untuk semua item yang bisa dijual.
 * Kelas ini tidak boleh di-instantiate langsung (Abstract).
 * Kelas lain (Drink, Chip, Candy) HARUS mewarisi (inherit) dari sini.
 */

/*
 * TODO: Buat Abstract Class 'Item'
 *
 * 1. Buat class public abstract bernama 'Item'.
 *
 * 2. Definisikan Properties berikut di dalam class:
 * - Property 'Name': Tipe string. Getter public, Setter protected.
 * - Property 'Price': Tipe decimal. Getter public, Setter protected.
 * - Property 'Quantity': Tipe int. Getter public, Setter public.
 *
 * 3. Buat Constructor Protected:
 * - @ACCESS: protected (karena class ini abstract, hanya child yang boleh memanggilnya).
 * - @PARAM: string name, decimal price, int quantity.
 * - @LOGIC: Tetapkan nilai parameter ke properti yang sesuai (this.Name = name, dst).
 *
 * 4. Buat Abstract Method 'Dispense':
 * - @ACCESS: public abstract.
 * - @RETURN: void.
 * - @LOGIC: Method ini TIDAK memiliki body (gunakan tanda titik koma ';').
 * Ini memaksa kelas turunan untuk mendefinisikan cara 'Dispense' mereka sendiri.
 */


namespace VendingMachineApp;

public abstract class Item
{
    public string Name { get; protected set; }
    public decimal Price { get; protected set; }
    public int Quantity { get; set;}

    protected Item(string name, decimal price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }

    public abstract void Dispense();
}

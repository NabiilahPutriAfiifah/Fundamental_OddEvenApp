/*
 * BAGIAN 3: VendingMachine
 * TUJUAN: Kelas inti (engine/core) yang menampung semua logika bisnis.
 * PRINSIP: Encapsulation. State internal (_inventory, _currentBalance) HARUS 'private'.
 */

/*
 * TODO: Buat Class 'VendingMachine'
 *
 * 1. Buat class public bernama 'VendingMachine'.
 *
 * 2. Definisikan Fields yang hanya bisa diakses internal:
 * - Field '_inventory': Private. Tipe 'Dictionary<string, Item>'.
 * - Field '_currentBalance': Private. Tipe 'decimal'.
 *
 * 3. Definisikan Public Property:
 * - Property 'CurrentBalance': Public, Tipe 'decimal'.
 * - Hanya boleh memiliki 'get' (read-only) yang mengembalikan nilai '_currentBalance'.
 *
 * 4. Buat Constructor:
 * - @ACCESS: public.
 * - @LOGIC:
 * a. Inisialisasi memori untuk '_inventory' (new Dictionary...).
 * b. Panggil method private 'InitializeInventory()'.
 *
 * 5. Buat Method Helper 'InitializeInventory':
 * - @ACCESS: private void.
 * - @LOGIC: Isi '_inventory' dengan data dummy.
 * Gunakan method '.Add("Kode", new ObjectItem(...))'.
 * Contoh: _inventory.Add("A1", new Drink("Cola", 1.50m, 5));
 * PENTING: Buat setidaknya satu item dengan quantity 0 untuk mengetes error 'OutOfStock'.
 * Masukkan data berikut persis seperti ini:
 * 5.1. Kategori Minuman (Drink):
 * - Kode "A1" -> Nama: "Cola", Harga: 1.50, Stok: 5
 * - Kode "A2" -> Nama: "Water", Harga: 1.00, Stok: 8
 * 5.2. Kategori Keripik (Chip):
 * - Kode "B1" -> Nama: "Chips", Harga: 1.25, Stok: 3
 * - Kode "B2" -> Nama: "Pretzels", Harga: 1.25, Stok: 4
 * 5.3. Kategori Permen (Candy):
 * - Kode "C1" -> Nama: "Candy Bar", Harga: 0.75, Stok: 0
 * - Kode "C2" -> Nama: "Gum", Harga: 0.50, Stok: 10
 *
 * 6. Buat Method 'GetInventory':
 * - @ACCESS: public Dictionary<string, Item>.
 * - @RETURN: Mengembalikan field '_inventory'.
 *
 * 7. Buat Method 'InsertMoney':
 * - @ACCESS: public void.
 * - @PARAM: decimal amount.
 * - @LOGIC:
 * a. Validasi: Jika 'amount' <= 0, lempar 'ArgumentException' dengan pesan error.
 * b. Jika valid, tambahkan 'amount' ke '_currentBalance'.
 *
 * 8. Buat Method 'Refund':
 * - @ACCESS: public decimal.
 * - @LOGIC:
 * a. Simpan nilai '_currentBalance' ke variabel sementara.
 * b. Ubah '_currentBalance' menjadi 0.
 * c. Return variabel sementara tadi (uang kembalian).
 *
 * 9. Buat Method UTAMA 'PurchaseItem':
 * - @ACCESS: public decimal.
 * - @PARAM: string selectionCode.
 * - @RETURN: decimal (sisa saldo setelah pembelian).
 * - @LOGIC (Langkah-langkah PENTING):
 * 9.1. Cek Kode: Apakah '_inventory' memiliki key 'selectionCode'? Jika TIDAK: Lempar 'KeyNotFoundException'.
 * 9.2. Ambil Item: Ambil item dari dictionary (misal: 'var item = _inventory[selectionCode]').
 * 9.3. Cek Stok: Apakah 'item.Quantity' <= 0? Jika YA: Lempar 'OutOfStockException' (Exception kustom yang Anda buat).
 * 9.4. Cek Uang: Apakah '_currentBalance' < 'item.Price'? Jika YA: Lempar 'InsufficientFundsException' (Exception kustom yang Anda buat).
 * 9.5. PROSES TRANSAKSI (Jika semua lolos):
 * - Kurangi '_currentBalance' dengan harga item.
 * - Kurangi 'item.Quantity' sebanyak 1.
 * - Tambah code berikut Console.WriteLine($"\n  [Dispensing]: {SelectedItem.Name}");
 * - Panggil 'item.Dispense()' (Disinilah Polymorphism terjadi!).
 * 9.6. Return '_currentBalance' (sisa uang).
 */
namespace VendingMachineApp;

public class VendingMachine
{
    private Dictionary<string, Item> _inventory;
    private decimal _currentBalance;

    public decimal CurrentBalance
    {
        get { return _currentBalance; }
    }

    public VendingMachine()
    {
        _inventory = new Dictionary<string, Item>();
        InitializeInventory();
    }

    private void InitializeInventory()
    {
        _inventory.Add("A1", new Drink("Cola",      1.50m, 5));
        _inventory.Add("A2", new Drink("Water",     1.00m, 8));
        _inventory.Add("B1", new Chip("Chips",      1.25m, 3));
        _inventory.Add("B2", new Chip("Pretzels",   1.25m, 4));
        _inventory.Add("C1", new Candy("Candy Bar", 0.75m, 0));
        _inventory.Add("C2", new Candy("Gum",       0.50m, 10));
    }

    public Dictionary<string, Item> GetInventory()
    {
        return _inventory;
    }

    public void InsertMoney(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        _currentBalance += amount;
    }

    public decimal Refund()
    {
        decimal refunded = _currentBalance;
        _currentBalance = 0;
        return refunded;
    }

    public decimal PurchaseItem(string selectionCode)
    {
        if (!_inventory.ContainsKey(selectionCode))
            throw new KeyNotFoundException("Invalid selection code.");

        var item = _inventory[selectionCode];

        if (item.Quantity <= 0)
            throw new OutOfStockException($"Item '{item.Name}' is out of stock!");

        if (_currentBalance < item.Price)
            throw new InsufficientFundsException($"Insufficient funds. {item.Name} costs {item.Price}");


        _currentBalance -= item.Price;
        item.Quantity--;

        Console.WriteLine($"\n  [Dispensing]: {item.Name}");
        item.Dispense();

        return _currentBalance;
    }

}

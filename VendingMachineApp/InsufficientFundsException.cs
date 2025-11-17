/*
 * BAGIAN 1: Berisi semua Pengecualian (Exception) kustom kita.
 * TUJUAN: Agar kita bisa membedakan error (e.g., "uang kurang" vs "stok habis") di dalam blok 'try-catch' nanti.
 */

/*
 * TODO: Buat Kustom Exception (Custom Exceptions)
 *
 * 1. Buat sebuah class public baru bernama 'OutOfStockException'.
 * - @INHERIT: Class ini HARUS mewarisi (inherit) dari 'Exception'.
 * - @CONSTRUCTOR: Buat sebuah constructor public yang menerima satu 'string message'.
 * - @LOGIC: Di dalam constructor, panggil constructor 'base(message)'.

* ===============================================================================================
*/

namespace VendingMachineApp;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException (string message) : base(message)
    {
        
    }
}

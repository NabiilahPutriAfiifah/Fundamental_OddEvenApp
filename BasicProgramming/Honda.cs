namespace BasicProgramming;

public class Honda : Car, IMachine
{
    public void Break()
    {
        Console.WriteLine("Mobil Mulai Berhenti");
    }

    public void Move()
    {
        Console.WriteLine("Mobil Mulai Berjalan");
    }


    public override void OpenDoor()
    {
        Console.WriteLine("Tekan untuk membuka Pintunya");
    }

    public override void OpenWindow()
    {
        Console.WriteLine("Tekan Tombol untuk membuka jendela");
    }

}

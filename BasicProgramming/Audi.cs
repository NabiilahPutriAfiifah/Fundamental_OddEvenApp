namespace BasicProgramming;

public class Audi : Car, IMachine
{
    public void Break()
    {
        Console.WriteLine("Berenti");
    }

    public void Move()
    {
        Console.WriteLine("Maju");
    }


    public override void OpenDoor()
    {
        Console.WriteLine("Buka Pintu");
    }

    public override void OpenWindow()
    {
        Console.WriteLine("Buka Jendela");
    }

}

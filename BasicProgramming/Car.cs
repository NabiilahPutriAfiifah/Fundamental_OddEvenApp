namespace BasicProgramming;

public abstract class Car
{
    public int MaxGear { get; set; }
    public int TopSpeed { get; set; }
    public bool IsManual { get; set; }

    public abstract void OpenDoor();
    public abstract void OpenWindow();
    public void StartEngine()
    {
        Console.WriteLine("Starting Engine");
    }

}

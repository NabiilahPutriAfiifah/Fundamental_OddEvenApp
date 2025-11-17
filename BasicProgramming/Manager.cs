namespace BasicProgramming;

public class Manager<TId> : Employee<TId>
{
    public float Allowance { get; set; }

    public override void Introduction()
    {
        base.Introduction();
        Console.WriteLine("ALLOWANCE :" + Allowance);
    }

    public Manager(TId id) : base(id)
    {
        Console.WriteLine("Instance Manager");
    }

}

namespace VendingMachineApp;

public class Drink : Item
{
    public Drink(string name, decimal price, int quantity) : base(name, price, quantity)
    {
        
    }

    public override void Dispense()
    {
        Console.WriteLine("*Glug glug*... *Fizz*");
    }

}

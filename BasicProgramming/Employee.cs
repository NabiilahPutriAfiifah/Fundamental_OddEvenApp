
namespace BasicProgramming;

public class Employee<TId>
{
    public TId Id { get; set; }
    public string FullName { get; set; }
    // public string id;
    // public string fullName;
    private float salary;
    protected string job;
    

    public float Salary
    {
        get { return salary; }
        set { 
            if (value < 0)
            {
                value = 0;
            }
            salary = value; 
            }
    }

    public string Job
    {
        get { return job; }
        set { job = value; }
    }

    public Employee (TId id)
    {
        Id = id;
        Console.WriteLine("Instance Employee");
    }

    // OVERRIDING
    public virtual void Introduction()
    {
        Console.WriteLine("=========");
        Console.WriteLine("ID : " + Id);
        Console.WriteLine("NAME : " + FullName) ;
        Console.WriteLine("SALARY : " + salary + "juta");
        Console.WriteLine("JOB : " + job);
    }


    // OVERLOADING
    public float CalculateTax()
    {
        float tax = 2.5f;
        return salary * tax;
    }

    public float CalculateTax(float aditionalFee)
    {
        float tax = 2.5f;
        return salary * tax * aditionalFee;
    }
}
using DAL;
using DAL.Models;
namespace BL;

public class BL_Employee
{
    private readonly PracticeContext _context;

    public BL_Employee(PracticeContext context)
    {
        _context = context;
    }   

    public bool AddEmployee( Customer customer)
    {
        try
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here if needed
            Console.WriteLine($"Error adding employee: {ex.Message}");
            return false;   
        }

    }
}

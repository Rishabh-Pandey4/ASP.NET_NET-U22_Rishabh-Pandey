using Task1.Models;

namespace Task1.Repositries
{
    public class EmployeeRepo : IEmployeeRepo
    {
        EmployeeDbContext _context;

        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmp()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmpById(int id)
        {
            return _context.Employees.Find(id);
        }
        public void AddEmp(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }
        public void DeleteEmp(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            _context.SaveChanges();
        }
        public void UpdateEmp(Employee obj)
        {
            _context.Employees.Update(obj);
            _context.SaveChanges();
        }
    }
}

using Task1.Models;

namespace Task1.Repositries
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmp();

        Employee GetEmpById(int id);

        void AddEmp(Employee obj);

        void DeleteEmp(int id);

        void UpdateEmp(Employee updated_Obj);

        public List<Employee> GetByDno(int dno);

        public List<Employee> GetByJob(string job);


    }
}

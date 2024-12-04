using Ryazantcev__353503_Lab6.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ryazantcev__353503_Lab6
{
    internal class Program
    {
        static List<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee {Salary = 10, Name = "A", IsOnVacation = false},
                new Employee {Salary = 20, Name = "B", IsOnVacation = false},
                new Employee {Salary = 30, Name = "C", IsOnVacation = false},
                new Employee {Salary = 40, Name = "D", IsOnVacation = true},
                new Employee {Salary = 50, Name = "E", IsOnVacation = true},
                new Employee {Salary = 60, Name = "F", IsOnVacation = true}
            };
        }
        static void Main(string[] args)
        {
            var employees = GetEmployeeList();

            var asm = Assembly.LoadFrom("FileService.dll");
            var asm_type = asm.GetType("FileService.FileService`1").MakeGenericType(typeof(Employee));
            var service = Activator.CreateInstance(asm_type);
            var SaveDataMethod = asm_type.GetMethod("SaveData");
            var ReadDataMethod = asm_type.GetMethod("ReadData");

            SaveDataMethod.Invoke(service, new object[] { employees, "Jsonfile" }); ;
            var fileList = ReadDataMethod.Invoke(service, new object[] { "Jsonfile" }) as IEnumerable<Employee>;

            foreach ( var el in fileList)
            {
                Console.WriteLine(el);
            }
        }
    }
}

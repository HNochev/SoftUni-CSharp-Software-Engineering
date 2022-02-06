using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            string result = GetEmployeesByFirstNameStartingWithSa(softUniContext);
            Console.WriteLine(result);
        }
        //15RemoveTown
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            var allAddressIds = town.Addresses
                .Select(x => x.AddressId)
                .ToList();

            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && allAddressIds.Contains(x.AddressId.Value))
                .ToList();

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            foreach (var addressId in allAddressIds)
            {
                var address = context.Addresses
                    .FirstOrDefault(x => x.AddressId == addressId);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{allAddressIds.Count} addresses in Seattle were deleted";
        }
        //14DeleteProjectById
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .FirstOrDefault(x => x.ProjectId == 2);

            var projectEmployees = context.EmployeesProjects
                .Where(x => x.ProjectId == project.ProjectId)
                .ToList();

            foreach (var pe in projectEmployees)
            {
                context.EmployeesProjects.Remove(pe);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().TrimEnd();
        }
        //13FindEmployeesByFirstNameStartingWithSa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        //12IncreaseSalaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<string> departments = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .OrderBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                e.Salary = e.Salary * 1.12m;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        //11FindLatest10Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate,
                })
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }
        //10DepartmentsWithMoreThan5Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    departmentName = x.Name,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    employees = x.Employees.Select(y => new
                    {
                        employeeFirstName = y.FirstName,
                        employeeLastName = y.LastName,
                        employeeJobTitle = y.JobTitle,
                    })
                    .OrderBy(y => y.employeeFirstName)
                    .ThenBy(y => y.employeeLastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.departmentName} - {d.managerFirstName} {d.managerLastName}");
                foreach (var e in d.employees)
                {
                    sb.AppendLine($"{e.employeeFirstName} {e.employeeLastName} - {e.employeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //9Employee147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    projects = x.EmployeesProjects.Select(y => new
                    {
                        y.Project.Name
                    })
                    .OrderBy(x => x.Name)
                    .ToList()
                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var p in employee147.projects)
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }
        //8AddressesByTown
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context.Addresses
                .Select(x => new
                {
                    address = x.AddressText,
                    townName = x.Town.Name,
                    empCount = x.Employees.Count,
                })
                .OrderByDescending(x => x.empCount)
                .ThenBy(x => x.townName)
                .ThenBy(x => x.address)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in adresses)
            {
                sb.AppendLine($"{a.address}, {a.townName} - {a.empCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
        //7EmployeesAndProjects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    empFirstName = x.FirstName,
                    empLastName = x.LastName,
                    mngFirstName = x.Manager.FirstName,
                    mngLastName = x.Manager.LastName,
                    projects = x.EmployeesProjects
                    .Select(y => new
                    {
                        name = y.Project.Name,
                        startDate = y.Project.StartDate,
                        endDate = y.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.empFirstName} {emp.empLastName} - Manager: {emp.mngFirstName} {emp.mngLastName}");
                foreach (var prj in emp.projects)
                {
                    sb.AppendLine($"--{prj.name} - {prj.startDate.ToString("M/d/yyyy h:mm:ss tt")} - {(prj.endDate == null ? "not finished" : prj.endDate.Value.ToString("M/d/yyyy h:mm:ss tt"))}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //6AddingANewAddressAndUpdatingEmployee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(newAddress);
            context.SaveChanges();

            Employee emp = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            emp.AddressId = newAddress.AddressId;
            context.SaveChanges();

            var result = context.Employees
                .Select(x => new
                {
                    x.Address.AddressId,
                    x.Address.AddressText
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var r in result)
            {
                sb.AppendLine($"{r.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }
        //5EmployeesFromResearchAndDevelopment
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //4EmployeesWithSalaryOver50000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new { x.FirstName, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //3EmployeesFullInformation
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            List<Employee> employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Employee e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}

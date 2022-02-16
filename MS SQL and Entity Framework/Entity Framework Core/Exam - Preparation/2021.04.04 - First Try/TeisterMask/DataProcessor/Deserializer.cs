namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var projects = new List<Project>();

            var projectTasksDto = XmlConverter.Deserializer<ProjectTasksImputModel>(xmlString, "Projects");

            foreach (var projectDto in projectTasksDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (projectDto.DueDate == "" || projectDto.DueDate == null)
                {
                    dueDate = null;
                }
                else
                {
                    dueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                List<TaskInputModel> tasks = new List<TaskInputModel>();

                foreach (var task in projectDto.Tasks)
                {
                    if (IsValid(task) && DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) && (dueDate == null || DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= dueDate))
                    {
                        tasks.Add(task);
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = dueDate,
                    Tasks = tasks
                    .Select(x => new Task
                    {
                        Name = x.Name,
                        OpenDate = DateTime.ParseExact(x.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(x.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = Enum.Parse<ExecutionType>(x.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(x.LabelType)
                    })
                    .ToArray()
                };

                projects.Add(project);
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var employees = new List<Employee>();

            var employeesDtos = JsonConvert.DeserializeObject<EmployeesImputModel[]>(jsonString);

            foreach (var employeeDto in employeesDtos)
            {
                var realTasks = context.Tasks.Select(x => x.Id)
                    .ToList();

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var currentTask = context.Tasks.FirstOrDefault(x => x.Id == taskId);

                    if (currentTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task = currentTask,
                    });
                }

                employees.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
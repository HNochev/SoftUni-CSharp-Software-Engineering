namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
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

            var xmlSerializer = new XmlSerializer(
                typeof(ProjectXmlImputModel[]),
                new XmlRootAttribute("Projects"));
            var projectsDtos =
                (ProjectXmlImputModel[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));

            foreach (var projectDto in projectsDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isProjectOpenDateNull = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);

                if (projectOpenDate == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = string.IsNullOrWhiteSpace(projectDto.DueDate)
    ? (DateTime?)null
    : DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var tasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isTaskOpenDateNull = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    var isTaskDueDateNull = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskOpenDateNull || !isTaskDueDateNull || taskOpenDate < projectOpenDate || (projectDueDate != null && taskDueDate > projectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType),
                    };

                    tasks.Add(task);
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                    Tasks = tasks,
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

            var employeesDtos = JsonConvert
                .DeserializeObject<IEnumerable<EmployeeJsonImputModel>>(jsonString);

            foreach (var employeeDto in employeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var uniqueTasks = employeeDto.Tasks.Distinct();

                var allTasks = context.Tasks.Select(x => x.Id).ToList();

                var resultTasks = new List<EmployeeTask>();

                foreach (var taskId in uniqueTasks)
                {
                    if (!allTasks.Contains(int.Parse(taskId)))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = context.Tasks.FirstOrDefault(x => x.Id == int.Parse(taskId));

                    var taskEmployee = new EmployeeTask
                    {
                        Task = task,
                    };

                    resultTasks.Add(taskEmployee);
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    EmployeesTasks = resultTasks,
                };

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
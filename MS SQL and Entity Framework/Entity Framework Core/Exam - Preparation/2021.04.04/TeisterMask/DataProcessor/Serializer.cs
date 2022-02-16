namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects.ToList()
                .Where(x => x.Tasks.Count > 0)
                .Select(x => new ProjectXmlOutputModel
                {
                    TasksCount = x.Tasks.Count(),
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(y => new TaskXmlOutputModel
                    {
                        Name = y.Name,
                        Label = y.LabelType.ToString(),
                    })
                    .OrderBy(y => y.Name)
                    .ToArray(),
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, "Projects");

            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees.ToList()
                .Where(x => x.EmployeesTasks.Count > 0)
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(y => y.Task.OpenDate >= date)
                    .OrderByDescending(y => y.Task.DueDate)
                    .ThenBy(y => y.Task.Name)
                    .Select(y => new
                    {
                        TaskName = y.Task.Name,
                        OpenDate = y.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = y.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = y.Task.LabelType.ToString(),
                        ExecutionType = y.Task.ExecutionType.ToString()
                    })
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}
using System;
using System.Collections.ObjectModel;

namespace MAUISfDataGrid
{
    public class EmployeeViewModel
    {
        public ObservableCollection<Employee> Employees { get; }

        public EmployeeViewModel(int count)
        {
            Employees = GenerateEmployees(count);
        }

        private ObservableCollection<Employee> GenerateEmployees(int count)
        {
            var employees = new ObservableCollection<Employee>();
            var random = new Random();

            string[] firstNames = { "John", "Emma", "Michael", "Sophia", "David", "Olivia", "James", "Ava" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Wilson", "Taylor", "Davis" };
            string[] departments = { "Engineering", "HR", "Finance", "Sales", "Support", "Marketing" };
            string[] designations = { "Developer", "Manager", "Lead", "Analyst", "Consultant" };
            string[] locations = { "New York", "London", "Chennai", "Singapore", "Sydney" };

            for (int i = 1; i <= count; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];

                employees.Add(new Employee
                {
                    EmployeeId = i,
                    EmployeeCode = $"EMP{i:D6}",
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    Age = random.Next(22, 60),
                    Email = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@company.com",
                    PhoneNumber = $"98765{i % 100000:D5}",
                    Department = departments[random.Next(departments.Length)],
                    Designation = designations[random.Next(designations.Length)],
                });
            }

            return employees;
        }
    }
}
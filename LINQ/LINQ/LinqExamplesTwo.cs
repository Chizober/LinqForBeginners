namespace LINQ
{
    public partial class LinqExamples
    {
        public List<Employees> employees = new List<Employees>
        {
            new Employees
            {
                EmployeeID = 1,
                EmployeeFullName = "Abraham Peters",
                DepartmentID = 100
            },
            new Employees
            {
                EmployeeID = 2,
                EmployeeFullName = "Grace Eze",
                DepartmentID = 101
            },
            new Employees
            {
                EmployeeID = 3,
                EmployeeFullName = "Chuka Ugochukwu",
                DepartmentID = 101
            }
        };

        public List<Departments> departments = new List<Departments>
        {
            new Departments { DepartmentID = 101, DepartmentName = "Software" },
            new Departments { DepartmentID = 100, DepartmentName = "Networking" },
            new Departments { DepartmentID = 103, DepartmentName = "Crypto" }
        };

        public void FetchEmployeesAndDepartments()
        {
            Console.WriteLine("\n\tUsing Where in query syntax \n");
            var querySyntax1 =
                from employee in employees
                where employee.EmployeeFullName.ToLower().StartsWith("c")
                select employee.EmployeeFullName;

            foreach (var item in querySyntax1)
            {
                Console.WriteLine($"\t{item}");
            }

            Console.WriteLine("\n\tUsing Where in method syntax\n");

            var methodSyntax1 = employees.Where(
                emp => emp.EmployeeFullName.ToLower().StartsWith("c")
            );

            foreach (var item in methodSyntax1)
            {
                Console.WriteLine($"\t{item.EmployeeFullName}");
            }
            Console.WriteLine();
            // using order by ascending
            Console.WriteLine("\n\tUsing ORDER BY ASCENDING in query syntax \n");
            var querySyntax2 =
                from employee in employees
                orderby employee.EmployeeFullName
                select employee.EmployeeFullName;

            foreach (var item in querySyntax2)
            {
                Console.WriteLine($"\t{item}");
            }

            Console.WriteLine("\n\tUsing ORDER BY ASCENDING in method syntax\n");

            var methodSyntax2 = employees.OrderBy(emp => emp.EmployeeFullName);

            foreach (var item in methodSyntax2)
            {
                Console.WriteLine($"\t{item.EmployeeFullName}");
            }

            // using order by descending
            Console.WriteLine("\n\tUsing ORDER BY DESCENDING in query syntax \n");
            var querySyntax3 =
                from employee in employees
                orderby employee.EmployeeFullName descending
                select employee.EmployeeFullName;

            foreach (var item in querySyntax3)
            {
                Console.WriteLine($"\t{item}");
            }

            Console.WriteLine("\n\tUsing ORDER BY DESCENDING  in method syntax\n");

            var methodSyntax3 = employees.OrderByDescending(emp => emp.EmployeeFullName);

            foreach (var item in methodSyntax3)
            {
                Console.WriteLine($"\t{item.EmployeeFullName}");
            }

            // using Then by


            Console.WriteLine("\n\tUsing Then By in query syntax \n");
            var querySyntax4 =
                from employee in employees
                orderby employee.DepartmentID, employee.EmployeeFullName
                select employee;

            foreach (var item in querySyntax4)
            {
                Console.WriteLine($"\t{item.DepartmentID} : {item.EmployeeFullName}");
            }

            Console.WriteLine("\n\tUsing Then By  in method syntax\n");

            var methodSyntax4 = employees
                .OrderBy(emp => emp.DepartmentID)
                .ThenBy(emp => emp.EmployeeFullName);

            foreach (var item in methodSyntax4)
            {
                Console.WriteLine($"\t{item.DepartmentID} : {item.EmployeeFullName}");
            }

            // selects a particular number of rows
            Console.WriteLine("\n\tUsing Take in query syntax \n");

            var querySyntax5 = (from employee in employees select employee).Take(2);

            foreach (var item in querySyntax5)
            {
                Console.WriteLine($"\t{item.EmployeeFullName}");
            }
            Console.WriteLine("\n\tUsing Take in method syntax \n");
            var methodSyntax5 = employees.Take(2);

            foreach (var item in methodSyntax5)
            {
                Console.WriteLine($"\t {item.EmployeeFullName}");
            }

            // skips a particular number of rows

            Console.WriteLine("\n\tUsing Skip in query syntax \n");

            var querySyntax6 = (from employee in employees select employee).Skip(2);

            foreach (var item in querySyntax6)
            {
                Console.WriteLine($"\t {item.EmployeeFullName}");
            }
            Console.WriteLine("\n\tUsing Skip in method syntax \n");
            var methodSyntax6 = employees.Skip(2);

            foreach (var item in methodSyntax6)
            {
                Console.WriteLine($"\t {item.EmployeeFullName}");
            }

            // groups your data according to a given property

            Console.WriteLine("\n\tUsing Group in query syntax \n");

            var querySyntax7 = from employee in employees group employee by employee.DepartmentID;

            foreach (var item in querySyntax7)
            {
                Console.WriteLine($"\t{item.Key} : {item.Count()}");
            }
            Console.WriteLine("\n\tUsing Group in method syntax \n");
            var methodSyntax7 = employees.GroupBy(emp => emp.DepartmentID);

            foreach (var item in methodSyntax7)
            {
                Console.WriteLine($"\t{item.Key} :{item.Count()}");
            }

            // Join is used to join lists(more than one) together

            Console.WriteLine("\n\tUsing Join in query syntax \n");

            var querySyntax8 =
                from employee in employees
                join department in departments
                    on employee.DepartmentID equals department.DepartmentID
                select new { employee.EmployeeFullName, department.DepartmentName };

            foreach (var item in querySyntax8)
            {
                Console.WriteLine($"\t{item.EmployeeFullName} : {item.DepartmentName}");
            }
            Console.WriteLine("\n\tUsing Join in method syntax \n");

            var methodSyntax8 = employees.Join(
                departments,
                e => e.DepartmentID,
                d => d.DepartmentID,
                (e, d) => new { e.EmployeeFullName, d.DepartmentName }
            );

            foreach (var item in methodSyntax8)
            {
                Console.WriteLine($"\t{item.EmployeeFullName} : {item.DepartmentName}");
            }

            //  Left Join is used to join lists(more than one) together

            Console.WriteLine("\n\tUsing Left Join in query syntax \n");

            var querySyntax9 =
                from employee in employees
                join department in departments
                    on employee.DepartmentID equals department.DepartmentID
                    into group1
                from department in group1.DefaultIfEmpty()
                select new
                {
                    employee.EmployeeFullName,
                    DepartmentName = department?.DepartmentName ?? "NULL"
                };

            foreach (var item in querySyntax9)
            {
                Console.WriteLine($"\t{item.EmployeeFullName} : {item.DepartmentName}");
            }
        }
    }
}

--1. Add employee 'Tina Smith'
--INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
--VALUES (4, 'Tina', 'Smith', 123456789, 1);
--INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
--VALUES (4, 4, 60000, '707 Laughter', '616 Road', 'Sherman', 'Illinois', 'US');

--2. Add department 'Marketing'
--INSERT INTO Department([ID], [Name], [Location])
--VALUES (4, 'Marketing', 'Peoria');

--2.5: Feed a couple employees into Marketing
--INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
--VALUES (5, 'Diana', 'Dove', 445931010, 4);
--INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
--VALUES (5, 5, 35000, '62 Court', '1 Loop', 'Peoria', 'Illinois', 'US');

--INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
--VALUES (6, 'Eric', 'Ersatz', 626262626, 4);
--INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
--VALUES (6, 6, 65000, '63 Court', '2 Loop', 'Peoria', 'Illinois', 'US');

--3. List all employees in Marketing
SELECT *
FROM dbo.Employee
WHERE DeptID = 4;

--4. Report Salary Total of Marketing
--SELECT SUM([Salary]) AS 'Marketing Total Salary'
--FROM dbo.EmpDetails
--WHERE EmployeeID = (SELECT ID FROM dbo.Employee WHERE DeptID = 4);

--5. Report total employees by department
SELECT Department.Name AS 'Department', COUNT(Employee.ID) AS 'Number of Employees'
FROM dbo.Employee JOIN dbo.Department ON dbo.Employee.DeptID = dbo.Department.ID
GROUP BY DeptID;

--6. Increase salary of Tina Smith to $90,000
--UPDATE EmpDetails
--SET Salary = 90000
--WHERE EmployeeID = 4;
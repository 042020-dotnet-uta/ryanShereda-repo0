
/**************************
	Employee Seeding
***************************/

/***Table Creation**********
CREATE TABLE [dbo].[Department]
(
	[ID] INT NOT NULL,
	[Name] NVARCHAR(40) NOT NULL,
	[Location] NVARCHAR(80) NOT NULL,
	PRIMARY KEY([ID])
);
GO

CREATE TABLE [dbo].[Employee]
(
	[ID] INT NOT NULL,
	[FirstName] NVARCHAR(40) NOT NULL,
    [LastName] NVARCHAR(40) NOT NULL,
	[SSN] CHAR(9) NOT NULL,
	[DeptID] INT NOT NULL,
	PRIMARY KEY ([ID]),
	FOREIGN KEY ([DeptID]) REFERENCES [dbo].[Department]([ID])
);
GO
CREATE TABLE [dbo].[EmpDetails]
(
	[ID] INT NOT NULL,
	[EmployeeID] INT NOT NULL,
	[Salary] INT NOT NULL,
	[Address1] NVARCHAR(70),
	[Address2] NVARCHAR(70),
	[City] NVARCHAR(40),
    [State] NVARCHAR(40),
    [Country] NVARCHAR(40),
	PRIMARY KEY ([ID]),
	FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee]([ID])
);
GO
*****End Table Creation********/

/*****************************************************
	Table Insertion
*****************************************************/

/***Table Seeding*******
INSERT INTO Department([ID], [Name], [Location])
VALUES (1, 'Training', 'Chicago');

INSERT INTO Department([ID], [Name], [Location])
VALUES (2, 'Legal', 'Springfield');

INSERT INTO Department([ID], [Name], [Location])
VALUES (3, 'HR', 'Decatur');

INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
VALUES (1, 'Aaron', 'Anderson', 648953772, 2);

INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
VALUES (2, 'Becky', 'Bristol', 551896667, 3);

INSERT INTO Employee([ID], [FirstName], [LastName], [SSN], [DeptID])
VALUES (3, 'Charles', 'Clinton', 000000001, 1);

INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
VALUES (1, 1, 45000, '111 Emery', '222 Hackberry', 'Chatham', 'Illinois', 'US'); 

INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
VALUES (2, 2, 90000, '404 Legal', '555 Irony', 'Springfield', 'Illinois', 'US');

INSERT INTO EmpDetails([ID], [EmployeeID], [Salary], [Address1], [Address2], [City], [State], [Country])
VALUES (3, 3, 55000, '999 End of Line', '000 Start of Line', 'Decatur', 'Illinois', 'US');
*****End Table Seeding*****************/
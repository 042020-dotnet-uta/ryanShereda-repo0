
/**************************
	Employee Seeding
***************************/

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
	CONSTRAINT [PK_EmpDetails] PRIMARY KEY CLUSTERED ([ID])
);
GO
CREATE TABLE [dbo].[Employee]
(
	[ID] INT NOT NULL,
	[FirstName] NVARCHAR(40) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
	[SSN] INT NOT NULL,
	[DeptID] INT NOT NULL,
	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([ID])
);
GO
CREATE TABLE [dbo].[Department]
(
	[ID] INT NOT NULL,
	[Name] NVARCHAR(40) NOT NULL,
	[Location] NVARCHAR(80) NOT NULL,
	CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([ID])
);
GO


ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [FK_EmployeeDeptID]
	FOREIGN KEY ([DeptID]) REFERENCES [dbo].[Department]([ID]);
GO
ALTER TABLE [dbo].[EmpDetails] ADD CONSTRAINT [FK_EmpDetailsID]
	FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee]([ID]);
GO

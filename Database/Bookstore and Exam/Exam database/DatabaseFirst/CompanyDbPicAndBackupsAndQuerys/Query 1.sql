USE [Company]
GO

SELECT (e.FirstName + ' ' + e.LastName) AS [Full name],
		e.YearSalary
FROM [Employees] e
WHERE e.YearSalary >= 100000 AND e.YearSalary <= 150000
ORDER BY e.YearSalary ASC
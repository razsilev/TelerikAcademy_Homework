USE [Company]
GO

SELECT d.Name AS [Departmant name],
		COUNT(*) AS [Number of employees]
FROM [Departments] d
	INNER JOIN [Employees] e
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY COUNT(*) DESC
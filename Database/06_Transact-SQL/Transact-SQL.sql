-- Task 1: Create a database with two tables: 
-- Persons(Id(PK), FirstName, LastName, SSN) 
-- and Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. 
-- Write a stored procedure that selects the full names of all persons.
-----------------------------------------
USE master
GO

IF EXISTS(SELECT name FROM sys.databases
	WHERE name = 'Bank')
	DROP DATABASE Bank
GO

CREATE DATABASE Bank
GO

USE Bank
GO

CREATE TABLE Persons (
	[Id] int IDENTITY,
	[FirstName] nvarchar(30) NOT NULL,
	[LastName] nvarchar(30) NOT NULL,
	[SSN] nvarchar(11) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)
GO

CREATE TABLE Accounts (
	[Id] int IDENTITY,
	[PersonId] int NOT NULL,
	[Balance] money NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonId) REFERENCES Persons(Id)
)
GO

INSERT INTO Persons (FirstName, LastName, SSN) VALUES ('Guy', 'Gilbert', '721-07-4426')
INSERT INTO Persons (FirstName, LastName, SSN) VALUES ('Ruth', 'Ellerbrock', '824-60-9117')
INSERT INTO Persons (FirstName, LastName, SSN) VALUES ('Jeffrey', 'Ford', '812-09-2815')
INSERT INTO Persons (FirstName, LastName, SSN) VALUES ('David', 'Bradley', '391-06-6917')

INSERT INTO Accounts (PersonId, Balance) VALUES (1, 2500)
INSERT INTO Accounts (PersonId, Balance) VALUES (2, 125000)
INSERT INTO Accounts (PersonId, Balance) VALUES (3, 15000)
INSERT INTO Accounts (PersonId, Balance) VALUES (4, 10000)
GO

CREATE PROC usp_SelectPersons
AS 
	SELECT FirstName + ' ' + LastName AS [FullName] 
	FROM Persons
GO
-----------------------------------------
-- Task 2: Create a stored procedure that accepts a number as a parameter 
-- and returns all persons who have more money in their accounts than the supplied number.
-----------------------------------------
CREATE PROC usp_SelectPersonsWithBalanceMoreThan 
@amount money
AS 
	SELECT p.FirstName + ' ' + p.LastName AS [FullName], a.Balance
	FROM Persons AS p
	JOIN Accounts AS a
		ON p.Id = a.PersonId
	WHERE a.Balance > @amount
GO
-----------------------------------------
-- Task 3: Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. 
-- Write a SELECT to test whether the function works as expected.
-----------------------------------------
CREATE FUNCTION ufn_CalculateInterest(@sum money, @interestRate int, @numberOfMonth int)
	RETURNS int
AS
BEGIN
	RETURN ((@interestRate / 100.0) / 12) * @numberOfMonth * @sum
END
GO

SELECT dbo.ufn_CalculateInterest(1000, 10, 12);
GO
-----------------------------------------
-- Task 4: Create a stored procedure that uses the function from the previous example 
-- to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
-----------------------------------------
CREATE PROC usp_AddInterestToBalance
@accountId int, @interestRate int
AS
	UPDATE Accounts SET Balance = dbo.ufn_CalculateInterest(Balance, @interestRate, 1) + Balance
	WHERE Id = @accountId
GO

EXEC usp_AddInterestToBalance 1, 6
GO
-----------------------------------------
-- Task 5: Add two more stored procedures WithdrawMoney( AccountId, money)
-- and DepositMoney (AccountId, money) that operate in transactions.
-----------------------------------------
CREATE PROC usp_WithdrawMoney
@accountId int, @withdrawMoney money
AS
	BEGIN TRAN
	DECLARE @newBalance money
	SET @newBalance = (SELECT Balance FROM Accounts WHERE ID = @accountId) - @withdrawMoney;

	IF @newBalance >= 0
		BEGIN 
			UPDATE Accounts SET Balance = @newBalance
			WHERE Id = @accountId
			COMMIT TRAN
		END
	ELSE
		ROLLBACK TRAN
GO

--TEST
EXEC usp_WithdrawMoney 1, 100;
SELECT * FROM Accounts
GO

CREATE PROC usp_DepositMoney
@accountId int, @depositMoney money
AS
	BEGIN TRAN
	IF @depositMoney > 0
		BEGIN
			UPDATE Accounts SET Balance = Balance + @depositMoney
			WHERE Id = @accountId
			COMMIT TRAN
		END
	ELSE
		ROLLBACK TRAN
GO

--TEST
EXEC usp_DepositMoney 1, 100;
SELECT * FROM Accounts
GO
-----------------------------------------
-- Task 6: Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry 
-- into the Logs table every time the sum on an account changes.
-----------------------------------------
CREATE TABLE Logs(
	LogID int IDENTITY PRIMARY KEY,
	AccountID int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER utr_AccountsUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountID, OldSum, NewSum) 
		SELECT d.PersonId, d.Balance, i.Balance 
		FROM deleted AS d
		JOIN inserted AS i
			ON d.PersonId = i.PersonId
GO

--TEST
EXEC dbo.usp_DepositMoney 1, 200
GO

-----------------------------------------
-- Task 7: Define a function in the database TelerikAcademy that returns all Employee's	
-- names (first or middle or last name) and all town's names that are comprised of		
-- given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',				
-- … but not 'Rob' and 'Guy'.															
-----------------------------------------

USE [TelerikAcademy]
GO

-- Using helper function that finds if a string consists of other string

IF OBJECT_ID('dbo.ufn_StringComprisedOf') IS NOT NULL DROP FUNCTION ufn_StringComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO


IF OBJECT_ID('dbo.ufn_EmployeesAndTownsNameComprisedOf') IS NOT NULL DROP FUNCTION ufn_EmployeesAndTownsNameComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name nvarchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @reulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM [dbo].ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO

-----------------------------------------
-- Task 8: Using database cursor write a T-SQL script that scans all employees and 
-- their addresses and prints all pairs of employees that live in the same town.
-----------------------------------------

USE [TelerikAcademy]
GO

SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID <> @employeeID
    FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO

-- This is the outer join way to do it without a db cursor

SELECT t1.Name, e1.FirstName + ISNULL(' '+ e1.MiddleName, '') + ' ' + e1.LastName AS FirstEmployeeName,
e2.FirstName + ISNULL(' '+ e2.MiddleName, '') + ' ' + e2.LastName AS SecondEmployeeName
FROM Employees e1 JOIN Addresses a1 ON e1.AddressID = a1.AddressID
JOIN Towns t1 ON a1.TownID = t1.TownID,
Employees e2 JOIN Addresses a2 ON e2.AddressID = a2.AddressID
JOIN Towns t2 ON a2.TownID = t2.TownID
WHERE t1.Name = t2.Name
AND e1.EmployeeID <> e2.EmployeeID
ORDER BY t1.Name, FirstEmployeeName, SecondEmployeeName

-----------------------------------------
-- Task 9: Write a T-SQL script that shows for each town a list of all employees
-- that live in it. Sample output: Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
-----------------------------------------

-- Solution with nested Cursors. Prints in Messages Window

USE [TelerikAcademy]
GO

SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE INDEX Idx_TemTown ON #TempEmployeesWithTowns(TownID)


DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name FROM Towns
OPEN townCursor
DECLARE @townID int, @townName varchar(50)
FETCH NEXT FROM townCursor INTO @townID, @townName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName varchar(150), @employeesList varchar(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @townName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @townName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns
GO

-----------------------------------------
-- Task 10: Define a .NET aggregate function StrConcat that takes as input a sequence of
-- strings and return a single string that consists of the input strings separated by
-- ','. For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees
-----------------------------------------

USE [TelerikAcademy]
GO

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

DECLARE @path nvarchar(256)
-- You must change this path to the folder where the .dll with the CLR function is.
SET @path = 'C:\PathToFile'

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM @path+'\ConcatAggregateSqlFunction.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX),
	@Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.Concat; 
GO

-- Enable execution of CLR code 
sp_configure 'clr enabled',1
GO
RECONFIGURE
GO
--sp_configure 'clr enabled'  -- make sure it took
--GO

SELECT [dbo].StrConcat(FirstName + ' ' + LastName, ', ') as Names
FROM Employees

-----------------------------------------
-- Solution to Task 9 with StrConcat from Task10
-----------------------------------------

USE [TelerikAcademy]
GO

SELECT t.Name AS Town, [dbo].StrConcat(FirstName + ' ' + LastName, ', ') AS Employees
FROM Employees e INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY t.Name
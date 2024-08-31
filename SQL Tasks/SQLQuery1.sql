-- single comment
print @@version
print @@servername

--declare @Name varchar(10) = 'Ahmed'
--Print @Name
--Set @Name = 'Mahmoud'
--Print @Name

Create Database Company
Use Company

--Create Table Employees
--(
--Id int Primary Key Identity(1,1), --first id 1 and increase by 1
--FName varchar(20) Not Null,
--LName varchar(20),
--BDate Date,
--Address varchar(30) default 'cairo',
--Gender char(1),
--Salary money,
--SuperId int references Employees(Id), --self relationship
--DepartmentNumber int
--)
--Create Table Departments
--(
--Dnum int Primary Key Identity(10,10),
--Dname varchar(20) Not Null,
--ManagerId int references Employees(Id),
--MGRStartDate Date
--)
--Create Table DepartmentLocations
--(
--Departmentnumber int references Departments(Dnum),
--Location Varchar(40),
--primary Key(Departmentnumber ,Location) --composite PK
--)
--Create Table Projects
--(
--Pnum int Primary Key Identity(100,100),
--PName varchar(25) Not Null,
--PLocation varchar(30),
--city varchar(10),
--DepartmentNumber int references Departments(Dnum)
--)
--Create Table Employees_Projects
--(
--EmpoyeeId int references Employees(Id),
--ProjectNumber int references Projects(Pnum),
--WHours int ,
--Primary Key (EmpoyeeId,ProjectNumber)
--)
--Create Table Dependents
--(
--EmployeeId int references Employees(Id),
--DependentName varchar(20),
--Bdate Date ,
--Gender char(1),
--Relationship varchar(30),
--Primary Key(DependentName ,EmployeeId)
--)
--Alter (Update)
Alter Table Employees 
Add Test int --Add Column to the Table

Alter Table Employees
Alter Column Test bigint --Ubdate the column in the Table

Alter Table Employees
Drop Column Test  --Delete the Column from the Table

Alter Table Employees  --Make Another RelationShip
Add Foreign Key (DepartmentNumber) references Departments(Dnum)

-- Drop
Drop Database company
--Drop Table Employees
-- DML 1.insert 
------1.1simple insert (add just only one row .. you will insert all data)
Insert Into Employees
Values('Ahmed' , 'Nasr' , '02-09-2010' , 'Alex' ,'M',5000 , NULL ,NULL)
--if you will not insert all data 
--علشان تعمل كدة لازم يتوفر احد الشروط دي
--1.Identity Costrain (Id)
--2.Default Value (Address)
--3.Allow NULL
Insert Into Employees(FName,BDate,Gender,Salary)
Values('Mohamed','10-11-1996','M',9000)
--Row Constractor (to add multiple record)
Insert Into Employees
Values
('Mai' , 'Mohamed' , '02-09-2010' , 'Giza' ,'F',5000 , 1 ,NULL),
('Ahmed' , 'Ali' , '02-09-2010' , 'Tanta' ,'M',10000 , 2 ,NULL),
('Omer' , 'Ali' , '02-09-2010' , 'Cairo' ,'M',3000 , 1 ,NULL),
('Mona' , 'Mohamed' , '02-09-2010' , 'Giza' ,'F',2000 , 1 ,NULL)

--2.Update 
--change the address of employee 1
Update Employees
Set Address = 'Giza' 
   where Id = 1

Update Employees
Set FName = 'Hamada' , LName = 'Hamada' 
   where Id = 2

Update Employees
Set Salary +=Salary*0.1
   where Address = 'Cairo' and Salary<5000

--3.Delete
Delete From Employees
   Where Id = 6  --delete Mona

--Select  Just for display
Select *
From Employees

Select FName , LName
from Employees

Select FName + ' ' + LName as [Full name]
from Employees

Select Id , FName , LName , Address
From Employees
where Id = 1

Select Id , FName , LName
From Employees
where Salary Between 3000 and 8000

Select Id , FName , LName
From Employees
where Address not in ('Cairo' , 'Alex')

Select Id , FName 
From Employees
where SuperId is null
-- _ => One Character % => Zero or More characters
Select Id ,FName
From Employees 
Where FName like '_a%'

-- '[ahm]%' first is a or h or m   [346]
-- '[^ahm]%' first is not a,h ,m
-- '[a-h]%' first is range from a to h
-- '%[%]' the last char is %
-- '%[_]%'  '[_]%[_]'
Select Distinct FName
From Employees 

Select FName , LName
From Employees 
Order By 1 ,2  Desc --Defualt asc ,, Desc
/*
if you want to select more than one table
Cartisian Product (Cross Join) Fake Data testing*/
Select E.FName,D.Dname
From Employees E Cross Join Departments D

Select E.FName,D.Dname
From Employees E inner Join Departments D
on D.Dnum = E.DepartmentNumber


Select E.FName,D.Dname
From Employees E left Outer Join Departments D
on D.Dnum = E.DepartmentNumber


Select E.FName,D.Dname
From Employees E right outer Join Departments D
on D.Dnum = E.DepartmentNumber

Select E.FName,D.Dname
From Employees E full outer Join Departments D
on D.Dnum = E.DepartmentNumber
/*
Equi Join (Inner Join)
Select E.Name,D.Name
From Employee E Inner Join Department D
Where D.Id = E.DeptId
3.1 Left outer Join =>inner join + that it not there in employee
Select E.Name,D.Name
From Employee E left outer join  Department D
On D.Id = E.DeptId
3.2 Right Outer Join => inner join + that it not there in Department
Select E.Name,D.Name
From Employee E right outer join  Department D
On D.Id = E.DeptId
Full Outer Join => both left and right outer join
Select E.Name,D.Name
From Employee E full outer join  Department D
On D.Id = E.DeptId
Self Join 
Select Emps.Name , Managers.Name
From Employees Emps , Employees Managers
Where Managers.Id = Employees.ManagerId (PK = FK)

*/

Use ITI
Select Stds.St_Fname as StudentName , Supers.St_Fname as SuperVisorName
From Student Stds , Student Supers
Where Supers.St_Id = Stds.St_super  --ANSI (Equi Join)
Select Stds.St_Fname as StudentName , Supers.St_Fname as SuperVisorName
From Student Stds Inner join Student Supers
on Supers.St_Id = Stds.St_super  --Microsoft (Inner Join)
Select Stds.St_Fname as StudentName , Supers.*
From Student Stds Inner join Student Supers
on Supers.St_Id = Stds.St_super  --Microsoft (Inner Join)
--Multiple Tables Join
 Select S.St_Fname , Sc.Grade , C.Crs_Name
 from Student S , Stud_Course Sc , Course C
 Where S.St_Id = Sc.St_Id and C.Crs_Id = Sc.Crs_Id --ANSI
 Select S.St_Fname , Sc.Grade 
 from Student S Inner Join Stud_Course Sc 
 On S.St_Id = Sc.St_Id 
 Inner Join Course C
 On C.Crs_Id = Sc.Crs_Id --Microsoft
 --Join With DML
 --Join + 
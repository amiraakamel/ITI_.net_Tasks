insert into Department (Dept_Id ,Dept_Name,Dept_Desc,Dept_Location) values
( 80,'dotnet','dotnet developer','lec3')
insert into Department values(90,'OS','opensource','lec3',1,'5/1/2020')

insert into Department values(100,'OS','opensource','lec3',1,'5/1/2020'),
(110,'OS','opensource','lec3',1,'5/1/2020'),
(120,'OS','opensource','lec3',1,'5/1/2020')


update Department 
set Dept_Name='php'
where Dept_Id=110

update Department 
set Dept_Name='SD',Dept_Desc='system developent',Dept_Location='lec2'
where Dept_Id>=100

update Department
set Dept_Manager=4
where Dept_Id=100 or Dept_Name='os'

-- delete
delete from Department 
where Dept_Id=110

delete from Department
where Dept_Id=120 or Dept_Name='os'

--- DQL (SELECT)
select * from Department

select dept_id,dept_name ,Dept_Desc,Manager_hiredate
from Department
where Dept_Id>50

select distinct dept_name from Department

select * from Department 
where Dept_Manager not in(1,4)

select  * from Department 
where Dept_Manager =1 or Dept_Manager=4 or Dept_Manager=2

select  * from Department 
where Dept_Manager in(1,4,2)


select * from Student
where St_Age>=20 and St_Age <=23

select  * from Student 
where St_Age between 20 and  23


select  * from student 
where St_Fname like '%al%'


select  * from student 
where St_Fname like '_o%'

select  st_fname ,st_age+4 from Student

select  st_fname as 'name' ,st_age+4 as 'age' from Student

select st_fname+' '+st_lname as'full name' ,st_age  from Student

select  * 
from Student
where St_Age >22
order by St_Fname desc

select  * 
from Student
where St_Age >22
order by St_Fname desc ,Dept_Id 

select  * 
from Student
where St_Age >22
order by 2 desc ,6 

select  * 
from Student
order by NEWID()


select Top(5) * 
from Student
order by NEWID()

select Top 5 * 
from student

select Top 4 * 
from student
order by St_Age desc


SELECT TOP(5) *
FROM student
ORDER BY NEWID();
select * from Course
where Crs_Duration = null

select * from Department where Dept_Manager is not null

select ISNULL(dept_manager,'') as manager from Department
select ISNULL(st_fname,'') as 'first name' from Student

select * from Course
where Crs_Duration is  null
select * from Student where st_lname is not null


select ISNULL(st_age,100) , ISNULL(St_Fname ,' ') from Student

select St_Fname +' '+St_Lname as 'full name' ,St_Age ,St_Id
into student2
from Student
where St_Age>24



select st_fname as name,st_age  as age
into student4
from Student
where St_Age >20


select  * 
into student3
from Student
where 1=2




select st_fname+' ' +St_Lname  as [full name]
into test4
from Student
where 1=2


--joins 

select  st_fname ,dept_name
from Student s, Department d
where s.Dept_Id=d.Dept_Id

--A Cartesian Product
select s.st_fname,d.dept_name
from student s , department d
where s.Dept_Id=d.Dept_Id

--Inner join and equi join

select st_fname ,dept_name
from Student inner join Department
on student.Dept_Id=Department.Dept_Id



select s.st_fname +' ' + s.St_Lname ,St_Age ,d.dept_name ,d.Dept_Location
from Student s inner join Department d
on s.Dept_Id=d.Dept_Id




select st_fname,dept_name
from student s inner join department d
on s.dept_id=d.dept_id
where s.St_Age >25



--inner with 3 tables
select st_fname,dept_name,ins.ins_name
from student s inner join department d
on s.dept_id=d.dept_id inner join instructor ins
on ins.dept_id=d.dept_id
order by ins_name

select s.St_Fname+' '+s.St_Lname,s.St_Age ,d.Dept_Name ,i.Ins_Name
from student s inner join Department d 
on s.Dept_Id=d.Dept_Id
inner join Instructor i on d.Dept_Manager=i.Ins_Id


select s.st_fname +' ' + s.St_Lname ,St_Age ,d.dept_name ,d.Dept_Location
from Student s full outer join Department d
on s.Dept_Id=d.Dept_Id

select st_fname,dept_name
from student s left outer join department d
on s.dept_id=d.dept_id

select st_fname,dept_name
from student s right outer join department d
on s.dept_id=d.dept_id

select st_fname,dept_name
from student s full outer join department d
on s.dept_id=d.dept_id

select  st.St_Fname+' '+st.St_Lname as 'student name' ,
super.St_Fname+' '+super.St_Lname as 'supdervisor name'
from student st inner join student super on st.St_super=super.St_Id

select stud.st_fname,super.st_fname as "supervisor Name"
from student super,student stud
where super.st_id=stud.st_super
 
select  AVG(st_age) from student

select avg(ISNULL( st_age,0)) from student
select MAX(crs_duration) from Course

select COUNT(*) from student
 
select COUNT(*) from student

SELECT AVG(ST_AGE) FROM Student
 
SELECT AVG(ISNULL(ST_AGE,0)) FROM Student



select count(isnull(st_age,0)) as avg ,St_super,Dept_Id 
from student

select MAX(St_Age),Dept_Id
from student 
group by Dept_Id 
having max(st_age)>24

select COUNT(st_id),dept_id from Student
group by Dept_Id
having avg( isnull(st_age ,0)) >17

select COUNT(st_id),Dept_Id from Student
group by Dept_Id
having COUNT(st_id)>2

select COUNT(*) from student
having avg(St_Age)<25

Select St_fname,st_lname from Student
where St_Age> AVG(st_age)

Select St_fname,st_lname from Student
where St_Age> (select AVG(st_age) from Student)

Select ins_name 
from instructor
where Ins_Id in (select dept_manager from Department where Dept_Manager is not null)

select St_Fname from Student
union all 
select Ins_Name from Instructor


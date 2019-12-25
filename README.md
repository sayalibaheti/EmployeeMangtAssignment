Simple MVC project to manage employee list

Screenshots folder conatins running project screenshots

Problem Statement:
Show list of employees with basic fields ID, name, age and marital status. 
Page should contain facility to search employee with salary , age and location.
There should be provision to delete employee record also on page shown at #1 above. 
This should be hard delete


//SQL script:


create table EMP
(
[EmpID] int NOT NULL,
  [LastName]  varchar(255) NOT NULL,
 [FirstName]  varchar(255) NOT NULL,
 [Age]  int,
 [MaritalStatus] varchar(255) NOT NULL,
 [Location] varchar(255) NOT NULL,
 [Salary] int,
  PRIMARY KEY ([EmpID])
);


insert into emp values
(1,'Baheti','Sayali',25,'Unmarried','Pune',60000),
(45,'Kumar','Dev',55,'Married','Nashik',560000),
(46,'Ghosla','Divya',55,'Married','Pune',560000)

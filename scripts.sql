IF OBJECT_ID (N'Employee', N'U') IS NOT NULL 
Begin
	Drop Table Employee
End

IF OBJECT_ID (N'EmployeePhone', N'U') IS NOT NULL 
Begin
	Drop Table EmployeePhone
End

IF OBJECT_ID (N'EmployeeAddress', N'U') IS NOT NULL 
Begin
	Drop Table EmployeeAddress
End


Create Table Employee
(
	EmployeeID int identity(1,1) not for replication not null,
	FirstName varchar(200),
	LastName varchar(200),
	DateOfBirth datetime,
	HireDate datetime
)



Create Table EmployeePhone
(
	EmployeePhoneID int identity(1,1) not for replication not null,
	EmployeeID int not null,
	PhoneArea varchar(5),
	Phone varchar(10),
	PhoneExt varchar(5)
)



Create Table EmployeeAddress
(
	EmployeeAddressID int identity(1,1) not for replication not null,
	EmployeeID int not null,
	StreetAddress varchar(100),
	City varchar(100),
	State varchar(2),
	ZipCode varchar(5)
)



Insert Into Employee
Select 'Tony', 'Stark', '1970-05-29', '2021-01-01'

Insert Into Employee
Select 'Peter', 'Parker', '2001-08-10', '2009-05-23'

Insert Into Employee
Select 'Steve', 'Rogers', '1918-07-04', '1976-12-30'

Insert Into Employee
Select 'Stephen', 'Strange', '1930-11-01', '1999-12-31'

Insert Into Employee
Select 'Wanda', 'Maximoff', '1989-01-21', '2022-03-13'


Insert Into EmployeePhone
Select 1, '111', '1111111', '111'

Insert Into EmployeePhone
Select 2, '222', '2222222', '222'

Insert Into EmployeePhone
Select 3, '333', '3333333', '333'

Insert Into EmployeePhone
Select 4, '444', '4444444', '444'

Insert Into EmployeePhone
Select 5, '555', '5555555', '555'



Insert Into EmployeeAddress
Select 1, '10880 Malibu Point', 'Malibu', 'CA', '90265'

Insert Into EmployeeAddress
Select 2, '20 Ingram Street', 'Queens', 'NY', '11375'

Insert Into EmployeeAddress
Select 3, '569 Leaman Place', 'Brooklyn', 'NY', '11202'

Insert Into EmployeeAddress
Select 4, '117A Bleecker Street', 'Port Jervis', 'NY', '12771'

Insert Into EmployeeAddress
Select 5, '2800 Sherwood Drive', 'Westview', 'NJ', '08801'
GO
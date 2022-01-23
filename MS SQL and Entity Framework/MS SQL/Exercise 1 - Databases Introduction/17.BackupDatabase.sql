--Problem 17
ALTER TABLE Employees
ADD FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
ALTER TABLE Employees
ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
ALTER TABLE Addresses
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)
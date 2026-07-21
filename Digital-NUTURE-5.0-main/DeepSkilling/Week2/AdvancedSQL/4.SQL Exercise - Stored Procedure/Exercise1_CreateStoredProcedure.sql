USE CognizantSQL;

CREATE TABLE EmployeeDetails (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO EmployeeDetails VALUES
(1,'Ujwala',50000),
(2,'Rishitha',60000);

DELIMITER $$

CREATE PROCEDURE GetEmployees()
BEGIN
    SELECT * FROM EmployeeDetails;
END $$

DELIMITER ;

CALL GetEmployees();
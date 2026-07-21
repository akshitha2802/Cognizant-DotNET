USE CognizantSQL;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    City VARCHAR(50)
);

INSERT INTO Customers VALUES
(1,'Ujwala','Hyderabad'),
(2,'Rishitha','Chennai'),
(3,'John','Mumbai'),
(4,'David','Delhi');

CREATE INDEX idx_customername
ON Customers(CustomerName);

SELECT *
FROM Customers
WHERE CustomerName='Ujwala';
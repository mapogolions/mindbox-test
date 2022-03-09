USE master
GO
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'MindboxTest'
)
CREATE DATABASE MindboxTest
GO

USE MindboxTest

DROP TABLE IF EXISTS dbo.ProductCategories
DROP TABLE IF EXISTS dbo.Products
DROP TABLE IF EXISTS dbo.Categories

CREATE TABLE dbo.Products
(
    ProductId INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.Categories
(
    CategoryId int IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.ProductCategories
(
    ProductId INT NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT Pk_ProductCategories_ProductIdCategoryId PRIMARY KEY (ProductId, CategoryId),
    CONSTRAINT Fk_ProductCategories_Products_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products (ProductId),
    CONSTRAINT FK_ProductCategories_Categories_CategoryId FOREIGN KEY (CategoryId) REFERENCES dbo.Categories (CategoryId)
)

INSERT INTO dbo.Products (ProductName)
VALUES ('foo'), ('bar'), ('baz')

INSERT INTO dbo.Categories (CategoryName)
VALUES ('cat1'), ('cat2'), ('cat3')

INSERT INTO dbo.ProductCategories (ProductId, CategoryId)
VALUES (1, 1), (1, 2), (2, 1)


SELECT prods.ProductName as [Product Name], tmp.CategoryName as [Category Name]
FROM dbo.Products as prods
LEFT JOIN
    (SELECT cats.CategoryId, cats.CategoryName, prodcats.ProductId FROM dbo.Categories as cats
    INNER JOIN dbo.ProductCategories as prodcats
    ON cats.CategoryId = prodcats.CategoryId) as tmp
ON prods.ProductId = tmp.ProductId


DROP TABLE IF EXISTS dbo.ProductCategories
DROP TABLE IF EXISTS dbo.Products
DROP TABLE IF EXISTS dbo.Categories

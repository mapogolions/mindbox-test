DROP TABLE IF EXISTS dbo.Products
DROP TABLE IF EXISTS dbo.Categories
DROP TABLE IF EXISTS dbo.ProductsCategories

CREATE TABLE dbo.Products
(
    ProductId INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.Categories
(
    CategoriesId int IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.ProductsCategories
(
    ProductId INT NOT NULL,
    CategoryId INT NOT NULL
    CONSTRAINT Pk_ProductsCategories_ProductIdCategoryId PRIMARY KEY (ProductId, CategoryId)
)

INSERT INTO dbo.Products (ProductName)
VALUES ('foo'), ('bar'), ('baz')

INSERT INTO dbo.Categories (CategoryName)
VALUES ('cat1'), ('cat2'), ('cat3')

INSERT INTO dbo.ProductsCategories (ProductId, CategoryId)
VALUES (1, 1), (1, 2), (2, 1)


SELECT prods.ProductName as [Product Name], tmp.CategoryName as [Category Name]
FROM dbo.Products as prods
LEFT JOIN
    (SELECT * FROM dbo.Categories as cats
    INNER JOIN dbo.ProductsCategories as prodcats
    ON cats.CategoriesId = prodcats.CategoryId) as tmp
ON prods.ProductId = tmp.ProductId


DROP TABLE IF EXISTS dbo.Products
DROP TABLE IF EXISTS dbo.Categories
DROP TABLE IF EXISTS dbo.ProductsCategories

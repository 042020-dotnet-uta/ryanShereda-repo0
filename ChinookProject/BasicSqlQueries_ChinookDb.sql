-- basic exercises (Chinook database)

-- 1. list all customers (full names, customer ID, and country) who are not in the US

	SELECT CustomerID, FirstName, LastName, Country 
	FROM dbo.Customer
	WHERE Country != 'USA';

-- 2. list all customers from brazil

	Select *
	FROM dbo.Customer
	WHERE Country = 'Brazil';

-- 3. list all sales agents

	SELECT * 
	FROM dbo.Employee
	WHERE Title LIKE '%Sales%Agent%';

-- 4. show a list of all countries in billing addresses on invoices.

	SELECT DISTINCT BillingCountry
	FROM dbo.Invoice

-- 5. how many invoices were there in 2009, and what was the sales total for that year?

	SELECT COUNT(InvoiceID) AS 'Number of Invoices', SUM(Total) AS 'Total of Invoices' 
	FROM dbo.Invoice
	WHERE YEAR(InvoiceDate) = 2009;

-- 6. how many line items were there for invoice #37?

	SELECT COUNT(InvoiceLineId) AS 'Number of Line Items'
	FROM dbo.InvoiceLine
	WHERE InvoiceID = 37;

-- 7. how many invoices per country?

	SELECT BillingCountry AS 'Country', COUNT(InvoiceID) AS 'Number of Invoices'
	FROM dbo.Invoice
	GROUP BY BillingCountry;

-- 8. show total sales per country, ordered by highest sales first.

	SELECT BillingCountry AS 'Country', SUM(Total) AS 'Invoice Total'
	FROM dbo.Invoice
	GROUP BY BillingCountry
	ORDER BY SUM(Total) DESC;

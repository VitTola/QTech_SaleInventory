ALTER TABLE [dbo].[IncomeExpenses] 
ALTER COLUMN [Note] NVARCHAR(2000) COLLATE Khmer_100_CI_AI_SC_UTF8
GO
ALTER TABLE [dbo].[Sales] 
ALTER COLUMN [InvoiceNo] NVARCHAR(200)
GO
ALTER TABLE [dbo].[Sales] 
ALTER COLUMN [PurchaseOrderNo] NVARCHAR(200)
--CREATE INDEX ON QTech_Sale
CREATE INDEX IX_EmployeeBills ON [dbo].[EmployeeBills]([DoDate])
CREATE INDEX IX_Invoices ON [dbo].[Invoices]([InvoicingDate],[CustomerId],[SiteId])
CREATE INDEX IX_InvoiceDetails ON [dbo].[InvoiceDetails]([InvoiceId],[SaleId])
CREATE INDEX IX_IncomeExpense ON [dbo].[IncomeExpenses]([DoDate])
CREATE INDEX IX_POProductPrices ON [dbo].[POProductPrices]([PurchaseOrderId])
CREATE INDEX IX_PurchaseOrders ON [dbo].[PurchaseOrders]([CustomerId])
CREATE INDEX IX_Sales ON [dbo].[Sales]([SaleDate],[InvoiceNo],[SiteId],[CompanyId])
CREATE INDEX IX_SaleDetails ON [dbo].[SaleDetails]([SaleId])


drop index if exists [dbo].[EmployeeBills].IX_EmployeeBills 
drop index if exists [dbo].[Invoices].IX_Invoices 
drop index if exists [dbo].[InvoiceDetails].IX_InvoiceDetails 
drop index if exists [dbo].[IncomeExpenses].IX_IncomeExpense 
drop index if exists [dbo].[POProductPrices].IX_POProductPrices
drop index if exists [dbo].[PurchaseOrders].IX_PurchaseOrders 
drop index if exists [dbo].[Sales].IX_Sales 
drop index if exists [dbo].[SaleDetails].IX_SaleDetails 

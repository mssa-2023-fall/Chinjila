Create View vw_supplier_item_count as
SELECT SupplierID,Count(distinct StockItemName) as ItemName
From Warehouse.StockItems
Group by SupplierID

select * from dbo.vw_supplier_item_count;
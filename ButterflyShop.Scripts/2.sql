-- Example:
-- if object_id(N'dbo.StoreProcedureName') is null
--   exec('create procedure dbo.StoreProcedureName as set nocount on;');
-- go
-- 
-- -- ============================================================================
-- -- Example    : exec dbo.StoreProcedureName
-- -- Author     : Nikita Dermenzhi
-- -- Date       : 25/07/2019
-- -- Description: —
-- -- ============================================================================
-- 
-- alter procedure dbo.StoreProcedureName -- exec dbo.StoreProcedureName  
-- (  
--     @Param1 as int = null  
--   , @Param2 as varchar(100) = null  
-- )  
-- as  
-- begin  
--   
-- 
-- 
-- end;
-- go

if object_id(N'dbo.GetItemsInfo') is null
  exec('create procedure dbo.GetItemsInfo as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetItemsInfo
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetItemsInfo -- exec dbo.GetItemsInfo 4, 0, 1
(
  @count int = 8,
  @newItems bit = 1,
  @saleItems bit = 0
)
as  
begin  
  
  select top (@count)
    p.Id as ProductId
  , i.Id as ItemId
  , p.Name as Name
  , p.Description as Description
  , i.Price as Price
  , i.OldPrice as OldPrice
  , pimg.Image
    from dbo.Products p
    join dbo.Items i on i.ProductId = p.Id
    outer apply
    (
      select top 1 * 
        from dbo.ProductImages pim where pim.ProductId = p.Id
    ) pimg
    where p.IsDeleted = 0 
      and i.IsDeleted = 0
      and (@saleItems = 0 
        or (@saleItems = 1 
        and i.OldPrice is not null))
    order by
      case when @newItems = 1 then p.DateCreated end desc
    , newid() 
end;
go
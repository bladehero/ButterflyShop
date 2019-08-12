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
-- alter procedure dbo.StoreProcedureName
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

use ButterflyShopDatabase
go

if object_id(N'dbo.GetItemsInfo') is null
  exec('create procedure dbo.GetItemsInfo as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetItemsInfo 4, 1
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetItemsInfo
(
  @count int = 8,
  @newItems bit = 0,
  @saleItems bit = 0
)
as  
begin  
  
  select top (@count) 
    p.Id as ProductId
  , i.Id as ItemId
  , p.Name
  , p.Description
  , i.Price
  , i.OldPrice
  , pimg.Image
    from dbo.Products p
    join (select i1.* 
            from dbo.Items i1
            join (select min(Id) as Id
                       , min(Price) as Price 
                       from dbo.Items 
                       group by ProductId) i2 
            on i1.Id = i2.Id) i 
          on i.ProductId = p.Id
    outer apply
    (
      select top 1 * 
        from dbo.ProductImages pim where pim.ProductId = p.Id
                                     and pim.IsDeleted = 0
    ) pimg
    where p.IsDeleted = 0 
      and i.IsDeleted = 0
      and (isnull(@saleItems, 0) = 0
        or (@saleItems = 1 
        and i.OldPrice is not null))
    order by
      case when isnull(@newItems, 0) = 1 then p.DateCreated end desc
    , newid() 
end;
go

declare @id int = 1;


if object_id(N'dbo.CategoriesForProduct') is null
  exec('create procedure dbo.CategoriesForProduct as set nocount on;');
go
 
 -- ============================================================================
 -- Example    : exec dbo.CategoriesForProduct 5
 -- Author     : Nikita Dermenzhi
 -- Date       : 25/07/2019
 -- Description: —
 -- ============================================================================
 
alter procedure dbo.CategoriesForProduct
(  
    @productId as int
)  
as  
begin

with CategoryParents as 
(
  select *
    from Categories
    where Id in (
                  select c.Id
                    from Categories c
                    join CategoryProducts cp on cp.CategoryId = c.Id
                    join Products p on p.Id = cp.ProductId
                    where p.Id = @ProductId 
                      and c.IsDeleted = 0
                )
  union all
  select c.*
    from Categories c
    inner join CategoryParents cp on cp.ParentId = c.Id
)
select *
  from CategoryParents
  order by Id
 
end;
go

if object_id(N'dbo.GetProductImages') is null
  exec('create procedure dbo.GetProductImages as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetProductImages 1
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetProductImages
(  
    @productId as int
)  
as  
begin  
  
  select pim.* 
    from Products p
    join ProductImages pim on pim.ProductId = p.Id
    where p.Id = @productId
      and p.IsDeleted = 0
      and pim.IsDeleted = 0

end;
go

if object_id(N'dbo.GetItemWithParameters') is null
  exec('create procedure dbo.GetItemWithParameters as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetItemWithParameters 7
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetItemWithParameters 
(  
    @productId as int
)  
as  
begin  
  
  select i.Id as ItemId
       , i.Price
       , i.OldPrice
       , params.Parameters
    from Products p
    join Items i on i.ProductId = p.Id
  cross apply
  (
    select top 1 string_agg(concat(op.Name, ' - ', opp.Value), ', ') as Parameters
      from OptionalParameterProducts opp
      join OptionalParameters op on op.Id = opp.OptionalParameterId
      where opp.ItemId = i.Id
        and opp.IsDeleted = 0
        and op.IsDeleted = 0
  ) params
    where p.Id = @productId
      and p.IsDeleted = 0
      and i.IsDeleted = 0
    order by i.Price

end;
go

if (object_ID('dbo.MD5HashPassword') is not null)
   drop function dbo.MD5HashPassword
go

-- ============================================================================
-- Example    : select dbo.MD5HashPassword('qwe')
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

create function dbo.MD5HashPassword(@password nvarchar(100))
returns char(32)
as 
begin 
  return convert(varchar(32), hashbytes('MD5', @password), 2) 
end
go


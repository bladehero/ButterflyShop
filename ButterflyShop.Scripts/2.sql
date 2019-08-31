﻿-- Example:
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
-- Example    : exec dbo.GetItemsInfo null, null, null, 5
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetItemsInfo
(
  @count int = 8,
  @newItems bit = 0,
  @saleItems bit = 0,
  @userId int = null
)
as  
begin  
  if @count is not null
    select top (@count) 
      p.Id as ProductId
    , i.Id as ItemId
    , p.BrandId
    , p.Name
    , p.Description
    , i.Price
    , i.OldPrice
    , pimg.Image
    , case 
        when isnull(fp.IsDeleted, 1) = 1 then 0
        else 1
      end as Favourite
      from dbo.Products p
      left join dbo.FavouriteProducts fp on fp.ProductId = p.Id and fp.UserId = @userId
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
  else
    select
      p.Id as ProductId
    , i.Id as ItemId
    , p.Name
    , p.Description
    , i.Price
    , i.OldPrice
    , pimg.Image
    , case 
        when isnull(fp.IsDeleted, 1) = 1 then 0
        else 1
      end as Favourite
      from dbo.Products p
      left join dbo.FavouriteProducts fp on fp.ProductId = p.Id and fp.UserId = @userId
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
end;
go


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

;with CategoryParents as 
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
                      and cp.IsDeleted = 0
                      and p.IsDeleted = 0
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

if (object_ID('dbo.GetUserRoleId') is not null)
   drop function dbo.GetUserRoleId
go

-- ============================================================================
-- Example    : select dbo.GetUserRoleId(N'Пользователь')
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

create function dbo.GetUserRoleId(@role nvarchar(100) null)
returns int
as 
begin 
  return (select top 1 r.Id from dbo.Roles r where r.Name = @role)
end
go



if object_id(N'dbo.GetCategoryHierarchy') is null
  exec('create procedure dbo.GetCategoryHierarchy as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetCategoryHierarchy 2
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetCategoryHierarchy 
(  
    @toLevelId as int = null
)  
as  
begin
 
  ;with CategoryHierarchy as 
  (
    select *
      , 0 as Level
      , cast(row_number() over(partition by ParentId order by Name) as varchar(max)) as Path 
      , 1 as IsParent
      from Categories
      where ParentId is null
    union all
    select c.*
      , Level + 1
      , Path + cast(row_number() over(partition by c.ParentId order by c.Name) as varchar(max))
      , case
          when exists (select * from Categories where ParentId = c.Id)
          then 1
          else 0
        end as IsParent
      from Categories c
      inner join CategoryHierarchy ch on ch.Id = c.ParentId
  )
  select ch.Id
       , ch.Name
       , ch.ParentId
       , ch.DateCreated
       , ch.DateModified
       , ch.IsDeleted
       , ch.Level
       , ch.IsParent
    from CategoryHierarchy ch
    where (@toLevelId is null or ch.Level <= @toLevelId)
    order by Path

end;
go

if object_id(N'dbo.GetFavouriteProductInfo') is null
  exec('create procedure dbo.GetFavouriteProductInfo as set nocount on;');
go
 
 -- ============================================================================
 -- Example    : exec dbo.GetFavouriteProductInfo 5
 -- Author     : Nikita Dermenzhi
 -- Date       : 25/07/2019
 -- Description: —
 -- ============================================================================
 
alter procedure dbo.GetFavouriteProductInfo
(  
  @userId int = null
)  
as  
begin

  select
        p.Id as ProductId
      , i.Id as ItemId
      , p.Name
      , p.Description
      , i.Price
      , i.OldPrice
      , pimg.Image
      , 1 as Favourite
        from dbo.Products p
        join dbo.FavouriteProducts fp on fp.ProductId = p.Id and fp.UserId = @userId
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
          and fp.IsDeleted = 0
 
end;
go

if (object_ID('dbo.GetCategoryForProducts') is not null)
   drop function dbo.GetCategoryForProducts
go

-- ============================================================================
-- Example    : select * from dbo.GetCategoryForProducts(5)
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================
create function dbo.GetCategoryForProducts(@productId as int) 
    returns @categories table
    (
        Id int not null
      , Name nvarchar(100)
      , ParentId int
      , DateCreated datetime
      , DateModified datetime
      , IsDeleted bit
    )
as
begin
  ;with CategoryParents as 
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
                        and cp.IsDeleted = 0
                        and p.IsDeleted = 0
                  )
    union all
    select c.*
      from Categories c
      inner join CategoryParents cp on cp.ParentId = c.Id
  )
  insert into @categories
    select *
      from CategoryParents
      order by Id

  return
end
go

if object_id(N'dbo.SearchItemInfo') is null
  exec('create procedure dbo.SearchItemInfo as set nocount on;');
go
 
 -- ============================================================================
 -- Example    : exec dbo.SearchItemInfo 5, 4, 1, N'Помада', 150, 200; exec dbo.SearchItemInfo null, null, null, N'Мужская'
 -- Author     : Nikita Dermenzhi
 -- Date       : 25/07/2019
 -- Description: —
 -- ============================================================================
 
alter procedure dbo.SearchItemInfo
(  
  @userId int = null,
  @categoryId int = null,
  @brandId int = null,
  @search nvarchar(100) = null,
  @minPrice float = null,
  @maxPrice float = null
)  
as  
begin

  select
      p.Id as ProductId
    , i.Id as ItemId
    , p.Name
    , p.Description
    , i.Price
    , i.OldPrice
    , pimg.Image
    , case 
        when isnull(fp.IsDeleted, 1) = 1 then 0
        else 1
      end as Favourite
      from dbo.Products p
      left join dbo.FavouriteProducts fp on fp.ProductId = p.Id and fp.UserId = @userId
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
      outer apply
      (
        select cpp.* 
          from dbo.GetCategoryForProducts(p.Id) as cpp
          where cpp.Id = @categoryId
      ) cfp
      where p.IsDeleted = 0 
        and i.IsDeleted = 0
        and (@categoryId is null or cfp.Id is not null) -- Filter by category 
        and (@brandId is null or p.BrandId = @brandId)  -- Filter by brand
        and (@search is null 
             or exists(
                        select *
                          from string_split(@search, ' ') es
                          left join Products ep on ep.Id = p.Id
                          left join Brands eb on eb.Id = ep.BrandId
                          outer apply
                          (
                            select cpp.* 
                              from dbo.GetCategoryForProducts(p.Id) as cpp
                          ) ecfp
                          where ep.Name like concat('%', es.value, '%')
                             or eb.Name like concat('%', es.value, '%')
                             or ecfp.Name like concat('%', es.value, '%')
                      )
            )                                           -- Filter by search
        and (@minPrice is null or i.Price >= @minPrice)
        and (@maxPrice is null or i.Price <= @maxPrice)
      order by
        p.DateCreated
 
end;
go

if (object_ID('dbo.GetProductNumericValueByOption') is not null)
   drop function dbo.GetProductNumericValueByOption
go

-- ============================================================================
-- Example    : select dbo.GetProductNumericValueByOption('MinPrice')
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

create function dbo.GetProductNumericValueByOption(@option char(10))
returns float
as 
begin
  declare @value float = null;
  if (@option = 'MinPrice')
    select @value = min(i.Price) from dbo.Items i
  if (@option = 'MaxPrice')
    select @value = max(i.Price) from dbo.Items i
  return @value;  
end
go

if object_id(N'dbo.GetCartItemsInfo') is null
  exec('create procedure dbo.GetCartItemsInfo as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.GetCartItemsInfo 1
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.GetCartItemsInfo 
(  
    @userId as int
)  
as  
begin

  select
      p.Id as ProductId
    , i.Id as ItemId
    , p.Name
    , round(i.Price, 2) as Price
    , c.Quantity
    , round(i.Price * c.Quantity, 2) as Total
    , pimg.Image
      from dbo.Cart c
      join dbo.Items i on i.Id = c.ItemId
      join dbo.Products p on p.Id = i.ProductId
      outer apply
      (
        select top 1 * 
          from dbo.ProductImages pim where pim.ProductId = p.Id
                                       and pim.IsDeleted = 0
      ) pimg
      where c.UserId = @userId
        and c.IsDeleted = 0
        and p.IsDeleted = 0 
        and i.IsDeleted = 0
      order by c.DateModified

end;
go

if object_id(N'dbo.MergeItemToCart') is null
  exec('create procedure dbo.MergeItemToCart as set nocount on;');
go

-- ============================================================================
-- Example    : exec dbo.MergeItemToCart 1, 7, 2
-- Author     : Nikita Dermenzhi
-- Date       : 25/07/2019
-- Description: —
-- ============================================================================

alter procedure dbo.MergeItemToCart 
(  
    @userId as int
  , @itemId as int
  , @quantity as int = null
  , @isDeleted as bit = 0
)  
as  
begin

  merge dbo.Cart as trg
    using 
    (
      select @itemId
           , @userId
           , @quantity
           , @isDeleted
    ) as src (ItemId, UserId, Quantity, IsDeleted)
    on (trg.ItemId = src.ItemId and trg.UserId = src.UserId)
    when matched then
      update set trg.Quantity = iif(trg.IsDeleted = 0, iif(src.Quantity is null, trg.Quantity + 1, src.Quantity), iif(src.Quantity is null, 1, src.Quantity)) 
               , trg.IsDeleted = src.IsDeleted
               , trg.DateModified = getdate()
    when not matched then
      insert (ItemId, UserId, Quantity)
      values (src.ItemId, src.UserId, iif(src.Quantity is not null and src.Quantity > 0, src.Quantity, 1))
    ;

end;
go
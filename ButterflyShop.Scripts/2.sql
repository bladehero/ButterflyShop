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
 
end;
go
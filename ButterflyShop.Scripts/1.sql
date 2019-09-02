use ButterflyShopDatabase;
go

insert Brands(Name, Country, Logo, BackgroundImage) values
  (N'TianDe', N'Россия', N'tiande-logo.png', N'tiande-bg.png')
, (N'Amrita', N'Индия', N'amrita-logo.png', N'amrita-bg.png')
, (N'Unice', N'Украина', N'unice-logo.png', N'unice-bg.png')
, (N'Flomar', N'Турция', N'flomar-logo.png', N'flomar-bg.png')
, (N'Біоліка', N'Украина', N'biolika-logo.png', N'biolika-bg.png')
, (N'Thalia', N'Турция', N'thalia-logo.png', N'thalia-bg.png')

insert Products(Name, BrandId, Description) values
  (N'Тушь для ресниц "Супердлина. Акцент"', 1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
, (N'Тушь для ресниц "Экстремальная длина"', 1, N'It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.')
, (N'Бронзирующая пудра для лица - Avon True Bronzing Pearls', 1, N'It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
, (N'Avon Far Away Infinity - Парфюмированная вода', 1, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.')
, (N'Губная помада "Ультра" - Avon Ultra Color Lipstick', 1, N'Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance.')
, (N'Двухцветные тени для век - Oriflame The ONE Colour Match', 2, N'The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.')
, (N'Oriflame Women''s Collection Mysterial Oud - Туалетная вода', 2, N'The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.')
, (N'Oriflame Eternal Man - Туалетная вода (пробник)', 2, N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content here'', making it look like readable English.')
, (N'Oriflame Born to Fly For Him - Туалетная вода (пробник)', 2, N'Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).')

insert into ProductImages(ProductId, Image) values
  (1,'Tush_1.jpg')

insert into Items(ProductId, Price, OldPrice) values
  (1,80, null)
, (2,100, null)
, (3,200, null)
, (4,250, null)
, (5,150, null)
, (6,220, null)
, (7,300, 350)
, (7,500, 600)
, (8,500, null)
, (9,600, null)

insert Categories(Name, ParentId) values
  (N'Для лица', null) -- 1
, (N'Проблемная кожа', 1) -- 2
, (N'Для молодой кожи', 1) -- 3
, (N'Для зрелой кожи', 1) -- 4
, (N'Для тела', null) -- 5
, (N'Антицелюлитные средства', 5) -- 6
, (N'Уход за телом', 5) -- 7
, (N'Для полости рта', null) -- 8
, (N'Для волос', null) -- 9
, (N'Для детей', null) -- 10
, (N'Здоровье', null) -- 11
, (N'Женское здоровье', 11) -- 12
, (N'Мужское здоровье', 13) -- 13
, (N'Питание', null) -- 14
, (N'Масла', 14) -- 15
, (N'Шроты', 14) -- 16
, (N'Коктейли', 14) -- 17
, (N'Кунжутики и батончики', 14) -- 18
, (N'Декоративная косметика', null) -- 19
, (N'Парфюмерия', null) -- 20
, (N'Фиточаи', null) -- 21
, (N'Фитопродукты', null) -- 22
, (N'Детокс организма', 23) -- 23
, (N'Антиаразитарные фитопрепараты', 23) -- 24
, (N'Витамины и минералы', 23) -- 25
, (N'Поддержка иммунитета', 23) -- 26
, (N'Здоровая кожа', 23) -- 27
, (N'Дыхательная система', 23) -- 28
, (N'Сердечно-сосудистая система', 23) -- 29
, (N'Опорно-двигательная система', 23) -- 30
, (N'Нервная система', 23) -- 31
, (N'Пищеварительная система', 23) -- 32
, (N'Почки и мочеполовая система', 23) -- 33
, (N'Эндокринная система', 23) -- 34
, (N'Здоровье глаз', 23) -- 35
, (N'Для дома', null) -- 36
, (N'Процедуры', null) -- 37
, (N'Cертификаты', null) -- 38

insert CategoryProducts(ProductId, CategoryId) values
  (1,3)
, (2,3)
, (3,4)
, (4,5)
, (5,6)
, (6,4)
, (7,5)
, (8,7)
, (9,7)

insert Characteristics(Name) values
  (N'Пол')              -- 1
, (N'Классификация')    -- 2
, (N'Возраст')          -- 3
, (N'Объем')            -- 4
, (N'Время применения') -- 5
, (N'Назначение')       -- 6
, (N'Тип кожи')         -- 7
, (N'Тип аромата')      -- 8

insert CharacteristicProducts(ProductId, CharacteristicId, Value) values
  (1, 1, N'для женщин')
, (1, 4, N'10мл.')
, (2, 1, N'для женщин')
, (2, 2, N'Премиум')
, (2, 4, N'15мл.')
, (3, 1, N'для женщин')
, (3, 3, N'30+')
, (3, 4, N'20мл.')
, (4, 1, N'для женщин')
, (4, 4, N'30мл, 50мл, 100мл.')
, (4, 8, N'Цветочный')
, (5, 1, N'для женщин')
, (5, 2, N'Масс-маркет')
, (5, 4, N'15мл.')
, (6, 1, N'для женщин')
, (6, 3, N'18+')
, (6, 4, N'20мл.')
, (7, 1, N'для женщин')
, (7, 4, N'50мл, 100мл.')
, (7, 8, N'Цветочный')
, (8, 1, N'для мужчин')
, (8, 4, N'40мл, 50мл, 100мл.')
, (8, 8, N'Морские ноты')
, (9, 1, N'для мужчин')
, (9, 4, N'20мл, 50мл, 80мл.')
, (9, 8, N'Древесный')

insert OptionalParameters(Name) values
  (N'Объем')
, (N'Цвет')
, (N'Тип кожи')

insert OptionalParameterProducts(ItemId, OptionalParameterId, Value) values
  (7,1,N'50мл.')
, (8,1,N'100мл.')

insert Roles(Name) values
  (N'Пользователь')
, (N'Администратор')

insert OrderDeliveryTypes(Type) values
  (N'Новая Почта')
, (N'Justin')
, (N'Доставка по Одессе')

insert OrderPaymentTypes(Type) values
  (N'Наложный')
, (N'На карту')

insert OrderStatuses(Status) values
  (N'В обработке')
, (N'Комплектуется')
, (N'Отправлен')
, (N'Выполнен')
, (N'Отменен')
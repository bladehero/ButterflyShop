use FleaMarketDatabase;
go

insert Brands(Name, Country, Logo, BackgroundImage) values
  (N'DC', N'Америка', N'dc.png', N'dc.png')                        -- 1
, (N'Marvel', N'Америка', N'marvel.png', N'marvel.png')            -- 2
, (N'Doctor Who', N'Англия', N'doctor-who.png', N'doctor-who.png') -- 3
, (N'Starwars', N'Америка', N'starwars.png', N'starwars.png')      -- 4

insert Products(Name, BrandId, Description) values
/*1*/   (N'The Child Real Moves Plush by Mattel – Star Wars: The Mandalorian', 4, N'Embrace your guardian skills when you assume control of the Child from Star Wars: The Mandalorian. Using the wrist strap remote control unit with its joystick, you can command the creature affectionately known as ''Baby Yoda.'' Make him follow you, spin around, move his ears, head and arms, play hide and seek, make sounds, and more.')
/*2*/,  (N'Darth Maul Collector''s Edition Action Figure by Diamond Select – Star Wars – 7''', 4, N'One of the Star Wars saga''s deadliest Sith Lords, Darth Maul is now the ultimate collectible with this 7'' scale action figure featuring detailed paint and sculpting. Along with the display-ready packaging, this figure comes with the Sith''s signature twin-bladed lightsaber with removable blades, alternate hands, and more.')
/*3*/,  (N'Spider-Man: Far From Home Marvel Gallery Diorama by Diamond Select', 2, N'In his Iron Spider armor, Peter Parker strikes a dynamic pose on the faux wood base of this diorama that''s accented with webbing and the evidence of an action-packed battle. Highly detailed and vividly colored, it''s a must-have collectible for any fan of the wall-crawling wonder.')
/*4*/,  (N'Gamorrean Fighter Funko Pop! Vinyl Bobble-Head – Star Wars: The Mandalorian', 4, N'One of Jabba the Hutt''s notorious guards is looking menacing as this Funko Pop! Vinyl Bobble-Head. Inspired by the Disney+ series Star Wars: The Mandalorian, this Gamorrean Fighter will make a tough addition to your collection.')
/*5*/,  (N'BB-8 Interactive Remote Control Droid – Star Wars', 4, N'Direct from a galaxy far, far away comes this new pre-built version of the BB-8 interactive droid from Droid Depot at Star Wars: Galaxy’s Edge. The Star Wars character features authentic lights, sounds, and integrated Bluetooth technology so it will always be at your command.')
/*6*/,  (N'Droid Depot Circuitry T-Shirt for Kids – Star Wars: Galaxy''s Edge', 4, N'If you love droid engineering, you''ll want to keep this circuitry design close to your heart. Rendered on a soft all-cotton tee, the screen art of an R-series astromech droid on the chest is complemented by the Droid Depot logo on the sleeve and Aurebesh text inside the back of the neck.')
/*7*/,  (N'First Avenger Smartwatch by Garmin – Special Edition', 2, N'The First Avenger comes to life with this special edition smartwatch by Garmin. Featuring midnight blue with stainless steel hardware, along with Captain America''s vibranium shield printed on the lens, it also includes character-themed watch faces and more. From smartwatch functionality to the First Avenger app experience, every detail is designed with your favorite hero in mind.')
/*8*/,  (N'Hulk Pewter Mini Figurine by Royal Selangor', 2, N'Provoked, Bruce Banner''s exposure to gamma rays sets off a chain reaction, transforming him into the rampaging Hulk. Created in pewter by Royal Selangor, the stylized mini figurine stands just over 2'' tall, but packs a big punch for a little guy.')
/*9*/,  (N'POP! Doctor Who Dalek Vinyl Figure', 3, N'All this POP! Doctor Who Dalek Vinyl Figure really wants to do, is live out his dream of EXTERMINATE! EXTERMINATE! EXTERMINATE! It''s up to you whether or not this Dalek gets to fulfill his desire. Keep this Funko figure on your desk at your office if you want to keep a close eye on it because it''ll try to exterminate the doctor the first chance it gets!')
/*10*/, (N'Чашка Тардис Подарок Доктор Кто', 3, N'Керамическая, принт устойчивый, но мыть лучше руками. Объем - 330 мл. Производство - Украина.')
/*11*/, (N'Фігурка Funko Pop Фанко Поп Tardis Тардіс Будка Doctor Who Доктор Хто 15 см DW Т 227.2', 3, N'Фігурка Funko Pop Фанко Поп Тардіс Доктор Хто Doctor Who Tardis 15 см DW Т 227.2 Опис: Розмір фігурки: 15 см Матеріал: вініл Серія: Funko Pop Doctor Who Упаковка, колекційна коробка 20.0 х 16.0 х 14.0 см')
/*12*/, (N'DC COMICS NEW 52 JUSTICE LEAGUE ACTION FIGURE 7 PACK BOX SET', 1, N'THE MOST POWERFUL HEROES IN THE UNIVERSE, TOGETHER IN ONE BOX SET!   Superman, Batman, Wonder Woman, Green Lantern, The Flash, Aquaman, and Cyborg')
/*13*/, (N'Оригінальна дитяча фігурка Людина-Яструб 15 см DC Comics Multiverse Hawkman DWM57', 1, N'Оригінальна дитяча фігурка Людина-Яструб 15 см DC Comics Multiverse Hawkman DWM57')
/*14*/, (N'HARLEY QUINN RED, WHITE & BLACK: HARLEY QUINN BY J. SCOTT CAMPBELL', 1, N'Based on one of the variant covers for Harley’s Little Black Book #1, this charmingly delightful statue really showcases J. Scott Campbell’s recognizable art style. Don’t miss your chance to add this popular artist and character to your collection today.')
/*15*/, (N'The Marvel Book', 2, N'Одна книга Marvel, которая пригодится каждому. Если вы хотите понять вселенную Marvel Comics во всей ее витиеватой красе, The Marvel Book - единственная книга, которая поможет вам в этом. Это уникальное исследование обширной мультивселенной Marvel Comics от ее зарождения до бесконечности.')

insert into ProductImages(ProductId, Image) values
  (1,  N'The Mandalorian.jpg')
, (2,  N'Darth Maul.jpg')
, (3,  N'Spider-Man.jpg')
, (4,  N'Gamorrean Fighter.jpg')
, (5,  N'BB-8.jpg')
, (6,  N'Droid Depot Circuitry T-Shirt.jpg')
, (7,  N'First Avenger Smartwatch by Garmin.jpg')
, (8,  N'Hulk Pewter Mini Figurine.jpg')
, (9,  N'pop-doctor-who-dalek-vinyl-figure.jpg')
, (10, N'Чашка Тардис.jpg')
, (11, N'Фігурка Funko Pop Фанко Поп Tardis.jpg')
, (12, N'DC COMICS NEW 52 JUSTICE LEAGUE AF 7 PK BOX SET.jpg')
, (13, N'Оригінальна дитяча фігурка Людина-Яструб.jpg')
, (14, N'HARLEY QUINN RED.jpg')
, (15, N'The Marvel Book.jpg')

insert into Items(ProductId, Price, OldPrice) values
  (1, 1099, null)	  						 -- 1
, (2, 999.90, null)	  						 -- 2
, (2, 899.90, null)	  						 -- 3
, (2, 899.90, null)	  						 -- 4
, (3, 899.90, null)	  						 -- 5
, (4, 899.90, null)   						 -- 6
, (5, 2545.35, 2800)  						 -- 7
, (6, 659.9, 890)	  						 -- 8
, (6, 559.9, null)	  						 -- 9
, (7, 4500, null)	  						 -- 10
, (8, 799, null)	  						 -- 11
, (9, 750, null)	  						 -- 12
, (10, 349, null)	  						 -- 13
, (11, 1209, null)	  						 -- 14
, (12, 507.35, null)	  				     -- 15
, (13, 878, null)	  						 -- 16
, (14, 655, null)	  						 -- 17
, (15, 750, null)	  						 -- 18

insert Categories(Name, ParentId) values
  (N'Фигурки', null)     -- 1
, (N'Одежда', null)      -- 2
, (N'Посуда', null)      -- 3
, (N'Комиксы', null)     -- 4
, (N'Техника', null)     -- 5

insert CategoryProducts(ProductId, CategoryId) values
  (1, 1)
, (2, 1)
, (3, 1)
, (4, 1)
, (5, 1)
, (6, 2)
, (7, 5)
, (8, 1)
, (9, 1)
, (10,3)
, (11,1)
, (12,1)
, (13,1)
, (14,1)
, (15,4)

insert Characteristics(Name) values
  (N'Размеры')          -- 1
, (N'Материал')         -- 2
, (N'Цвет')             -- 3

insert OptionalParameters(Name) values
  (N'Размеры')
, (N'Материал')
, (N'Цвет')

insert OptionalParameterProducts(ItemId, OptionalParameterId, Value) values
  (2, 2, N'Темно-зеленый')
, (3, 2, N'Салатовый')
, (4, 2, N'Коричневый')
, (8, 1, N'M')
, (9, 1, N'L')

insert Roles(Name) values
  (N'Пользователь')
, (N'Администратор')

insert OrderDeliveryTypes(Type) values
  (N'Новая Почта')
, (N'Justin')
, (N'Самовывоз')

insert OrderPaymentTypes(Type) values
  (N'Наложный')
, (N'На карту')

insert OrderStatuses(Status) values
  (N'В обработке')
, (N'Комплектуется')
, (N'Отправлен')
, (N'Выполнен')
, (N'Отменен')

insert ContactInfo(City, Address, Phones, TimeTable, GoogleUrl) values
  (N'г. Одесса', N'Сегедская ул., 15Б', N'+38(099)1112323', N'<b>Пн - Сб:</b> 9:00 – 18:00;<b>Вс:</b> 10:00 - 15:00', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d971.9313377219876!2d30.74403807282682!3d46.44797596731911!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40c633c3b623c30b%3A0xa49cd5dc3ae654d6!2zMTVCLCDQodC10LPQtdC00YHQutCw0Y8g0YPQuy4sIDE10JEsINCe0LTQtdGB0YHQsCwg0J7QtNC10YHRgdC60LDRjyDQvtCx0LvQsNGB0YLRjCwgNjUwMDA!5e0!3m2!1sru!2sua!4v1616446396266!5m2!1sru!2sua')


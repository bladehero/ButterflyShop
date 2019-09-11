﻿use ButterflyShopDatabase;
go

insert Brands(Name, Country, Logo, BackgroundImage) values
  (N'TianDe', N'Россия', N'tiande-logo.png', N'tiande-bg.png')      -- 1
, (N'Amrita', N'Индия', N'amrita-logo.png', N'amrita-bg.png')       -- 2
, (N'Unice', N'Украина', N'unice-logo.png', N'unice-bg.png')        -- 3
, (N'Flomar', N'Турция', N'flomar-logo.png', N'flomar-bg.png')      -- 4
, (N'Біоліка', N'Украина', N'biolika-logo.png', N'biolika-bg.png')  -- 5
, (N'Thalia', N'Турция', N'thalia-logo.png', N'thalia-bg.png')      -- 6

insert Products(Name, BrandId, Description) values
/*1*/  (N'Экстракт Фукуса', 5, N'Форма выпуска: экстракт жидкий.Продукт пищевой функциональный.Экстракт фукуса оказывает противовоспалительное, ранозаживляющее, регенерирующее, антибактериальное, болеутоляющее, седативное, успокаивающее, иммуностимулирующее, мочегонное, желчегонное, детоксикационное, антисклеротическое, антикоагулянтное действие.Состав: экстракт растительный жидкий слоевищ фукуса на водно- пропиленгликолевой основе.Экстракт фукуса содержит полный набор микро- и макроэлементов (железо, йод, калий, кальций, натрий, магний, кремний, селен, фосфор, цинк, сера и проч.), практически все необходимые человеку витамины, сбалансированный набор органических кислот и уникальные полисахариды (альгинаты, ламинаран, фукоидан), которых практически не бывает в наземных растениях. Немаловажным является тот факт, что все перечисленные вещества содержатся в фукусе в органической форме.Экстракт способствует снижению уровня холестерина в крови. Большое количество йода и трийодтирозин мягко стимулируют функцию щитовидной железы. Альгинаты фукуса выводят из организма радионуклиды и соли тяжелых металлов, регулируют водно-солевой обмен, нормализуют пищеварение, очищают кишечник. Также альгинаты стимулируют процессы заживления ран и ожогов, препятствуют развитию инфекции в поврежденных тканях. Ламинарин фукуса укрепляет стенки сосудов, нормализует кровоснабжение сердца и головного мозга, препятствует образованию тромбов и злокачественных опухолей, повышает иммунитет, успокаивающе действует на нервную систему, способствует крепкому сну. Фукоидан обладает противовирусным, имуннорегулирующим, противоопухолевым (он прекращает рост и развитие новых кровеносных сосудов, питающих опухоль) свойствами. Йод фукуса нормализует обмен веществ в подкожной жировой клетчатке, активирует распад жиров и повышает липолиз, таким образом способствует исчезновению ожирения – целлюлита.Фукус нормализует синтез половых гормонов, стимулирует полноценную работу щитовидной железы, восполняет потребности организма человека в незаменимых аминокислотах, витаминах, полиненасыщенных жирных кислотах типа «Омега». Экстракт способствует укреплению сердечно-сосудистой системы, делает стенки сосудов более эластичными и прочными, является мощным детоксикантом и незаменим при выводе шлаков из организма. Фукус очень эффективен для похудения, его компоненты стимулируют обмен веществ, затрудняют усвоение углеводов, понижают в крови уровень сахара. Компоненты фукуса благотворно действуют на гормональный фон женщин в период климакса а также нормализуют менструальный цикл, укрепляют иммунитет, улучшают состояние кожи и волос.Полезные вещества, которыми богат фукус, действуют на организм комплексно и оказывают влияние практически на все органы и системы. Поэтому экстракт фукуса применяется при лечении заболеваний мочеполовой, дыхательной и нервной систем, желудочно-кишечного тракта, сахарного диабета, щитовидной железы, астмы, аллергии, кожных заболеваний, мышечных болей и воспалений суставов, авитаминоза, дисбактериоза, отечностей.')
/*2*/, (N'Flormar Pretty BB Cream SPF15', 4, N'Этот Бальзам Красоты со своей легкой текстурой обеспечивает ровный тон коже лица и придает естественный блеск. Насыщенный увлажняющими, а также маскирующими компонентами ББ крем, идеально сочетается с кожей и помогает выровнять тон. Уникальная формула, обогащенная натуральными ингредиентами, обеспечивает коже роскошное сияние. Мягкая кремовая текстура способствует сохранению равномерного, безупречного тона лица в течении всего дня. Подходит для всех типов кожи, а также защищает кожу от УФ-излучения с SPF 15.')
/*3*/, (N'Тушь Flormar Pretty Volumizing Mascara', 4, N'Благодаря лишь одному взмаху щеточки новой туши Pretty Volume Mascara ресницы становятся вдвое гуще, а времени на это тратится вдвое меньше. Благодаря специальным утолщающим и придающим объем ингредиентам в сочетании с увлажняющими веществами ресницы выглядят естественно густыми, а входящие в состав туши полимеры закрепляют загнутую форму ресниц на длительное время. Разработанная для этой туши длинная щеточка с жесткими щетинками разделяет ресницы и прокрашивает каждую из них по отдельности. ')
/*4*/, (N'Крем для лица и тела с аргановым маслом', 6, N'Крем Thalia для лица и тела с аргановым маслом стимулирует естественные процессы восстановления кожи в течение всего дня. Органические аргановое масло, масло ши, провитамин В5 и витамин Е в составе крема обеспечивают питание, увлажнение и необходимый уход. Подарите своей коже сияние, восстановление и упругость. Подходит для ежедневного использования и ухода за кожей. Не содержит парафиновых масел и парабенов.Способ применения: легкими массажными движениями нанести на кожу лица и тела. Меры предосторожности: только для наружного применения. Избегать контакта с глазами. В случае попадания в глаза промыть большим количеством воды. Хранить при комнатной температуре в недоступном для детей месте.Состав: Aqua, Glycerin, Ethylhexyl Stearate, Stearyl Alcohol, Butyrospermum Parkii Butter, Argania Spinosa Kernel Oil, Cyclopentasiloxane, Ethylhexyl Palmitate, Cyclohexasiloxane, Parfum, Glyceryl Stearate, Ceteareth-20, Ceteareth-12, Cetearyl Alcohol, Cetyl Palmitate, Tocopheryl Acetate, Dimethicone, Panthenol, Sodium Polyacrylate, Allantoin, Tetrasodium EDTA, Phenethyl Alcohol, Caprylyl Alcohol, Citric Acid, Butylphenyl Methylpropional, Benzyl Benzoate, Alpha-Isomethyl Ionone, Limonene, Benzyl Salicylate, Citronellol, Cinnamyl Alcohol, Citral, Coumarin, Linalool.')
/*5*/, (N'Весенний, фиточай', 5, N'Фиточай «Весенний» Фитокомпозиции сезонных фиточаев серии «Родная природа» позволяют гармонизировать биоритмы человека и снизить стресс организма при изменении времни года. Летом Вы сможете не только утолить жажду и охладить организм, но и снизить риск сердечно-сосудистых заболеваний, аллергии, расстройства желудочно-кишечного тракта. В зимний период употребление фиточая позволит избежать простудных и инфекционных заболеваний, пополнить витаминами ежедневный рацион питания. Весной и осенью фиточай избавит Вас от обострений хронических заболеваний, наполнит организм жизненной энергией.Фиточаи серии «Родная природа» сочетаются с другими оздоровительными продуктами компании «Биолика», что повышает их эффективность и устойчивость полученных результатов.Состав: корень солодки, цветы бузины, гинкго-билоба, трава душицы, плоды шиповника, цветы липы, листья малины, лист вишни, лист ежевики.Сбалансированная формула фиточая «Весенний» создана с целью профилактики сезонной аллергии (поллиноза) и острых респираторных заболеваний, а также предупреждения сезонных обострений желудочно-кишечных заболеваний.Проявления аллергии зависят как от сверхчувствительности иммунной системы, так и от способности печени связывать и выводить аллергены. Печень – это «лаборатория», которая очищает кровь от всех вредных веществ. При ослаблении функции печени по обезвреживанию токсических веществ, попадающих в кровь, организм «запускает» аллергические реакции. Компоненты фиточая подобраны таким образом, что обеспечивают гепатопротекторный (восстановление клеток печени) эффект, желчегонное действие, профилактику весеннего обострения хронических заболеваний желудочно-кишечного тракта (язвенной болезни и др.).Оказывает общеукрепляющее, адаптогенное, противовоспалительное, иммуномодулирующее, десенсибилизирующее (противоаллергическое) действие.Фиточай «Весенний» укрепляет стенки сосудов снижает уровень опасности нарушений мозгового кровообращения, нормализует обменные процессы, является источником витаминов и микроэлементов, обладает замечательным ароматом дикорастущих трав.')
/*6*/, (N'Амрита Восстанавливающий тоник для лица, 200 мл', 2, N'Мощный Fitomelanin®++ в соединении с Essential extracts и активными компонентами растительного происхождения способствует восстановлению клеток и предотвращает появление признаков старения.')
/*7*/, (N'Бальзам для губ Unice Divine Полуниця', 3, N'Бальзами від UNICE не тільки порадують приємними фруктовими ароматами, а й потурбуються про красу і живлення губ. Не забудь покласти в сумочку та насолоджуйся літом і сонцем! Спосіб застосування: Наносити в міру необхідності на губи як самостійний засіб або перед використанням губної помади/блиску для губ. Запобіжні заходи: Тільки для зовнішнього застосування. Зберігати при кімнатній температурі. Уникати потрапляння в очі. У разі потрапляння в очі промити великою кількістю води. Зберігати в недоступному для дітей місці. Уникати прямих сонячних променів.')
/*8*/, (N'Бьюти Баланс, 30 капс.', 2, N'Бьюти Баланс - это специальная формула витаминов, минералов и растительных экстрактов для здоровья и красоты кожи, ногтей и волос, а также энергии и прекрасного настроения на каждый день. ')
/*9*/, (N'Увлажняющая помада для губ Unice Divine, 4,2 г', 3, N'Попробуйте идеальную палитру оттенков Sensual Lips для дневного макияжа! Очень мягкая текстура с мерцающими частицами придаст губам соблазнительного объема, а касторовое масло в составе помад обеспечит необходимое увлажнение. Представляете - бальзам для губ вам больше не понадобится!')
/*10*/, (N'Крем-молочко для тела «Солнечные оливки», серия "Hainan Tao"', 1, N'Антистрессовая серия "Hainan Tao" создана на основе природных ингредиентов. Прекрасно подходит для ежедневного применения для любого типа кожи и в любом возрасте.C крем-молочком для тела "Солнечные оливки" Ваша кожа будет мягкая и нежная, как у ребенка. Шикарное питательное средство для ухода за Вашей бархатной кожей. В состав входит экстракт оливок, аллантоин, витамин С, гиалуроновая кислота, благодаря чему Ваша кожа дышит здоровьем и красотой!')
/*11*/, (N'Минеральная пудра UNICE Divine MCP01', 3, N'Многофункциональная минеральная пудра UNICE Divine  имеет непревзойденно стойкие свойства. Высококачественные ингредиенты обеспечивают натуральный вид лица и матовый финиш. Минералы в составе пудры поддерживают надлежащий уровень увлажнения, создавая защитный барьер между поверхностью кожи и вредными внешними факторами. Пудра скрывает несовершенства кожи и предотвращает появление жирного блеска. Идеальна для поддержания и обновления макияжа на протяжении дня. Не содержит парабенов и отдушек.')
/*12*/, (N'Противовоспалительный лосьон, серия антиакне "Master Herb"', 1, N'Фитокоррекция проблемной кожи с ТианДе!Лосьон Master Herb применяется после умывания гелем. Проникая глубоко в поры, он помогает удалить все лишнее с кожных покровов, тщательно очищая их. Обладает дезинфицирующими свойствами, так как создан для борьбы с акне.Противовоспалительный лосьон, серия антиакне "Master Herb" - тонизирует, освежает, обладает вяжущим действием; не только удаляет излишки кожного сала, а и нормализует деятельность сальных желез, восстанавливая pH кожи. Растительные экстракты успокаивают, помогая убрать отеки и покраснения кожи.')
/*13*/, (N'Шампунь от облысения (против выпадения ), серия "Master Herb"', 1, N'Шампунь от облысения (против выпадения ), серия "Master Herb" - эффективно останавливает и предотвращает преждевременное выпадение волос. Усиливает кровоснабжение в области очага облысения. Активизирует обменные процессы. Восстанавливает витаминно-минеральный баланс, необходимый для роста волос. Укрепляет корни, воссоздает поврежденную волосяную кутикулу (защитный слой волоса). Стимулирует рост новых волос. Рекомендован для редеющих волос. ')
/*14*/, (N'Шанталь Крем-суфле для рук і тіла «Вербена і олива», 200 г', 2, N'Легкий крем для рук і тіла забезпечує інтенсивне зволоження та живлення впродовж всього дня. Легко усуває роздратування і сухість, а також прискорює відновні процеси в шкірі. Крем ідеально поєднує і забезпечує комплексний догляд за шкірою рук і тіла.')

insert into ProductImages(ProductId, Image) values
  (1,'ekstrakt-fukusa-30-ml.jpg')
, (2,'Flormar_pretty_BB_Cream_SPF15.jpg')
, (3,'Flormar_Pretty_Volumizing_mascara.jpg')
, (4,'thalia_krem-dlya-litsa.png')
, (5,'vesenniy-fitochay.jpg')
, (6,'Амрита_Восстанавливающий_тоник_для_лица.jpg')
, (7,'Бальзам_для_губ_Юнис_Полуниця.png')
, (8,'Бьюти_Баланс_30_капс.png')
, (9,'Зволожуюча_помада_для_губ_Юнис.png')
, (10,'Крем_молочко_для_тела_Солнечные_оливки.jpg')
, (11,'Минеральна_пудра_Юнис.png')
, (12,'Противовоспалительный_лосьон_серия_антиакне.jpg')
, (13,'Шампунь_от_облысения.png')
, (14,'Шанталь_Крем-суфле_для_рук_и_тела.png')

insert into Items(ProductId, Price, OldPrice) values
  (1, 116, null)
, (2, 117, null)
, (2, 117, null)
, (3, 107, null)
, (4, 272, null)
, (5, 46, 50)
, (6, 149.5, null)
, (7, 89, null)
, (8, 356.5, 420)
, (9, 99, null)
, (10,330.7, 389)
, (11, 199, null)
, (12, 157.3, 185.00)
, (13, 319.60, 376.00)
, (14, 83, null)

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
, (N'Детокс организма', null) -- 23
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
  (1,14)
, (1,22)
, (1,26)
, (2,2)
, (2,3)
, (3,1)
, (4,3)
, (4,4)
, (4,15)
, (5,21)
, (5,22)
, (6,2)
, (6,3)
, (6,4)
, (7,1)
, (8,25)
, (8,26)
, (9,1)
, (10,5)
, (11,1)
, (12,2)
, (12,27)
, (13,9)
, (14,5)

--insert Characteristics(Name) values
--  (N'Пол')              -- 1
--, (N'Классификация')    -- 2
--, (N'Возраст')          -- 3
--, (N'Объем')            -- 4
--, (N'Время применения') -- 5
--, (N'Назначение')       -- 6
--, (N'Тип кожи')         -- 7
--, (N'Тип аромата')      -- 8

--insert CharacteristicProducts(ProductId, CharacteristicId, Value) values
--  (1, 1, N'для женщин')
--, (1, 4, N'10мл.')
--, (2, 1, N'для женщин')
--, (2, 2, N'Премиум')
--, (2, 4, N'15мл.')
--, (3, 1, N'для женщин')
--, (3, 3, N'30+')
--, (3, 4, N'20мл.')
--, (4, 1, N'для женщин')
--, (4, 4, N'30мл, 50мл, 100мл.')
--, (4, 8, N'Цветочный')
--, (5, 1, N'для женщин')
--, (5, 2, N'Масс-маркет')
--, (5, 4, N'15мл.')
--, (6, 1, N'для женщин')
--, (6, 3, N'18+')
--, (6, 4, N'20мл.')
--, (7, 1, N'для женщин')
--, (7, 4, N'50мл, 100мл.')
--, (7, 8, N'Цветочный')
--, (8, 1, N'для мужчин')
--, (8, 4, N'40мл, 50мл, 100мл.')
--, (8, 8, N'Морские ноты')
--, (9, 1, N'для мужчин')
--, (9, 4, N'20мл, 50мл, 80мл.')
--, (9, 8, N'Древесный')

insert OptionalParameters(Name) values
  (N'Объем')
, (N'Цвет')
, (N'Тип кожи')

insert OptionalParameterProducts(ItemId, OptionalParameterId, Value) values
  (2,2,N'BB-крем 01 Light')
, (3,2,N'BB-крем 02 Light Medium')

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
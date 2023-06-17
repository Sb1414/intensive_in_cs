# intensive_in_cs
# Оглавление
1. [День 00](#день-00) \
	[Упражнение 00 - Жизнь в кредит](#упражнение-00---жизнь-в-кредит) \
    [Упражнение 01 – Работа над ошибками](#упражнение-01-–-работа-над-ошибками)
2. [День 01](#день-01) \
    [Упражнение 00 — Хранение](#упражнение-00--хранение) \
    [Упражнение 01 – Клиенты](#упражнение-01-–-клиенты) \
    [Упражнение 02 – Корзина для покупок](#упражнение-02-–-корзина-для-покупок) \
    [Упражнение 03 – Кассовый аппарат](#упражнение-03-–-кассовый-аппарат) \
    [Упражнение 04 – Сохранение](#упражнение-04-–-сохранение) \
    [Упражнение 05 – Очереди](#упражнение-05-–-очереди) \
    [Упражнение 06 – Как это работает?](#упражнение-06-–-как-это-работает)
3. [День 02](#день-02) \
    [Упражнение 00. Сколько денег стоят деньги?](#упражнение-00-сколько-денег-стоят-деньги) \
    [Упражнение 01 – Баланс между работой и личной жизнью](#упражнение-01-–-баланс-между-работой-и-личной-жизнью)
4. [День 03](#день-03) \
    [Упражнение 00 – Конфигурация](#упражнение-00-–-конфигурация) \
    [Упражнение 01 — JSON](#упражнение-01--json) \
    [Упражнение 02 — YML](#упражнение-02--yaml) \
    [Упражнение 03 – Исключения](#упражнение-03-–-исключения) \
    [Упражнение 04 – Приоритеты](#упражнение-04-–-приоритеты)
5. [День 04](#день-04) \
    [Упражнение 00 – Книги](#упражнение-00-–-книги)
6. [Team00](#team00) \
    [Упражнение 00 — Домен](#упражнение-00--домен)

# День 00
## Упражнение 00 - Жизнь в кредит
Вывод данных в таблице следующего вида: 

| № платежа | Дата платежа | Оплата | Основной долг | Доля | Остаток долга  |
|---|---|---|---|---|---|

Все должно рассчитываться ежемесячно. Калькулятор принимает на вход: Сумма кредита, Годовая процентная ставка, количество месяцев кредита.
Формулы, по которым банк производит расчеты:

**Общий ежемесячный платеж**

```math

\frac{Loan \; ammount*i*(1+i)^n}{(1+i)^n-1}

```

n — количество месяцев, в течение которых выплачивается кредит

i — процентная ставка по кредиту в месяц.

**Процентная ставка по кредиту в месяц:**

```math

i = Annual \; percentage \; rate /12/100

```

**Ежемесячный платеж проценты:**

```math

\frac{Total \; debt \; balance*Annual \; percentage \; rate * DaysOfThePeriod}{100*Days \; per \; year}

```
Общий остаток долга – это сумма основного долга на дату погашения.

Количество дней периода – это разница в днях между «Текущей датой платежа» и датой предыдущего платежа.

Мы предполагаем, что кредит погашается 1-го числа каждого месяца, начиная со следующего. Важно учитывать високосные годы!

### Входные параметры

| Аргумент | Тип | Описание |
|---|---|---|
| сумма |double | Сумма кредита, руб. |
|ставка | double | Годовая процентная ставка, % |
|срок|int|Количество месяцев кредита|

### Выходной формат
Данные должны быть упорядочены по месяцам (в порядке возрастания)

#### Если пользователь указал неверные данные
```
Something went wrong. Check your input and retry.
```

#### Пример запуска приложения из папки проекта
```
$ dotnet run 1000000 12 10
1       06/01/2021      105,582.08      95,390.30       10,191.78       904,609.70
2       07/01/2021      105,582.08      96,659.90       8,922.18        807,949.81
3       08/01/2021      105,582.08      97,347.63       8,234.45        710,602.18
4       09/01/2021      105,582.08      98,339.77       7,242.30        612,262.40
5       10/01/2021      105,582.08      99,543.32       6,038.75        512,719.08
6       11/01/2021      105,582.08      100,356.56      5,225.52        412,362.52
7       12/01/2021      105,582.08      101,514.94      4,067.14        310,847.58
8       01/01/2022      105,582.08      102,413.99      3,168.09        208,433.60
9       02/01/2022      105,582.08      103,457.77      2,124.31        104,975.83
10      03/01/2022      105,942.18      104,975.83      966.35          0.00
```

## Упражнение 01 – Работа над ошибками
Есть словарь, который содержит список всех имён, по которому можно проверить правильность написания, а в ответ на ошибку в имени пользователя может предложить исправление. Это то, что вам нужно реализовать.

У нас есть файл со списком имен, который нужно прочитать для проверки.
Здесь мы предполагаем, что словарь заполнен и содержит все возможные варианты (если пользователь ничего не выбирает или имя не найдено, отображается ошибка).

Нужно использовать [расстояние Левенштейна](<https://en.wikipedia.org/wiki/Levenshtein_distance>) для сравнения слов. Имя считаем родственным введенному, если расстояние редактирования до него меньше 2. Самый простой способ выполнять операции со строками, например, очищать их от лишних пробелов, — это использовать методы строкового типа .

Итак, консольное приложение запрашивает имя пользователя:
```
>Enter name:
```
### Выходной формат

Далее пользователь должен ввести свое имя (оно может содержать только буквы, пробелы и дефисы), на что программа реагирует следующим образом:

| Случай | Ожидаемый результат |
|---|---|
| Имя было найдено в словаре |Hello, {name}! |
| В словаре найдено близкое имя (дистанция редактирования до которого не более 1) |>Did you mean “{исправленное имя}”? Y/N |
| Y |Hello, {исправленное имя}! |
| N |>Did you mean “{new correction option}”? Y/N <br/> or <br/> Your name was not found. |
| Родственное имя не найдено |Your name was not found. |
| Имя не введено  |Your name was not found. |

#### Пользователь указал неверные данные
```
Something went wrong. Check your input and retry.
```

#### Пример запуска приложения из папки проекта

```
$ dotnet run
>Enter name:
Mrk
>Did you mean “Mark”? Y/N
Y
>Hello, Mark!
```
# День 01
## Упражнение 00 — Хранение
Нужно создать класс Storage и описать его свойства. Главное для нас то, что склад определяется целым числом товаров (условно одинаковых), которые в нем хранятся.

Количество товара может варьироваться, но на момент создания хранилища оно определяется его вместимостью - начальной стоимостью. Пусть в конструкторе класса указано количество товаров. Хранилище нельзя создать без емкости, поэтому у него не должно быть конструктора без параметров.

Добавить в класс метод IsEmpty, который будет возвращать информацию о товарах, которых нет в наличии. Использовать лямбда-оператор.

## Упражнение 01  – Клиенты
Создать класс Customer и описать его свойства. Сделать так, чтобы одного покупателя можно было отличить от другого: пусть у него будет имя и порядковый номер, под которым он зашел в магазин. Поскольку классы наследуются от типа Object и получают доступ к его методам, переопределить метод ToString(), чтобы он возвращал строковую информацию с номером и именем клиента.
```
Andrew, customer #1
```
Номер и название не меняются. Сделать эти автосвойства заблокированными для редактирования извне и задавать только из конструктора класса. Заказчик не может быть создан без них, поэтому у него не должно быть конструктора без параметров.

Попробуйте создать двух клиентов с одинаковыми именами и номерами:
```
var customer1 = new Customer("Andrew", 1);
var customer2 = new Customer("Andrew", 1);
```
Вывести значение выражения customer1 == customer2 в консоль. Почему ответ такой?

Изменить класс Customer , чтобы вывод на консоль был верным.

## Упражнение 02 – Корзина для покупок
Возьмем класс Customer из предыдущего упражнения, добавим ему свойство, отражающее количество товаров в его корзине. Когда клиент создается (в реальном мире, когда он появляется в магазине), у него нет товаров.

Чтобы пользователи ваших классов не могли изменять значение как им вздумается, сделайте поле с количеством товаров не изменяемым извне.

Вместо этого добавьте клиенту метод заполнения корзины FillCart: пусть метод берет максимальную вместимость корзины (входной аргумент) и заполняет количество товаров клиента случайным числом (минимум 1, максимальная вместимость корзины).

Вот так мы реализовали логику наполнения корзины в одном месте и закрыли ее удобным методом с читаемым и понятным названием. Добро пожаловать в инкапсуляцию.

Создайте 3 пользователей, заполните их корзины вместимостью 15 товаров. Вывести в консоль информацию о пользователе и количестве товаров в его корзине.

Пример:
```
Andrew, customer #1 (5 items in cart)
```

## Упражнение 03 – Кассовый аппарат
Создать класс CashRegister и описать его свойства. Пусть у кассы есть «имя» — некий заголовок, который позволит покупателям четко понимать, о какой кассе идет речь. Переопределить методы класса, чтобы ToString() возвращал название и две кассы с одинаковые заголовки равны.
```
Register #1
```
У кассового аппарата не должно быть конструктора без параметров. Также не должно быть очередей на кассе. Но мы живем в реальном мире и хотим построить модель для реального мира, поэтому давайте реализуем очереди.

Добавить коллекцию Customers в класс CashRegister, чтобы это была очередь типа «первым пришел, первым обслужен».

## Упражнение 04 – Сохранение
Создать класс Store и описать его свойства. В магазине должен быть склад и комплект кассовых аппаратов.

Реализовать конструктор класса так, чтобы он принимал на вход целочисленную емкость хранилища и целое число кассовых аппаратов. Заполнить свойства класса в конструкторе, используя эти входные данные. Пусть каждый кассовый аппарат будет создан с названием, соответствующим его порядковому номеру.

Подумать, есть ли смысл блокировать сеттер кассовой коллекции от редактирования?

Добавьте метод IsOpen , возвращающий true, если на складе еще есть товар.

## Упражнение 05 – Очереди
Как вы стоите в очереди? К кассе с наименьшим количеством покупателей или к кассе с наименьшим количеством покупок? Давайте реализуем обе ситуации.

Создайте статический класс CustomerExtensions с двумя методами расширения для объекта Customer : оба метода будут принимать набор кассовых аппаратов ( объекты CashRegister ) и возвращать кассовый аппарат, выбранный покупателем. Первый способ — касса с наименьшим количеством покупателей, второй — с наименьшим количеством товаров среди всех покупателей в очереди этой кассы.

Не забудьте назвать методы, чтобы было понятно, что именно они делают. Теперь у вас есть отдельный класс, отвечающий за выбор очереди (мы разделили ответственность) и удобный способ вызова этих методов в коде. Попробовать их.

## Упражнение 06 – Как это работает?
Создать магазин с 3 кассами и складом на 40 товаров. Создать 10 разных клиентов. Реализовать цикл: пусть каждый из покупателей наполнит корзину и встанет в очередь. Цикл должен работать, пока магазин открыт (у нас есть способ это проверить) и в нем есть покупатели.

Заполнение корзины покупателя товарами должно снимать их со склада. Реализовать его самостоятельно. Клиенты выходят из очереди после того, как они получают свои товары со склада. У клиентов не может быть больше предметов, оставшихся на складе (на складе не может быть меньше 0 предметов). Если хранилище пусто, а в корзине покупателя еще есть товары для покупки, вывести на консоль:
```
Andrew, Customer #4 (2 items left in cart)
```
Проделать это для двух разных случаев выбора очереди и в каждом случае вывести имя и номер пользователя, количество товаров, выбранную кассу и количество людей на кассе, количество товаров в корзинах очереди на консоль в цикле.
```
Andrew, Customer #4 (6 items in cart) - Register #1 (4 people with 20 items behind)
```
Вместимость тележки 7 штук.

# День 02
## Упражнение 00. Сколько денег стоят деньги?
Задача: реализовать конвертер валют для пар EUR-RUB, USD-RUB, EUR-USD, USD-EUR, RUB-USD, RUB-EUR. На входе программа запросит сумму в одной из разрешенных валют (EUR, RUB, USD). В ответ он отобразит таблицу, содержащую суммы, конвертированные в другие разрешенные валюты. Для удобства определим, что каждая валюта имеет свой уникальный код-идентификатор (EUR, RUB, USD). Для представления данных подходят **структуры** : тогда для суммы в валюте можно определить *ExchangeSum* (сумма, идентификатор), а для биржевой информации — ExchangeRate (валюта «от», валюта «до», курс обмена).

Используйте  **single-responsibility principle** (принцип единой ответственности)! Согласно ему, ваши структуры не должны знать о других валютах и ​​обменных курсах. Но они могут самостоятельно разбирать данные из текста или определять формат выходных данных при приведении к строке. Вам может помочь переопределение метода ToString().

Информацию о курсах обмена предоставляет обменник/биржа. В приложенном к упражнению архиве вы найдете файлы с коэффициентами пересчета. Мы предполагаем, что формат данных в файле строго задан. Предполагается, что файлы обновляются один раз в день, поэтому путь к папке будет одним из входных аргументов.

Функционал обменника должен быть выделен в отдельный класс *Exchanger*. Он будет содержать коллекцию курсов валют, парсить их из файлов и конвертировать. Помните, *Exchanger* не нужно знать, откуда он вызывается и для чего используется результат — не возлагайте на него ответственность за вывод в терминал.

Если метод конвертации возвращает список возможных сумм в валюте, его использование будет более гибким.

Посмотрите на оператор yield , это может быть полезно.

|Аргумент|Тип|Описание|
|---|---|---|
| sum |string | Сумма с указанием валюты |
|ratesDirectory | string | Путь к папке с файлами с курсами конвертации|

### Выходной формат
```
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR

Amount in the original currency: 100.00 EUR
Amount in USD: 81.97 USD
Amount in RUB: 8,990.38 RUB
```

### Пользователь указал неверные данные
```
Input error. Check the input data and repeat the request.
```

### Пример запуска приложения из папки проекта

```
$ dotnet run “100 RUB” “path/to/folder”
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR
```

## Упражнение 01 – Баланс между работой и личной жизнью

Структура проекта:
```
d02_ex01
      Program.cs
      Tasks/
            Task.cs
            TaskType.cs
            TaskPriority.cs
            TaskState.cs

```

Чтобы найти баланс между работой, учебой и личной жизнью, вы решили создать для себя личный таск-трекер.

Подумайте, что такое задача, чтобы мы могли разработать наше приложение на основе знаний предметной области . Задача – это цель, проблема, которую необходимо решить. Чтобы узнать содержание цели, нужно ее описать. Чтобы найти его среди других, нужно задать заголовок. Чтобы достичь своих целей, вам нужно установить сроки. Итак, задача должна иметь: название , описание и срок выполнения .

Кроме того, в задачах будет гораздо удобнее ориентироваться, если можно назначить *приоритет (Низкий, Нормальный, Высокий)* и *категорию (Работа, Учеба, Личная)* . Здесь нам поможет **enum**.

Статус задачи может меняться: она создается как *Новая* , после завершения всех работ становится *Выполненной* , кроме того, задачи, над которыми уже нет смысла работать, могут быть отмечены статусом *Неактуально* , поэтому вы не вернетесь к ним снова. Задача может находиться только в одном статусе и перемещаться между ними в определенном порядке ( *Выполненные* не могут стать *Неактуальными* ): звучит как **конечный автомат**.

Вам необходимо реализовать программу, позволяющую создавать список задач с возможностью отображения списка, добавления новой или пометки задачи как выполненной или неактуальной. Свойства задачи должны быть закрыты для внешних изменений. Для изменения статусов в задаче должны быть предусмотрены специальные методы, **инкапсулирующие** логику смены статуса.

### Способ 1. Создание задачи
```
> add
> Enter a title
> {title}
> Enter a description
> {summary}
> Enter the deadline
> {dueDate}
> Enter the type
> {type}
> Assign the priority
> {priority}

```

Примечание: статус задачи не задается вводом. Задача всегда должна создаваться в статусе *Новая*.

#### Входные параметры
|Аргумент|Тип|Описание|
|---|---|---|
| title |string, required | Название задачи|
|summary | string, not required | Описание того, что нужно сделать|
|dueDate | datetime (nullable), not required | К какому сроку планируется выполнить задачу|
|type | enum [Work, Study, Personal], required | Тип задачи |
|priority| enum [Low, Normal, High], not required (default value: Normal)| Приоритет задачи |
			
Обратите внимание на обязательные входные аргументы! Если параметр является обязательным, необходимо проверить его на входе. Если это не требуется, соответствующее поле в классе должно быть пустым. Помните, что строка является ссылочным типом и по умолчанию допускает **значение NULL**. DateTime и enum являются **типами значений**, и их необходимо явно указывать как допускающие значение NULL.

#### Выходной формат
```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```
#### Формат ответа в случае пустой даты
```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}
{task.Summary}
```
#### Пример ответа
```
- Water the flowers
[Personal] [New]
Priority: High, Due till 11/21/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent!
```
#### Пользователь указал неверные данные
```
Input error. Check the input data and repeat the request.
```
### Способ 2. Список задач
```
> list
```
Чтобы задать формат отображения задачи в одном месте, вы можете переопределить метод ToString() задачи. Если список пуст, нужно вывести сообщение об этом. Вам не нужно сортировать задачи.

#### Выходной формат
```
- {task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```
#### Пустой список
```
The task list is still empty.
```
#### Пример ответа
```
- Water the flowers
[Personal] [New]
Priority: Normal, Due till 11/5/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent

- Finish Day 02
[Study] [Done]
Priority: High, Due till 11/21/2021
Finish all the exercises of the day 02 of the .NET piscine, upload everything to the repository.
```
### Способ 3. Выполнение задания
```
> done
> Enter a title
> {title}
```
Здесь мы ссылаемся на конкретную задачу по названию, считая его уникальным идентификатором для простоты.

#### Входные параметры
|Аргумент|Тип|Описание|
|---|---|---|
| title |string, required | Название требуемой задачи для закрытия |

#### Задача не существует
```
Input error. The task with this title was not found
```
#### Пользователь указал неверные данные
```
Input error. Check the input data and repeat the request.
```
#### Пример ответа
```
The task [Water the flowers] is completed!
```
### Способ 4. Задача не актуальна
```
> wontdo
> Enter a title
> {title}
```
Здесь мы ссылаемся на конкретную задачу по названию, считая его уникальным идентификатором для простоты.

#### Входные параметры
|Аргумент|Тип|Описание|
|---|---|---|
| title |string, required | Название требуемой задачи для закрытия |

#### Задача не существует
```
Input error. The task with this title was not found
```
#### Пользователь указал неверные данные
```
Input error. Check the input data and repeat the request.
```
#### Пример ответа
```
The task [Water the flowers] is no longer relevant!
```
#### Выход
Приложение закрывается, если вы вводите
```
> quit
```
или
```
> q
```

## День 03
Структура проекта:
```
d03/
	Program.cs
    Configuration/
        Configuration.cs
        Sources/
            IConfigurationSource.cs
            YamlSource.cs
            JsonSource.cs
```
### Упражнение 00 – Конфигурация
Для обработки и хранения параметров реализовать класс *Configuration*. Он должен содержать коллекцию *Params* — набор параметров, необходимых для работы приложения, словарь ключ-значение. Ключи должны быть уникальными, поэтому хэш-таблицы — хороший выбор для этого.

Помните о **принципе единой ответственности**: класс *Configuration* ничего не должен знать об источниках данных, будь то JSON, YAML или что-то еще. Поэтому давайте извлечем общий интерфейс *IConfigurationSource* для реализации разных источников. Он будет отвечать за загрузку данных из файла и иметь метод, возвращающий набор параметров.

Реализуйте конструктор класса *Configuration*, чтобы он принимал коллекцию параметров *IConfigurationSource* и заполнял ими коллекцию *Params*.

Так будет сохранен принцип **инверсии зависимостей**: класс *Configuration* будет зависеть от абстракции *IConfigurationSource* , а не от конкретных реализаций данного интерфейса. Позже, если вы решите добавить новые источники, вам не придется переписывать конфигурацию.

### Упражнение 01 — JSON
Реализуйте класс *JsonSource* , потомок *IConfigurationSource*. Единственным конструктором класса должен быть конструктор, принимающий путь к файлу json, откуда будет загружаться конфигурация. Чтобы превратить файл JSON в Hashtable, используйте встроенные инструменты System.Text.Json.

Мы предполагаем, что структура параметров в файлах плоская, и здесь нет вложенных данных.

Создайте экземпляр класса *Configuration* , используя *JsonSource* , заполненный из файла config.json. Вывести конфигурацию в консоль в следующем формате:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```
#### Входные параметры
```
$ dotnet run “{filePath}”
```
|Аргумент|Тип|Описание|
|---|---|---|
| filePath |string | Путь к json-файлу |

#### Пример запуска приложения из папки проекта
```
Configuration
Port: 1234
CheckForUpdates: True
Domain: http://localhost
Source: JSON
```

### Упражнение 02 — YAML
Реализуйте класс *YamlSource* , потомок *IConfigurationSource*. Единственным конструктором класса должен быть конструктор, принимающий путь к yaml-файлу, откуда будет загружаться конфигурация. Пока нет встроенных инструментов для получения Hashtable из файла YAML , но это не имеет большого значения. Дело в том, что любая разработка, так или иначе, — это командная работа, и для обмена полезным кодом есть инструмент nuget . Подключайтесь и используйте пакет YamlDotNet .

Мы предполагаем, что структура параметров в файлах плоская, и здесь нет вложенных данных.

Создайте экземпляр класса *Configuration* , используя *YamlSource* , заполненный из файла config.yml. Вывести конфигурацию в консоль в следующем формате:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```
#### Входные параметры
```
$ dotnet run “{filePath}”
```
|Аргумент|Тип|Описание|
|---|---|---|
| filePath |string | Путь к файлу yaml |
#### Пример запуска приложения из папки проекта
```
Configuration
CheckForUpdates: false
Port: 8080
Source: YAML
Application: ex03
```

### Упражнение 03 – Исключения
Десериализация файлов неправильного формата может привести к возникновению исключений в приложении. Это нормально, если исключение обрабатывается .

Добавьте вызов классов обработки конфигурации для перехвата исключений, возникающих во время десериализации. В этом случае нужно вывести ошибку о некорректных данных:
```
Invalid data. Check your input and try again.
```

### Упражнение 04 – Приоритеты
Класс *Configuration* будет создан путем сбора данных из разных источников. Однако окончательный набор параметров, который будет иметь отношение к приложению, должен быть один. Поэтому у вас должна быть возможность объединять одноименные параметры из разных источников конфигураций. Это означает, что каждый из источников должен иметь параметр *Priority*, чтобы конфигурация могла определить, в каком порядке она будет загружать и объединять данные.

Добавьте в интерфейс *IConfigurationSource* свойство , отображающее приоритет источника конфигурации. Свойство должно быть закрытым для редактирования и заполняемым из конструктора класса.

Добавить *конфигурацию*, чтобы приоритет учитывался при загрузке конфигураций из разных источников.

Создайте экземпляр класса *Configuration* с конфигурацией из двух источников: *YamlSource* и *JsonSource*. Задайте путь к файлам и их приоритет из консоли при запуске приложения.

Вывести конфигурацию в консоль в следующем формате:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```
#### Входные параметры
```
$ dotnet run “{jsonPath}” {jsonPriority} “{yamlPath}” {yamlPriority}
```
|Аргумент|Тип|Описание|
|---|---|---|
| jsonPath |string | Путь к json-файлу |
| jsonPriority |int | Приоритет файла json |
| yamlPath |string | Путь к файлу yaml |
| yamlPriority |int | Приоритет файла yaml |

#### Пример запуска приложения из папки проекта
```
$ dotnet run “pathToJson” 1 “pathToYaml” 2
Configuration
Source: YAML
Application: ex03
CheckForUpdates: false
Domain: http://localhost
Port: 8080
```
```
$ dotnet run “pathToJson” 1 “pathToYaml” 0
Configuration
CheckForUpdates: True
Application: ex03
Port: 1234
Source: JSON
Domain: http://localhost
```

## День 04
#### Структура проекта:
```
d04/
      Program.cs
      appsettings.json
      Model/
            ISearchable.cs
            BookReview.cs
            MovieReview.cs
```
### Упражнение 00 – Книги
Теперь у вас есть загрузка самых продаваемых книг этой недели из разных категорий. Мы считаем, что файл периодически обновляется и содержит актуальную информацию. Из приведенной в списке информации нас интересуют: название книги, ее автор, описание, место в рейтинге и ее (рейтинговое) название, а также ссылка на страницу в магазине.

Список книг необходимо загрузить из файла **book_reviews.json**, их необходимо десериализовать из **JSON** в [соответствующие сущности](<https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-customize-properties>).


Реализуйте отдельный формат вывода для результирующего класса BookReview , переопределив метод ToString(). Пусть выводит:
```
{book.Title} by {book.Author} [{book.Rank} on NYT’s {book.ListName}]
{book.SummaryShort}
{book.Url}
```
Вывести список книг в консоль.

### Упражнение 01 – Фильмы
Для киношного настроения рядом есть выгрузка свежих обзоров фильмов. Мы считаем, что этот файл также обновлен и содержит актуальную информацию. Из данных, приведенных в этом списке, нам нужны: название фильма, его рейтинг, является ли фильм выбором критиков, краткое содержание его рецензии и ссылка на страницу публикации.
Список фильмов нужно загрузить из файла movie_reviews.json, их нужно десериализовать из JSON в соответствующие сущности .
Реализуйте отдельный выходной формат для результирующего класса MovieReview , переопределив метод ToString(). Пусть выводит:
```
{movie.Title} {movie.IsCriticsPick ? “[NYT critic’s pick]” : “”}
{movie.SummaryShort}
{movie.Url}
```
Вывести список фильмов на консоль.

## Team00

Рекомендуемая структура проекта:
```
rush00.App
	Assets/
		...
	Models/
		...
	ViewModels/
		...
	Views/
		...
	App.axaml
	Program.cs
	ViewLocator.cs
rush00.Data
	Migrations/
		...
	Models/
		Habit.cs
		HabitCheck.cs
	HabitDbContext.cs
```
### Упражнение 00 — Домен
Сегодня мы создадим собственный трекер привычек. Нам нужно иметь возможность описывать привычку и отслеживать ее развитие (или отказ) каждый день в течение заданного периода времени. На самом деле, ставьте галочки каждый день. Итак, нам нужен объект **Habit**, описывающий привычку: ее название (*Title*) и мотивация для ведения отслеживания (*Motivation*). Для привычки вам нужно будет отслеживать прогресс: он может быть установлен набором объектов *HabitCheck* для каждого из запланированных дней отслеживания, которые будут определяться *Свойства даты* и *IsChecked*. Как только все дни прошли (независимо от того, были они отмечены или нет), отслеживание завершается, и это можно отметить в свойстве *IsFinished*.

Теперь у нас есть простая модель. Мы можем отслеживать одну привычку в любое время. Это упрощение поможет нам как в развитии, так и в отслеживании этой привычки. Итак, если в системе нет незавершенного отслеживания, мы должны иметь возможность его создать, заполнив название привычки, мотивацию, дату начала и количество дней отслеживания.
Если привычка отслеживается, мы должны иметь возможность отмечать ее соблюдение или отклонение в каждый из дней (установите *IsChecked* для определенного объекта *HabitCheck*). Галочку можно поставить на любую дату.
Если отмечена последняя дата или прошел последний день отслеживания, свойство *IsFinished* объекта **Habit** должно стать истинным.

### Упражнение 01 – Интерфейс
Реализуем простой интерфейс для нашего трекера: пусть это будет **десктопное приложение**. Для разработки настольных приложений .NET огромную популярность приобрели **WPF** и **UWP**, которые являются одними из наиболее распространенных платформ. К сожалению, они очень ограничены, так как позволяют разрабатывать только в Windows.
Мы будем смотреть в сторону пользовательского интерфейса [Avalonia UI](<https://docs.avaloniaui.net/>). Это новый, но активно развивающийся кроссплатформенный **UI-фреймворк**, который разработчики называют духовным наследником технологии WPF. Он основан на разметке **XAML** и позволяет создавать настольные приложения для разных операционных систем. Наиболее часто используемый шаблон проектирования для разработки — **MVVM** .
Нам просто нужно несколько простых экранов.

### Установка привычки
Если в системе нет активной привычки отслеживания, приложение должно отобразить экран настроек.
Пользователь заполняет необходимые поля, чтобы начать отслеживание.
Обратите внимание на вводимые данные: все поля обязательны для заполнения; количество дней не должно быть отрицательным. Кнопка «старт» должна вести к следующему экрану.

### Отслеживание
Если для отслеживания задана привычка отслеживания (или она была заполнена на предыдущем шаге), пользователь должен увидеть экран отслеживания. Здесь у них есть возможность отметить каждый из дней.

Важно обрабатывать каждый тик (**событие Checked** каждого объекта **CheckBox**), чтобы установить и сохранить его в модели. Не забудьте проверить, завершено ли отслеживание!
Приведенные выше скриншоты программы помогут понять, что именно нужно реализовать.
Обязательно используйте [официальную документацию AvaloniaUI](<https://docs.avaloniaui.net/>) — там вы найдете описание всех необходимых [компонентов](<https://docs.avaloniaui.net/guides/basics>), основы технологии и [туториалы](<https://docs.avaloniaui.net/tutorials/todo-list-app>) двух простых проектов, которые помогут вам понять и освоить основные принципы разработки. Кроме того, читайте о [DataContext](<https://rachel53461.wordpress.com/2012/07/14/what-is-this-datacontext-you-speak-of/>).
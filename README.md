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
    [Упражнение 05 – Очереди](#упражнение-05-–-очереди)

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
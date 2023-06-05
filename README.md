# intensive_in_cs
# Оглавление
1. [Задание 00 - Жизнь в кредит](#задание-00---жизнь-в-кредит)
2. [Задание 01 – Работа над ошибками](#задание-01-–-работа-над-ошибками)

## Задание 00 - Жизнь в кредит
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

## Задание 01 – Работа над ошибками
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
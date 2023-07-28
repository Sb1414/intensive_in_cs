# d04

1. [Упражнение 00 – Книги](#упражнение-00-–-книги)
2. [Упражнение 01 – Фильмы](#упражнение-01-–-фильмы)
3. [Упражнение 02 — Поиск](#упражнение-02-–-поиск)
4. [Упражнение 03 — Лучшая версия](#упражнение-03--лучшая-версия)
5. [Упражнение 04 – Конфигурация](#упражнение-04-–-конфигурация)


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

### Упражнение 02 – Поиск
Теперь, когда у нас есть все наши медиафайлы в одном месте, давайте реализуем функцию поиска. Мы будем искать СМИ по названию.

Было бы здорово реализовать поиск в одном методе — искать придется по названию и среди книг, и среди фильмов, но дублировать код — [моветон](<https://x-team.com/blog/principles-clean-code/>). Это означает, что здесь вам понадобится **принцип подстановки Лисков**.

Реализуем поиск по заголовку **в статическом методе расширения** — *Search* . Чтобы метод Search не заботился о поиске книг или фильмов, сделайте тип T **generic** . Однако у этого типа должен быть заголовок для поиска. Добавим [ограничение](<https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint>):
```
static T[] Search<T>(this IEnumerable<T> list, string search)
where T : ISearchable
```
Реализовать поиск введенной строки, метод должен возвращать список всех найденных элементов: книги и обзоры фильмов.
Элементы *BookReview* и *MovieReview* должны реализовывать один и тот же интерфейс *ISearchable* : книги и фильмы будут искаться по названию, которое у них есть.

Результат поиска должен быть сгруппирован по типу мультимедиа (фильм/книга). Не используйте циклы для поиска, обратите внимание на **LINQ**! Обратите внимание на методы расширения **LINQ — Any, Count, GroupBy, OrderBy, Where**, они делают код намного читабельнее и проще для понимания. Используйте [лямбда-выражения](<https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions>).

Поиск не должен быть чувствительным к регистру. Результаты в каждой группе должны быть отсортированы по названию. Если элементов, соответствующих запросу, нет, приложение должно отобразить сообщение «Сегодня в медиа нет «{иска}».
В случае пустой строки поиска приложение должно вернуть все элементы.

#### Входные параметры
```
> Input search text:
```

|Аргумент|Тип|Описание|
|---|---|---|
|search|string|Строка поиска|

#### Пример запуска приложения из папки проекта
```
$ dotnet run
> Input search text:
ar

Items found: 6
Book search result [3]:
- THE MIDNIGHT LIBRARY by Matt Haig [6 on NYT's Hardcover Fiction]
Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.
https://www.amazon.com/dp/0525559477?tag=NYTBSREV-20
- THE INVISIBLE LIFE OF ADDIE LARUE by V.E. Schwab [9 on NYT's Hardcover Fiction]
A Faustian bargain comes with a curse that affects the adventure Addie LaRue has across centuries.
https://www.amazon.com/dp/0765387565?tag=NYTBSREV-20
- KLARA AND THE SUN by Kazuo Ishiguro [13 on NYT's Hardcover Fiction]
An "Artificial Friend" named Klara is purchased to serve as a companion to an ailing 14-year-old girl.
https://www.amazon.com/dp/059331817X?tag=NYTBSREV-20

Movie search result [3]:
- IN OUR MOTHERS' GARDENS
The Netflix documentary sets out to show how maternal lineages have shaped generations of Black women.
https://www.nytimes.com/2021/05/06/movies/in-our-mothers-gardens-review.html
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
- THINGS HEARD & SEEN
Amanda Seyfried and James Norton move into a haunted house in this busy, creaky Netflix thriller.
https://www.nytimes.com/2021/04/29/movies/things-heard-and-seen-review.html
```

### Упражнение 03 — Лучшая версия
Если при запуске приложения указан аргумент «лучший», реализовать вывод лучшего варианта книги и фильма вместо поиска по названию.
Мы считаем первую книгу, занявшую наивысшее место в рейтинге, лучшей, а первую рецензию на фильм – выбором критиков.
Не используйте циклы для поиска, обратите внимание на LINQ! Обратите внимание на методы расширения LINQ , они делают код намного читабельнее и проще для понимания. Используйте лямбда-выражения .
Примечание: методы для выбора одного элемента, такие как First(), имеют пары First()/FirstOrDefault(). Подумайте о разнице и применимости каждого из них.

#### Пример запуска приложения из папки проекта
```
$ dotnet run best
Best in books:
- SOOLEY by John Grisham [1 on NYT's Hardcover Fiction]
Samuel Sooleymon receives a basketball scholarship to North Carolina Central and determines to bring his family over from a civil war-ravaged South Sudan.
https://www.amazon.com/dp/0385547684?tag=NYTBSREV-20

Best in movie reviews:
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
```
### Примечание. Эффективность на примере метода Last()
Каждая коллекция в C# имеет метод расширения Last(). Однако в **O(1)** он работает только для коллекций, реализующих интерфейс IList (**список с доступом к элементам по индексу**). Для остальных коллекций он работает за **O(N)**, перебирая элементы до конца. Будь осторожен.
Всегда учитывайте, как работают методы LINQ и итерации элементов. Особенно, если вы используете их внутри циклов.

### Упражнение 04 – Конфигурация
Накануне мы уже написали свою **конфигурацию** , но на самом деле для этого есть готовые инструменты в .NET Core. Воспользуемся ими: файлом конфигурации **appsettings.json** и **пакетами nuget** для управления конфигурацией.

Установите [Microsoft.Extensions.Configuration.Json](<https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/6.0.0-preview.4.21253.7>) и обратите внимание на пакеты зависимостей, которые для него установит менеджер nuget. Пример настройки и использования конфигураций приложения можно найти в [статье](<https://learn.microsoft.com/en-us/archive/msdn-magazine/2016/february/essential-net-configuration-in-net-core>). Туда же можно вынести дополнительные настройки.

Настройте конфигурацию приложения так, чтобы путь к файлам брался из appsettings.json.

### Кроме того
Для более глубокого понимания языка запросов LINQ будет очень полезно понять, что такое [деревья выражений](<https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/>) и как они работают. Обязательно прочитайте его.
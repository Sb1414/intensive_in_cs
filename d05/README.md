# d05

1. [Упражнение 00 – Конфигурация](#упражнение-00-–-конфигурация) 
2. [Упражнение 01 – Интерфейсы](#упражнение-01-–-интерфейсы)
3. [Упражнение 02 – Пространство дня](#упражнение-02-пространство-дня)
4. [Упражнение 03 – Принеси мне звездочки](#упражнение-03-принеси-мне-звездочки)

Структура проекта:
```
d05/
     d05.Nasa/
           Apod/
                Models/
                      MediaOfToday.cs
                ApodClient.cs
           INasaClient.cs
     d05.Host/
           Program.cs
           appsettings.json
```
### Упражнение 00 – Конфигурация
Для начала работы с **API** необходимо получить ключ доступа, **API Key**: это можно сделать на вкладке «Generate API Key». Мы будем использовать его в наших методах, но хранить ключи и пароли небезопасно (и другие конфиденциальные данные) прямо в коде приложения Запомните это как истину!
Установите [Microsoft.Extensions.Configuration.Json](<https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/6.0.0-preview.4.21253.7>) и выведите ключ в конфигурационный файл appsettings.json:
```
{
   "ApiKey": "{ApiKey}"
}
```

Для того, чтобы иметь возможность публиковать свои наработки в Nuget и повторно использовать их в дальнейшем, разделите код решения на два проекта: библиотеку классов d05.Nasa , которая будет отвечать за логику получения данных, и консольное приложение *d05.Host*, который будет использовать полученные данные и заниматься их выводом.

В консольном приложении *d05.Host* вам потребуется только конфигурация *appsettings.json* и точка входа — метод *Main* класса *Program.cs* , который будет загружать конфигурацию, читать ввод и отвечать запрошенной информацией.
Библиотека *d05.Nasa* будет отвечать за связь с космосом и содержать клиентские реализации для каждого из упражнений.

### Упражнение 01 – Интерфейсы
Создайте интерфейс *INasaClient* с помощью метода получения данных *GetAsync*. Что бы мы ни получили от НАСА, оно будет отвечать за это.

Сделайте так, чтобы входные и выходные параметры в этом методе могли быть разными для каждой из реализаций. **Ключевые слова** **in** и **out** помогут вам, они позволят реализациям самим устанавливать типы входных и выходных параметров. Такой интерфейс называется **контравариантным** и **ковариантным** соответственно: *INasaClient<in TIn, out TOut>* с методом *TOut GetAsync(TIn input)*.

Это необходимо для соблюдения **принципа инверсии зависимостей**.

Создайте три разные реализации интерфейса с разными **входными** и **выходными** параметрами (по вашему желанию).

### Упражнение 02. Пространство дня
Рассмотрим «APOD (Astronomy Picture of the Day)» — ресурс, который возвращает коллекцию космических фотографий (или видео) дня, один из самых популярных ресурсов НАСА. По их словам, «у него популярность видео Джастина Бибера». Ваша цель — вывести на консоль первые N фотографий дня. N задается с консоли.

Вы можете найти документацию по API «APOD», перейдя на веб-сайт [API](<https://api.nasa.gov/>) -> Browse APIs -> APOD. Здесь вы можете прочитать о параметрах, ссылку для GET-запроса и увидеть пример возвращаемых данных.

На основе примера запроса, представленного на веб-сайте, создайте класс *MediaOfToday*. Структура необходимых данных:
```
{
      copyright: "Ignacio Diaz Bobillo",
      date: "2021-06-03",
      explanation: "Globular star cluster Omega Centauri, also known as NGC 5139, is some 15,000 light-years away. The cluster is packed with about 10 million stars much older than the Sun within a volume about 150 light-years in diameter. It's the largest and brightest of 200 or so known globular clusters that roam the halo of our Milky Way galaxy. Though most star clusters consist of stars with the same age and composition, the enigmatic Omega Cen exhibits the presence of different stellar populations with a spread of ages and chemical abundances. In fact, Omega Cen may be the remnant core of a small galaxy merging with the Milky Way. Omega Centauri's red giant stars (with a yellowish hue) are easy to pick out in this sharp, color telescopic view.",
      title: "Millions of Stars in Omega Centauri",
      url: "https://apod.nasa.gov/apod/image/2106/OmegaCent_LRGB_final1_1024.jpg"
}
```

### Упражнение 03. Принеси мне звездочки
Реализуйте класс ApodClient :
```
public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
```
Реализуйте метод GetAsync , он должен выводить первые N элементов. Сделайте входным параметром количество результатов ( в типе). Метод вернет коллекцию объектов *MediaOfToday*. Обратите внимание, что **асинхронные** методы возвращают **Task**.

Реализуйте **HTTP-запрос** GET к NASA API с помощью **HttpClient** и десериализуйте ответ в список MediaOfToday .

Если запрос не был выполнен успешно (успешный ответ имеет [StatusCode == 200 (OK)](<https://learn.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode?view=net-5.0>)) , необходимо вывести его содержимое в консоль.

Поскольку HTTP-запросы являются **операцией ввода-вывода**, чтобы программа не блокировалась при выполнении запроса к удаленному ресурсу (API-серверу), методы класса, содержащие эти запросы, должны быть **асинхронными**. В этом вам помогут ключевые слова async **/await**.
Для лучшего понимания что к чему читайте про [асинхронные завтраки](<https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios>).

Переменные в C# должны быть **PascalCasing** или **CamelCase**, для разбора используйте **аннотации JsonPropertyName**.
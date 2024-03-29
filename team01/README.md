# team01

1. [Упражнение 00 — Основы](#упражнение-00--основы)
2. [Упражнение 01 – Окружающая среда](#упражнение-01-–-окружающая-среда)
3. [Упражнение 02 – ПОЛУЧИТЬ погоду по координатам](#упражнение-02-–-получить-погоду-по-координатам)
4. [Упражнение 03 – ПОЛУЧИТЬ погоду по городам](#упражнение-03-–-получить-погоду-по-городам)
5. [Упражнение 04. Рефакторинг кода](#упражнение-04-рефакторинг-кода)
6. [Упражнение 05 — POST/PUT/DELETE, повторить](#упражнение-05--postputdelete-повторить)

Для разработки нашего API мы будем использовать архитектурный подход REST . В отличие от SOAP -сервисов, REST — это не стандарт, а набор практик и подходов, общая концепция реализации веб-сервисов с интерфейсом доступа. Попробуем на практике.
### Упражнение 00 — Основы
[Чтобы создать веб-приложение в .NET](<https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/>), используйте стандартный шаблон веб-приложения ASP.NET Core и выберите для него тип веб-API. У вас должен быть веб-проект, содержащий файлы конфигурации, классы конфигурации и **контроллер** с моделью WeatherForecast.

Ваш проект уже работает. Запустите и протестируйте метод, написанный «из коробки»: /WeatherForecast должен вернуть 5 случайно сгенерированных прогнозов. Эти данные являются статическими и задаются непосредственно в коде, но мы изменим это позже. Теперь рассмотрим сам проект.

Взгляните на файл Program.cs и посмотрите, что в нем происходит. Этот файл и его метод Main являются точкой входа при запуске приложения и используются во всех веб-проектах .NET.

Приложение настраивается в файле **Startup.cs** , который является важной частью любого веб-проекта на .NET. Узнайте самостоятельно, для чего нужны методы **Configure** и **ConfigureServices** , что такое **IApplicationBuilder**.

Текущей конфигурации будет достаточно для продолжения работы, но мы добавим документацию в наш API. В Startup есть вызовы службы **Swagger** — функционала для автоматического формирования документации. По адресу /swagger/index.html вы можете посмотреть документацию по имеющимся у вас методам. Проверьте их.

Добавьте в контроллер описание метода Get(): краткое описание того, что он делает, и два типа ответа — 200, если все в порядке, и 400, если произошла ошибка. **ProducesResponseType** идеально подходит для указания различных [статусов ответа](<https://developer.mozilla.org/en-US/docs/Web/HTTP/Status>) метода.

Откройте страницу Swagger вашего приложения и проверьте, корректно ли отображается описание метода и возможные статусы его ответов в сгенерированной документации.

Не забудьте проверить, что документация создается в файле XML.

### Упражнение 01 – Окружающая среда
Когда дело доходит до веб-разработки, предполагается, что **бэкенд**- приложение может быть запущено в разных **средах** : оно будет отлаживаться локально на машине разработчика, запускаться на сервере разработки для тестирования командой, а затем выпускаться в производство.

Однако некоторые настройки приложения могут (и должны) различаться для разных сред. Это решается легко. Во-первых, файлы конфигурации appsettings.json имеют постфикс с названием среды, в которой применяется эта конкретная конфигурация.

Во-вторых, в файле *Startup* можно найти свойство типа **IConfiguration** и параметр типа **IWebHostEnvironment** . Здесь вы можете, например, обнаружить, что документация по API swagger включена только для конфигурации dev. Это сделано для того, чтобы не давать доступ к подробному описанию вашего интерфейса в продакшн-версиях.

Приложение узнает о том, [что это за среда](<https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-5.0>), когда оно запускается. Для этого он считывает значение аргумента **ASPNETCORE_ENVIRONMENT**.

Запустите приложение в рабочей среде. Убедитесь, что swagger-документация недоступна в этой конфигурации.

### Упражнение 02 – ПОЛУЧИТЬ погоду по координатам
Сделаем запрос прогноза погоды актуальным. Используйте [общедоступный API](<https://openweathermap.org/current>) OpenWeather : зарегистрируйтесь, получите ключ API и измените метод Get() вашего контроллера, чтобы он принимал географические координаты (широту и долготу) и возвращал информацию о погоде с помощью вызова OpenWeather.

Вывод информации о температуре, давлении, влажности, скорости ветра, название географического объекта и описание погоды.

Добавьте описание к методу и модели. Убедитесь, что он отображается в документации swagger.

Пример вызова
```
{
    wind: 
    {
            speed: 4.47
    },
    weather: 
    [
            {
                      description: "overcast clouds"
            }
    ],
    main: 
    {
            temp: 29.27,
            pressure: 1007,
            humidity: 57
    },
    name: "Kizicheskaya"
}
```
### Упражнение 03 – ПОЛУЧИТЬ погоду по городам
Добавьте в контроллер еще один метод **HttpGet**, который будет принимать название города и возвращать прогноз погоды для этого города. Используйте соответствующий метод в [OpenWeather API](<https://openweathermap.org/current>).

Используйте выходной формат из упражнения 02. Обратите внимание на **маршрутизацию**, ее можно реализовать с [помощью атрибутов](<https://learn.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2>). Сделайте метод доступным по ссылке /WeatherForecast/{cityName}.

Добавьте описание к методу и модели. Убедитесь, что он отображается в документации swagger.

Пример вызова
```
{
    wind: 
    {
            speed: 4.49
    },
    weather: 
    [
            {
                      description: "overcast clouds"
            }
    ],
    main: 
    {
            temp: 29.34,
            pressure: 1007,
            humidity: 57
    },
    name: "Kazan’"
}
```

### Упражнение 04. Рефакторинг кода

### Структурирование
Давайте убираться. Чтобы быть готовым к расширению функциональности и использованию принципов **SOLID** , выделите весь код, связанный с OpenWeather API, в отдельный класс *WeatherClient* . У вас должен быть класс с двумя методами получения прогноза погоды: по координатам и по названию города. Оба метода должны обращаться к OpenWeather API, поэтому этот функционал будет **инкапсулирован** . В контроллере осталось только вызвать эти методы с нужными аргументами.

Вынести модель прогноза погоды и сервис для работы с OpenWeather API в отдельный проект *rush01.WeatherClient*. Чтобы проверить себя, задайте себе вопрос: что произойдет, если я решу использовать другой способ ввода и вывода информации, и вместо веб-приложения это будет настольное приложение или консольное приложение? При таком разделении можно легко повторно использовать проект, реализующий основную логику, и просто подключить к нему другое приложение с новой точкой входа.

### КЛЮЧ API
Обратите внимание, что API OpenWeather имеет разные варианты тарификации и, соответственно, разные ограничения. Это означает, что тестовая учетная запись вполне может подойти для разработки, но в производственной среде вам, возможно, придется приобрести полную лицензию (гипотетически). Итак, ключ, который мы используем для подключения, может быть разным и зависеть от среды.

Поместите значение API KEY в *appsettings files.json* и *appsettings.Development.json* и сделайте так, чтобы оно передавалось классу *WeatherClient* и использовалось в качестве параметра.

### DI
Подумайте о том, как создается объект *WeatherClient* в контроллере, который его использует:

- Мы можем создавать новый экземпляр каждый раз, когда в этом есть необходимость.
- Мы можем сделать его свойством контроллера и один раз создать новый экземпляр в конструкторе контроллера после использования заполненного свойства.
- Мы можем заполнить свойство значением, которое является параметром конструктора и ему передается уже готовое.

Все три метода легитимны, их использование зависит от требований к правилам создания, времени жизни и количеству экземпляров объекта. Чаще всего удобно использовать третий вариант — для него гораздо удобнее писать юнит-тесты.

Откуда будет вызываться конструктор контроллера для передачи ему требуемого параметра? Здесь нам на помощь приходит **внедрение зависимостей**. Это форма **инверсии управления**(IoC), которая позволяет реализовать зависимости извне. По сути, стиль конфигурации объекта, при котором поля объекта задаются внешней сущностью. В нашем случае [контейнер службы, встроенный в инструмент .NET](<https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0>).

Отредактируйте WeatherForecastController так, чтобы он содержал
> private readonly WeatherClient _weatherClient;

и что значение этого свойства передается конструктору контроллера и устанавливается там. Обратите внимание, что свойство является **частным** и **доступным только для чтения** , зачем это нужно?

Отредактируйте Startup.cs, чтобы зависимость *WeatherClient* была зарегистрирована в методе *ConfigureServices* при запуске приложения. Служба встроит объект в конструктор контроллера, где он используется. Платформа заботится о создании экземпляра зависимости и его удалении, когда он больше не нужен.

Запустите приложение и убедитесь, что все работает правильно.

Параметры
Используя Dependency Injection, вы можете [зарегистрировать объект параметров](<https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0>), который позволит вам встраивать элементы конфигурации там, где они необходимы. Помните, мы убрали значение ключа API в настройках приложения?

Создайте класс **ServiceSettings** с полем *ApiKey* и отредактируйте конструктор *WeatherClient*:
> public WeatherClient (IOptions<ServiceSettings> options)

Заполните объект значением из файла appsettings. Эта зависимость также должна быть зарегистрирована в методе *ConfigureServices* *Startup.cs*.

### Упражнение 05 — POST/PUT/DELETE, повторить
Помимо метода HTTP **GET** , вам могут пригодиться [и другие , каждый из них имеет свою область применимости](<https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods>). Например, посмотрите на разницу между использованием методов **PUT** , **POST** и **PATCH** . Почитайте, что такое **идемпотентность**.

Давайте сделаем так, чтобы вы могли установить город по умолчанию, если хотите. Если он установлен, метод Get из упражнения 03 вернет:

- если в метод передается название города: погода для этого города;
- если в метод не передано название города и задан город по умолчанию: погода для города по умолчанию;
- если в метод не передано название города и не задан город по умолчанию: [404](<https://developer.mozilla.org/ru/docs/Web/HTTP/Status>) .

Добавьте в контроллер метод Post(), который принимает название города. Не забудьте добавить к методу чванливое описание! Если все в порядке, метод должен вернуть HTTP-статус OK.

Поскольку одной из особенностей принципа REST является **бессерверность**, а запускать всю базу данных для хранения одной строки расточительно, воспользуемся [кэшированием](<https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-5.0>).

Измените код приложения так, чтобы метод Post() сохранял переданный ему город в кэш, а метод Get из упражнения 03 использовал его при необходимости. Проверяем, что все работает правильно:

1. Вызовите метод Get без указания города. Метод должен возвращать статус 404.
2. Вызовите метод Get, указав город Барнаул. Метод должен возвращать погоду для города Барнаул.
3. Вызовите метод Post, указав город Альбукерке. Метод должен возвращать статус 200.
4. Вызовите метод Get, указав город Барнаул. Метод должен возвращать погоду для города Барнаул.
5. Вызовите метод Get без указания города. Метод должен возвращать погоду для города Альбукерке.
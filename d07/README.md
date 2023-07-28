# d07

1. [Упражнение 00 – Документация по коду](#упражнение-00-документация-по-коду)
2. [Упражнение 01 – Нарушение правил](#упражнение-01-–-нарушение-правил)
3. [Упражнение 02 — Автозаполнение](#упражнение-02--автозаполнение)
4. [Упражнение 03 – Создание объектов](#упражнение-03-–-создание-объектов)
5. [Бонусное задание](#бонусное-задание)



### Упражнение 00. Документация по коду
```
Структура проекта:
d07_ex00\
      Program.cs
```

Хорошо документированный код — это код, который намного проще поддерживать. Все это знают. И они также знают, что это иногда забывается или не хватает времени на хорошую документацию.

Идей и реализаций для этого уже много, но здесь и сейчас давайте рассмотрим основы. Возьмем реальный класс [DefaultHttpContext](<https://github.com/dotnet/aspnetcore/blob/c660e9b1e3d6918e327499d340cbc38065e34436/src/Http/Http/src/DefaultHttpContext.cs>). Он содержится в пакете nuget Microsoft.AspNetCore.Http и активно используется в ASP.NET Core для хранения и управления информацией о http-запросах и ответах.

Отражение поможет нам получить информацию о типах, свойствах, методах этого класса. Почему бы не использовать его и не вывести описание всех из них на экран? Нам поможет **класс Type**, который по сути является корнем **System.Reflection** и основным способом доступа к **метаданным**, и его **методам**. Объект класса Type для DefaultHttpContext можно получить с помощью **typeof**.

Начнем с общей информации: выведем полное название типа, описание его **сборки** и название его базового типа.

Далее мы получим описание его [полей](<https://learn.microsoft.com/ru-ru/dotnet/api/system.type.getfields?view=net-5.0>) для класса DefaultHttpContext — давайте выведем имя и название типа для каждого поля в списке FieldInfo. Мы сделаем то же самое для [свойств](<https://learn.microsoft.com/ru-ru/dotnet/api/system.type.getproperties?view=net-5.0>) и списка PropertyInfo. Подумайте, [чем они отличаются](<https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties>).

DefaultHttpContext, вероятно, также имеет [методы](<https://learn.microsoft.com/en-us/dotnet/api/system.type.getmethods?view=net-5.0>). Их список — список объектов MethodInfo — тоже нужно вывести, но для каждого из них указать имя, тип, возвращаемый методом, и параметры метода.

При получении этих списков обратите внимание на **BindingFlags**. В выводе нас интересуют публичные и непубличные поля и только публичные методы и свойства.

Нужно учитывать как **статические**, так и нестатические. Ни один из приведенных выше списков не требует сортировки на выходе. Вы не пишете код в алфавитном порядке, не так ли?

#### Выходной формат
```
Type: {FullName}
Assembly: {AssemblyFullName}
Based on: {BaseType}

Fields: 
{field.TypeName} {field.Name}
...

Properties:
{property.TypeName} {property.Name}
...

Methods:
{method.ReturnTypeName} {method.Name} ({method.Parameters[]})
...
```
#### Пример запуска приложения из папки проекта
```
$ dotnet run
Type: Microsoft.AspNetCore.Http.DefaultHttpContext
Assembly: Microsoft.AspNetCore.Http, Version=2.2.2.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
Based on: Microsoft.AspNetCore.Http.HttpContext

Fields:
Microsoft.AspNetCore.Http.Features.FeatureReferences`1[Microsoft.AspNetCore.Http.DefaultHttpContext+FeatureInterfaces] _features
Microsoft.AspNetCore.Http.HttpRequest _request
Microsoft.AspNetCore.Http.HttpResponse _response
.....
System.Func`2[Microsoft.AspNetCore.Http.Features.IFeatureCollection,Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature] _newHttpRequestIdentifierFeature

Properties:
Microsoft.AspNetCore.Http.Features.IFeatureCollection Features
Microsoft.AspNetCore.Http.HttpRequest Request
.....
Microsoft.AspNetCore.Http.ISession Session

Methods:
IFeatureCollection get_Features ()
.....
Boolean Equals (Object obj)
Int32 GetHashCode ()
```

### Упражнение 01 – Нарушение правил
```
Структура проекта:
d07_ex01\
      Program.cs
```

Значение приватного поля можно изменить во время выполнения с помощью отражения.
Давайте снова возьмем фактический класс [DefaultHttpContext](<https://github.com/dotnet/aspnetcore/blob/c660e9b1e3d6918e327499d340cbc38065e34436/src/Http/Http/src/DefaultHttpContext.cs>). Он содержится в пакете nuget Microsoft.AspNetCore.Http и активно используется в ASP.NET Core для хранения и управления информацией о http-запросах и ответах.

Прежде всего создайте экземпляр класса DefaultHttpContext. Выведите значение его свойства Response на консоль. Вы увидите полное имя типа DefaultHttpResponse, так метод ToString() работал [по умолчанию](<https://learn.microsoft.com/ru-ru/dotnet/api/system.object.tostring?view=net-5.0#the-default-objecttostring-method>).

Свойство Response ничего в себе не хранит, оно **инкапсулирует** приватное поле _response, значение которого напрямую недоступно (в этом смысл приватности). Когда создается экземпляр DefaultHttpResponse, объект DefaultHttpResponse создается и сохраняется в поле _response. Выводим его выше.

Изменим его значение. Получить объект типа FieldInfo для поля _response. Не забывайте про флаги и то, что поле приватное, а не статичное. Знания, полученные в упражнении выше, помогут вам в этом.

Теперь используйте метод [SetValue](<https://learn.microsoft.com/ru-ru/dotnet/api/system.reflection.fieldinfo.setvalue?view=net-5.0#System_Reflection_FieldInfo_SetValue_System_Object_System_Object_>) и укажите новое значение — null. Снова выведите значение свойства Response на консоль. Будет выведена пустая строка.
Итак, мы изменили значение приватного поля. Имейте в виду, скорее всего, эта модификация нарушит поведение класса DefaultHttpContext. Поэтому используйте эти знания с осторожностью.

#### Выходной формат
```
Old Response value: {value}
New Response value: {value}
```
#### Примеры запуска приложения из папки проекта
```
$ dotnet run
Old Response value: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse
New Response value:
```

### Упражнение 02 — Автозаполнение
```
Структура проекта:
d07_ex02/
      Attributes/
              NoDisplayAttribute.cs
      ConsoleSetter/
              ConsoleSetter.cs
      Models/
              IdentityUser.cs
              IdentityRole.cs
      Program.cs
```
Что, если мы позволим пользователю заполнить некоторый объект? Что, если нам не нужно знать, что это за объект, а с помощью рефлексии ваш код может пробежаться по свойствам самого класса и заполнить нужные?
Давай попробуем.
Возьмем класс IdentityUser. Поместите это в проект:
```
public class IdentityUser
{
   public IdentityUser()
   {
   }

   public IdentityUser(string userName) : this()
   {
       UserName = userName;
   }

   public virtual string UserName { get; set; }
   public virtual string NormalizedUserName { get; set; }
   public virtual string Email { get; set; }
   public virtual string NormalizedEmail { get; set; }
   public virtual bool EmailConfirmed { get; set; }
   public virtual string PasswordHash { get; set; }
   public virtual string SecurityStamp { get; set; }
   public virtual string ConcurrencyStamp() => Guid.NewGuid().ToString();
   public virtual string PhoneNumber { get; set; }
   public virtual bool PhoneNumberConfirmed { get; set; }
   public virtual bool TwoFactorEnabled { get; set; }
   public virtual DateTimeOffset? LockoutEnd { get; set; }
   public virtual bool LockoutEnabled { get; set; }
   public override string ToString()
       => $"User: {UserName}, {Email}, {PhoneNumber}";
}
```
Этот класс основан на типе [IdentityUser](<https://github.com/aspnet/AspNetIdentity/blob/main/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUser.cs>) из ASP.NET Identity. Этот класс используется для авторизации и аутентификации пользователей в Web-приложениях.

Давайте реализуем приложение, которое при запуске будет запрашивать данные у пользователя для заполнения этого класса. Создайте класс ConsoleSetter, он будет отвечать за заполнение данных через консоль в методе SetValues ​​(T input). Метод не должен заботиться о том, какой объект его просят заполнить, поэтому мы делаем тип T **универсальным**. Однако дальше нам будет важно, что этот тип является классом, давайте добавим [ограничение](<https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint>).

Реализуйте метод *SetValues* . Во-первых, пусть он выводит приветствие "Давайте установим {typeName}!" в консоль, указав, какой класс мы сейчас будем заливать. Теперь для каждого публичного и нестатического свойства выводим в консоль запрос «Set {propertyName}:» и устанавливаем этому свойству значение, введенное пользователем для этого запроса.
Теперь мы можем заполнить «форму» без необходимости писать каждый конкретный вывод. Давайте настроим это.

Для заполнения класса нам нужно попросить пользователя заполнить только свойства *UserName*, *Email* и *PhoneNumber*. Атрибуты помогут нам отметить свойства, которые не требуются для заполнения.

Атрибуты в C# позволяют добавлять к типу различные **метаданные** . В .NET атрибуты используются повсеместно. Например, для проверки моделей используются атрибуты из пространства имен **System.ComponentModel.DataAnnotations**. Xunit активно использует атрибуты в качестве маркеров, например, чтобы определить, какой метод является тестом, а какой тест с параметрами.

Кроме того, атрибуты часто используются для динамической идентификации типа во время выполнения и для форматированного вывода. Это то, что нам понадобится.
Давайте объявим [тип нашего атрибута](<https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/creating-custom-attributes>) *NoDisplayAttribute* , унаследовав его от **System.Attribute**. Также укажем [условия его использования](<https://learn.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes>): он должен быть доступен для использования только со свойствами, один и тот же атрибут может быть указан для свойства только один раз. Пометьте этим атрибутом все свойства класса IdentityUser, кроме *UserName*, *Email* и *PhoneNumber*.

Теперь добавим фильтрацию в *SetValues* : нам нужен вывод и ввод только для свойств, которые не отмечены атрибутом NoDisplayAttribute . Это можно сделать, обратившись к [коллекции атрибутов](<https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/accessing-attributes-by-using-reflection>) для каждого свойства. Проверьте сами: для IdentityUser нужно запрашивать только три свойства.

Теперь сделаем красиво. Используйте существующие атрибуты D**escriptionAttribute** и **DefaultValueAttribute** , укажите их для свойств Имя пользователя (User name, «Me») , Email (Адрес электронной почты, «test@test») и Phone Number (Номер телефона, «1234567890») класса IdentityUser . Теперь модифицируем SetValues , чтобы при запросе данных выводился запрос с содержимым **DescriptionAttribute , а если пользователь не ввел данные, свойство заполнялось значением по умолчанию, указанным в DefaultValueAttribute**.

Остается только добавить в консоль сообщение об успешном завершении и вывести данные с помощью метода ToString().

Проверьте себя: передайте экземпляр другого класса в SetValue вместо экземпляра IdentityUser:
```
public class IdentityRole
{
   public IdentityRole()
   {
   }

   public string Name { get; set; }
   public string Description { get; set; }

   public override string ToString()
      => $"{Name}, {Description}";
}
```
#### Выходной формат
```
Let's set {typeName}
Set {propertyDescription}:

Set {propertyDescription}:

Set {propertyDescription}:
...

We've set our instance!
```
#### Примеры запуска приложения из папки проекта
```
$ dotnet run
Let's set IdentityUser!
Set User name:
Ann
Set Email address:
ann@test.ru
Set Phone number:
123000123

We've set our instance!
User: Ann, ann@test.ru, 123000123
```

### Упражнение 03 – Создание объектов
```
Структура проекта:
d07_ex03/
      Models/
              IdentityUser.cs
              IdentityRole.cs
      Program.cs
      TypeFactory.cs
```
Иногда при использовании отражения необходимо создать экземпляр определенного класса. Например, при реализации собственного **DI-контейнера**, когда вы регистрируете в нем свои типы, которые хотите использовать для внедрения зависимостей. Способов его использования может быть много. Но поскольку действие происходит во время выполнения, а создаваемый тип также известен только во время выполнения, у вас нет возможности использовать **ключевое слово new().**
Как создать экземпляр объекта во время выполнения?

Давайте реализуем фабричный класс **TypeFactory** , который будет предоставлять набор **статических** и **универсальных** методов:
- CreateWithConstructor
- CreateWithActivator

В каждом из них мы будем использовать отдельный метод для создания экземпляра класса T. Более того, нам будет важно, чтобы T был классом, давайте добавим [ограничение](<https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint>).

*CreateWithConstructor* позволит вам создать объект определенного типа с помощью конструктора объекта. Для его реализации необходимо с помощью рефлексии [получить объект типа ConstructorInfo](<https://learn.microsoft.com/en-us/dotnet/api/system.type.getconstructor?view=net-5.0>). Для простоты будем использовать конструктор без параметров, этот вариант описан в данной статье. Далее используйте метод **Invoke** — это позволит вызвать конструктор класса и получить созданный объект.

*CreateWithActivator* позволит вам создать объект типа, используя [методы](<https://learn.microsoft.com/en-us/dotnet/api/system.activator?view=net-5.0>) статического класса **Activator**.

Скопируйте классы *IdentityUser* и *IdentityRole* из упражнения 02 в проект. Используйте *TypeFactory* для создания двух объектов типа IdentityUser . Напоминаем, что для простоты при создании мы используем конструктор без параметров, но ConstructorInfo и Activator также позволяют создавать объекты с помощью конструктора с параметрами. Выведите «user1 == user2», если объекты равны, и «user1 != user2» в противном случае. Сделайте то же самое для класса IdentityRole .
Подумайте, какой вывод здесь должен быть правильным и [почему](,https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/equality-operators#reference-types-equality) ?


### Бонусное задание
Добавьте в класс *TypeFactory* метод *CreateWithParameters* , чтобы он принимал массив объектов (*object*) и с помощью метода класса *Activator* , позволяющего передавать параметры в конструктор, создавал экземпляр класса с помощью параметризованного конструктора. Создайте объект типа *IdentityUser* с указанным UserName и выведите его имя.

#### Выходной формат
```
$ dotnet run
d07_ex03.Models.IdentityUser
user1 != user2
d07_ex03.Models.IdentityRole
role1 != role2
```
#### Выходной формат (бонусное задание)
```
$ dotnet run
d07_ex03.Models.IdentityUser
user1 != user2
d07_ex03.Models.IdentityRole
role1 != role2

d07_ex03.Models.IdentityUser
Set name:
Activated user
Username set: Activated user
```
// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Microsoft.AspNetCore.Http;

DefaultHttpContext context = new DefaultHttpContext();

Console.WriteLine("Old Response value: " + context.Response);

Type contextType = typeof(DefaultHttpContext);

FieldInfo responseField = contextType.GetField("_response", BindingFlags.Instance | BindingFlags.NonPublic);

responseField.SetValue(context, null);

Console.WriteLine("New Response value: " + context.Response);
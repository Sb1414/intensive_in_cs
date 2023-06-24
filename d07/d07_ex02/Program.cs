// See https://aka.ms/new-console-template for more information

using d07_ex02.ConsoleSetter;
using d07_ex02.Models;

IdentityUser user = new IdentityUser();
ConsoleSetter.SetValues(user);

IdentityRole role = new IdentityRole();
ConsoleSetter.SetValues(role);
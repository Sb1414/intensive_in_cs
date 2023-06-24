// See https://aka.ms/new-console-template for more information
using d07_ex03;
using d07_ex03.Models;

IdentityUser user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
IdentityUser user2 = TypeFactory.CreateWithConstructor<IdentityUser>();

Console.WriteLine(typeof(IdentityUser).FullName);
Console.WriteLine(user1 == user2 ? "user1 == user2" : "user1 != user2");

IdentityRole role1 = TypeFactory.CreateWithActivator<IdentityRole>();
IdentityRole role2 = TypeFactory.CreateWithActivator<IdentityRole>();

Console.WriteLine(typeof(IdentityRole).FullName);
Console.WriteLine(role1 == role2 ? "role1 == role2" : "role1 != role2");

Console.WriteLine("\n" + typeof(IdentityUser).FullName);
Console.WriteLine("Set name:");
string name = Console.ReadLine();

object[] userParameters = { name };
IdentityUser user = TypeFactory.CreateWithParameters<IdentityUser>(userParameters);

Console.WriteLine("Username set: " + user.UserName);

// IdentityUser user1_ = TypeFactory.CreateWithConstructor<IdentityUser>();
// user1_.UserName = "Sb";
// user1_.Email = "Sb@gmail.com";
// user1_.PhoneNumber = "9876543210";
//
// IdentityUser user2_ = TypeFactory.CreateWithConstructor<IdentityUser>();
// user2_.UserName = "Sb";
// user2_.Email = "Sb@gmail.com";
// user2_.PhoneNumber = "9876543210";
//
// Console.WriteLine(typeof(IdentityUser).FullName);
// Console.WriteLine(user1_ == user2_ ? "user1_ == user2_" : "user1_ != user2_");
// Console.WriteLine(user1_.ToString());
// Console.WriteLine(user2_.ToString());

// IdentityRole role1_ = TypeFactory.CreateWithActivator<IdentityRole>();
// role1_.Name = "Admin";
// role1_.Description = "Administrator role";
//
// IdentityRole role2_ = TypeFactory.CreateWithActivator<IdentityRole>();
// role2_.Name = "Editor";
// role2_.Description = "Editor role";
//
// Console.WriteLine(typeof(IdentityRole).FullName);
// Console.WriteLine(role1_ == role2_ ? "role1_ == role2_" : "role1_ != role2_");
// Console.WriteLine(role1_.ToString());
// Console.WriteLine(role2_.ToString());
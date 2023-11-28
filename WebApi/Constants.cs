using KIKWebApi.Models;
using SnowflakeIdGeneratorForCSharp;

namespace KIKWebApi;

public static class Constants
{
    private static string user1Id = new SnowflakeIdGenerator(1, 1).CreateId().ToString();
    private static string user2Id = new SnowflakeIdGenerator(1, 2).CreateId().ToString();
    private static string user3Id = new SnowflakeIdGenerator(1, 3).CreateId().ToString();
    private static string user4Id = new SnowflakeIdGenerator(1, 4).CreateId().ToString();
    private static string user5Id = new SnowflakeIdGenerator(1, 5).CreateId().ToString();

    public static List<User> Users = new()
    {
        new User()
        {
            Id = user1Id,
            Email = "test1@test.com",
            UserName = "test1",
            Password = "Password12*",
            NameLastName = "Test Kullanıcı 1",
            RefreshToken = "",
            RefreshTokenExpires = DateTime.Now,
        },
        new User()
        {
            Id = user2Id,
            Email = "test2@test.com",
            UserName = "test2",
            Password = "Password12*",
            NameLastName = "Test Kullanıcı 2",
            RefreshToken = "",
            RefreshTokenExpires = DateTime.Now
        },
        new User()
        {
            Id = user3Id,
            Email = "test3@test.com",
            UserName = "test3",
            Password = "Password12*",
            NameLastName = "Test Kullanıcı 3",
            RefreshToken = "",
            RefreshTokenExpires = DateTime.Now
        },
        new User()
        {
            Id = user4Id,
            Email = "test4test.com",
            UserName = "test4",
            Password = "Password12*",
            NameLastName = "Test Kullanıcı 4",
            RefreshToken = "",
            RefreshTokenExpires = DateTime.Now
        },
        new User()
        {
            Id = user4Id,
            Email = "test5test.com",
            UserName = "test5",
            Password = "Password12*",
            NameLastName = "Test Kullanıcı 5",
            RefreshToken = "",
            RefreshTokenExpires = DateTime.Now
        }
    };

    public static List<UserRole> UserRoles = new()
    {
        new UserRole()
        {
            UserId = user1Id,
            RoleName = "Menu.Personel"
        },
         new UserRole()
        {
            UserId = user2Id,
            RoleName = "Menu.Personel"
        },
        new UserRole()
        {
            UserId = user3Id,
            RoleName = "Menu.Personel"
        },
        new UserRole()
        {
            UserId = user4Id,
            RoleName = "Menu.Personel"
        },
        new UserRole()
        {
            UserId = user5Id,
            RoleName = "Menu.Personel"
        },
        new UserRole()
        {
            UserId = user1Id,
            RoleName = "Personel.Create"
        },
        new UserRole()
        {
            UserId = user1Id,
            RoleName = "Personel.GetAll"
        },
        new UserRole()
        {
            UserId = user1Id,
            RoleName = "Personel.Update"
        },
        new UserRole()
        {
            UserId = user1Id,
            RoleName = "Personel.Remove"
        },
        new UserRole()
        {
            UserId = user2Id,
            RoleName = "Personel.Create"
        },
        new UserRole()
        {
            UserId = user2Id,
            RoleName = "Personel.GetAll"
        },
        new UserRole()
        {
            UserId = user2Id,
            RoleName = "Personel.Update"
        },
        new UserRole()
        {
            UserId = user3Id,
            RoleName = "Personel.Create"
        },
        new UserRole()
        {
            UserId = user3Id,
            RoleName = "Personel.GetAll"
        },
        new UserRole()
        {
            UserId = user4Id,
            RoleName = "Personel.GetAll"
        },
        new UserRole()
        {
            UserId = user5Id,
            RoleName = "Personel.Create"
        }
    };

    public static List<Personel> Personels = new()
    {
        new Personel()
        {
            ImageUrl = "personel.png",
            Name = "Babacan",
            LastName = "Kumcuoğlu",
            Profession = "Muhasebe",
            Salary = 25000,
            StartingDate = Convert.ToDateTime("01.10.2022"),
            LeavingDate = null,
            LeavingStatus = null
        },
        new Personel()
        {
            ImageUrl = "personel.png",
            Name = "Haluk",
            LastName = "Kavaklıoğlu",
            Profession = "Yazılım",
            Salary = 45000,
            StartingDate = Convert.ToDateTime("11.01.2023"),
            LeavingDate = null,
            LeavingStatus = null
        },
        new Personel()
        {
            ImageUrl = "personel.png",
            Name = "Mutahhar",
            LastName = "Ilıcalı",
            Profession = "İnsan Kaynakları",
            Salary = 37000,
            StartingDate = Convert.ToDateTime("01.01.2022"),
            LeavingDate = null,
            LeavingStatus = null
        },
        new Personel()
        {
            ImageUrl = "personel.png",
            Name = "Hüccet",
            LastName = "Ekşioğlu",
            Profession = "Depo Sorumlusu",
            Salary = 17000,
            StartingDate = Convert.ToDateTime("01.03.2022"),
            LeavingDate = Convert.ToDateTime("01.05.2022"),
            LeavingStatus = "İstifa"
        },
        new Personel()
        {
            ImageUrl = "personel.png",
            Name = "Tezcan",
            LastName = "Tüzün",
            Profession = "Depo Sorumlusu",
            Salary = 19000,
            StartingDate = Convert.ToDateTime("02.01.2022"),
            LeavingDate = Convert.ToDateTime("31.12.2022"),
            LeavingStatus = "İstifa"
        }
    };
}
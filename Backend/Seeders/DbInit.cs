using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using Backend.DbContexts;
using Backend.Models;
using System;

namespace Backend.Seeders
{
    public class DbInit
    {
        public static void Initialize(DbDispatchingSystem context)
        {
            // 新增資料的時候要注意，Id因為是PK，所以不用自己手動鍵入
            if(!context.Departments.Any())
            {
                var departments = new List<Department>()
                {
                    new Department { Name = "資訊部", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "人資部", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "業務部", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };
                context.Departments.AddRange(departments);
                context.SaveChanges();
            }
            
            if(!context.Users.Any())
            {
                var hasher = new PasswordHasher<User>();
                var users = new List<User>()
                {
                    new User 
                    { 
                        Name = "哆啦ａ夢", 
                        Department = context.Departments.Find(1),
                        Account = "account1", 
                        Password = hasher.HashPassword(null, "password1"), 
                        CreatedAt = DateTime.Now, 
                        UpdatedAt = DateTime.Now
                    },
                    new User
                    {
                        Name = "工藤新一",
                        Department = context.Departments.Find(2),
                        Account = "account2", 
                        Password = hasher.HashPassword(null, "password2"), 
                        CreatedAt = DateTime.Now, 
                        UpdatedAt = DateTime.Now
                    }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
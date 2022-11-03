using Manager.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.EF
{
    public class AppDbContext : DbContext
    {
        private static AppDbContext _instance;
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }

        public static AppDbContext Instance()
        {
            if (_instance == null)
            {
                _instance = new AppDbContext();
            }
            return _instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=manager;user=root;password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed Data
            // Class Room
            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom() { Id = 1, Name = "CNTT K18 A" });
            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom() { Id = 2, Name = "Quản trị kinh doanh" });

            // Students
            modelBuilder.Entity<Student>().HasData(new Student() { Id = 1, Name = "Huu Tai", Age = 20, ClassRoomId = 1 });
            modelBuilder.Entity<Student>().HasData(new Student() { Id = 2, Name = "Huy Hieu", Age = 20, ClassRoomId = 2 });
            modelBuilder.Entity<Student>().HasData(new Student() { Id = 3, Name = "Van Hoang", Age = 21, ClassRoomId = 1 });
            modelBuilder.Entity<Student>().HasData(new Student() { Id = 4, Name = "Anh Kiet", Age = 20, ClassRoomId = 2});

            
            #endregion
        }
    }
}

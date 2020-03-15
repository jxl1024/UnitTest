using Microsoft.EntityFrameworkCore;
using UnitTest.Model;

namespace UnitTest.Data
{
    /// <summary>
    /// 数据上下文类
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 通过构造函数给父类构造传参
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("T_Student");
            modelBuilder.Entity<Student>().HasKey(p => p.ID);
            modelBuilder.Entity<Student>().Property(p => p.Name).HasMaxLength(32);

            // 添加种子数据
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    ID = 1,
                    Name = "测试1",
                    Age = 20,
                    Gender = "男"
                },
                new Student()
                {
                    ID = 2,
                    Name = "测试2",
                    Age = 22,
                    Gender = "女"
                },
                new Student()
                {
                    ID = 3,
                    Name = "测试3",
                    Age = 23,
                    Gender = "男"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}

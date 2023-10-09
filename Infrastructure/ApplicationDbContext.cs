using Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var CategoryGuid = Guid.NewGuid().ToString();
            var PostGuid = Guid.NewGuid().ToString();

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = CategoryGuid,
                Name = "Category 1"
            }) ;

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = PostGuid,
                Title = "Post 1 Title",
                Content = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla ",
                CategoryId = CategoryGuid

            });
           

        }

        public DbSet<Post> Posts { get; set; }


    }
}

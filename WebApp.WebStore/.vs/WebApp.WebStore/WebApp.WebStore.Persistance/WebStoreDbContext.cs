using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Common;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance
{
    public class WebStoreDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<BrandType> BrandTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<SizeType> SizeTypes { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductsCategories { get; set; }

        //  public DbSet<ProductPicture> ProductsPictures { get; set; }

        public DbSet<ProductSizeType> ProductsSizeTypes { get; set; }

        public DbSet<Picture> Pictures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebStoreDbContext).Assembly); // it will search all configurations in an assembly and apply them


            modelBuilder.Entity<ProductSizeType>()
                .HasKey(c => new { c.ProductID, c.SizeTypeID });



            modelBuilder.Entity<ProductSizeType>()
            .HasOne(c => c.Product)
            .WithMany(p => p.ProductSizeType)
            .HasForeignKey(c => c.ProductID);


            modelBuilder.Entity<ProductSizeType>()
            .HasOne(c => c.SizeType)
            .WithMany(p => p.ProductSizeType)
            .HasForeignKey(c => c.SizeTypeID);



            modelBuilder.Entity<ProductCategory>()
              .HasKey(c => new { c.ProductID, c.CategoryID });

            modelBuilder.Entity<ProductCategory>()
            .HasOne(c => c.Product)
            .WithMany(p => p.ProductCategory)
            .HasForeignKey(c => c.ProductID);


            modelBuilder.Entity<ProductCategory>()
            .HasOne(c => c.Category)
            .WithMany(p => p.ProductCategory)
            .HasForeignKey(c => c.CategoryID);


            modelBuilder.Entity<Product>()
            .Property(p => p.Uid)
            .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<Order>()
           .Property(o => o.Uid)
           .HasDefaultValueSql("NEWID()");


            //modelBuilder.Entity<ProductPicture>()
            //.HasKey(c => new { c.ProductID, c.PictureID });


            //modelBuilder.Entity<ProductPicture>()
            //.HasOne(c => c.Product)
            //.WithMany(p => p.ProductPicture)
            //.HasForeignKey(c => c.ProductID);


            //modelBuilder.Entity<ProductPicture>()
            //.HasOne(c => c.Picture)
            //.WithMany(p => p.ProductPicture)
            //.HasForeignKey(c => c.PictureID);





            modelBuilder.Entity<SizeType>()
          .HasData(
         new SizeType()
         {
             SizeTypeEID = 1,
             Caption = "S"
         },
         new SizeType()
         {
             SizeTypeEID = 2,
             Caption = "L"
         }
        ,
         new SizeType()
         {
             SizeTypeEID = 3,
             Caption = "XL"
         }
         ,
         new SizeType()
         {
             SizeTypeEID = 4,
             Caption = "XXL"
         }
         ,
         new SizeType()
         {
             SizeTypeEID = 5,
             Caption = "XXXL"
         }

         );







            modelBuilder.Entity<Category>()
            .HasData(
            new Category()
            {
                CategoryID = 1,
                Caption = "Shoes"
            },
            new Category()
            {
                CategoryID = 2,
                Caption = "Clothes"
            }
           ,
            new Category()
            {
                CategoryID = 3,
                Caption = "Jackets"
            }
            ,
            new Category()
            {
                CategoryID = 4,
                Caption = "Shirts"
            }
            ,
            new Category()
            {
                CategoryID = 5,
                Caption = "Sneakers"
            }

            );


            modelBuilder.Entity<BrandType>()
             .HasData(
             new BrandType()
             {
                 BrandTypeEID = 1,
                 Caption = "Puma"
             },
             new BrandType()
             {
                 BrandTypeEID = 2,
                 Caption = "Nike"
             },
             new BrandType()
             {
                 BrandTypeEID = 3,
                 Caption = "Adidas"
             }

             );





        }





        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options) : base(options)
        {


            //Database.EnsureCreated();

        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }

            }
            return base.SaveChangesAsync(cancellationToken);


        }




    }
}

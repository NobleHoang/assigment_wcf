using baseNetApi.models;
using Microsoft.EntityFrameworkCore;

namespace baseNetApi.context;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }
    
    public void Seed()
    {
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                id = 1, role = Role.Admin, username = "admin",email = "admin@gmail.com",
                firstName = "Hiéu", lastName = "Hoang",
                phoneNumber = "0375886096", address = "VietNam",
                birthday = "20-10-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            },
            new User(){
                id = 2, role = Role.User, username = "user",email = "user@gmail.com",
                firstName = "User", lastName = "New",
                phoneNumber = "0968886868", address = "VietNam",
                birthday = "00-00-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
                
            }
        );
        modelBuilder.Entity<Categories>().HasData(
            new Categories()
            {
                id = 1, category = "Home"
            },
            new Categories()
            {
                id = 2, category = "Camera"
            },
            new Categories()
            {
                id = 3, category = "Card"
            }
        );
        modelBuilder.Entity<Products>().HasData(
            new Products()
            {
                id = 1, category_id = 1, name = "DSLA 60D",description = "Canon",
                quantity = 100, thubnail = "https://bizweb.dktcdn.net/100/107/650/products/1434876014-60dwith18-135mm1-1.jpg?v=1507629831483",
                status = ProductStatus.ACTIVE, price = "100.00"
            },
            new Products(){
                id = 2, category_id = 1, name = "XT-100",description = "FUjifilm",
                quantity = 250, thubnail = "https://cdn.vjshop.vn/may-anh/mirrorless/fujifilm/fujifilm-x-t100/fujifilm-x-t100-black-500x500.jpg",
                status = ProductStatus.ACTIVE, price = "599.99"
            },
            new Products()
            {
                id = 3, category_id = 3, name = "16Gb",description = "Kingston",
                quantity = 100, thubnail = "https://media.kingston.com/kingston/hero/ktc-hero-flash-microsd-sdce-lg.jpg",
                status = ProductStatus.ACTIVE, price = "100.00"
            }
        );
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initilize(StoreContext context){
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                        name = "Angular Speedster Board 2000",
                    description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    price = 20000,
                    pictureUrl = "/images/products/sb-ang1.png",
                    brand = "Angular",
                    type = "Boards",
                    quantityInStock = 100
                },
                    new Product
                    {
                        name = "Green Angular Board 3000",
                        description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        price = 15000,
                        pictureUrl = "/images/products/sb-ang2.png",
                        brand = "Angular",
                        type = "Boards",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Core Board Speed Rush 3",
                        description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        price = 18000,
                        pictureUrl = "/images/products/sb-core1.png",
                        brand = "NetCore",
                        type = "Boards",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Net Core Super Board",
                        description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        price = 30000,
                        pictureUrl = "/images/products/sb-core2.png",
                        brand = "NetCore",
                        type = "Boards",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "React Board Super Whizzy Fast",
                        description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 25000,
                        pictureUrl = "/images/products/sb-react1.png",
                        brand = "React",
                        type = "Boards",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Typescript Entry Board",
                        description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 12000,
                        pictureUrl = "/images/products/sb-ts1.png",
                        brand = "TypeScript",
                        type = "Boards",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Core Blue Hat",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1000,
                        pictureUrl = "/images/products/hat-core1.png",
                        brand = "NetCore",
                        type = "Hats",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Green React Woolen Hat",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 8000,
                        pictureUrl = "/images/products/hat-react1.png",
                        brand = "React",
                        type = "Hats",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Purple React Woolen Hat",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1500,
                        pictureUrl = "/images/products/hat-react2.png",
                        brand = "React",
                        type = "Hats",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Blue Code Gloves",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1800,
                        pictureUrl = "/images/products/glove-code1.png",
                        brand = "VS Code",
                        type = "Gloves",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Green Code Gloves",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1500,
                        pictureUrl = "/images/products/glove-code2.png",
                        brand = "VS Code",
                        type = "Gloves",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Purple React Gloves",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1600,
                        pictureUrl = "/images/products/glove-react1.png",
                        brand = "React",
                        type = "Gloves",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Green React Gloves",
                        description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 1400,
                        pictureUrl = "/images/products/glove-react2.png",
                        brand = "React",
                        type = "Gloves",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Redis Red Boots",
                        description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        price = 25000,
                        pictureUrl = "/images/products/boot-redis1.png",
                        brand = "Redis",
                        type = "Boots",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Core Red Boots",
                        description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        price = 18999,
                        pictureUrl = "/images/products/boot-core2.png",
                        brand = "NetCore",
                        type = "Boots",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Core Purple Boots",
                        description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        price = 19999,
                        pictureUrl = "/images/products/boot-core1.png",
                        brand = "NetCore",
                        type = "Boots",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Angular Purple Boots",
                        description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        price = 15000,
                        pictureUrl = "/images/products/boot-ang2.png",
                        brand = "Angular",
                        type = "Boots",
                        quantityInStock = 100
                    },
                    new Product
                    {
                        name = "Angular Blue Boots",
                        description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        price = 18000,
                        pictureUrl = "/images/products/boot-ang1.png",
                        brand = "Angular",
                        type = "Boots",
                        quantityInStock = 100
                    },
                };

                foreach(var product in products)
                {
                    context.Products.Add(product);
                }
                context.SaveChanges();
        }
    }
}
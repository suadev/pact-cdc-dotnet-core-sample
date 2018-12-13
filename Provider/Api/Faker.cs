using System.Collections.Generic;
using Provider.Model;

namespace Provider
{
    public class Faker
    {
        public static List<ProductModel> GetProducts()
        {
            return new List<ProductModel>{
                    new ProductModel
                    {
                        Id = 1,
                        CategoryId =2,
                        Name = "Printer",
                        UnitPrice = 200
                    },
                    new ProductModel
                    {
                        Id =2,
                        CategoryId =2,
                        Name = "Scanner",
                        UnitPrice = 600
                    },
                    new ProductModel
                    {
                        Id =3,
                        CategoryId =2,
                        Name = "Keyboard",
                        UnitPrice = 100
                    },
                    new ProductModel
                    {
                        Id =5,
                        CategoryId =5,
                        Name = "Duster",
                        UnitPrice = 10
                    },
                   new ProductModel
                    {
                        Id =6,
                        CategoryId =5,
                        Name = "Pencil",
                        UnitPrice = 20
                    }
            };
        }
    }
}
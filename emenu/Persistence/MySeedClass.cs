using emenu.Core.Contracts;
using emenu.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Persistence
{
    public static class MySeedClass
    {
        static readonly Random rand = new Random();
        public static void Seed(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
      
           
            SeedProducts(context);
            context.SaveChanges();
            unitOfWork.Complete();

            SeedVariants(context);
            context.SaveChanges();
            unitOfWork.Complete();

        }


      
        public static void SeedProducts(ApplicationDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                context.Products.AddRange(new Product[]
                {
                        new Product
                        {
                            NameEn = "Iphone",
                            NameAr = "موبايل " ,
                        },
                         new Product
                        {
                            NameEn = "TShirt",
                            NameAr = "قميص" ,
                        },
                 });
            }

        }

        public static void SeedVariants(ApplicationDbContext context)
        {
            if (context.Variants.Count() == 0)
            {
                context.Variants.AddRange(new Variant[]
                {
                        new Variant
                        {
                            NameEn = "color",
                            NameAr = "اللون" ,
                        },
                         new Variant
                        {
                            NameEn = "size",
                            NameAr = "الحجم" ,
                        },
                 });
            }

        }
        public static void SeedVariantValues(ApplicationDbContext context)
        {
            if (context.VariantValues.Count() == 0)
            {
                context.VariantValues.AddRange(new VariantValue[]
                {
                        new VariantValue
                        {
                            ValueEn = "red",
                            ValueAr = "أحمر" ,
                            VariantId = 1,
                        },
                        new VariantValue
                        {
                            ValueEn = "blue",
                            ValueAr = "أزرق" ,
                            VariantId = 1,
                        },
                        new VariantValue
                        {
                            ValueEn = "green",
                            ValueAr = "أخضر" ,
                            VariantId = 1,
                        },
                        new VariantValue
                        {
                            ValueEn = "small",
                            ValueAr = "صغير" ,
                            VariantId = 2,
                        },
                        new VariantValue
                        {
                            ValueEn = "big",
                            ValueAr = "كبير" ,
                            VariantId = 2
                        }
                 });
            }

        }

        public static void SeedProductVariant(ApplicationDbContext context)
        {
            if (context.ProductVariants.Count() == 0)
            {
                context.ProductVariants.AddRange(new ProductVariant[]
                {
                        new ProductVariant
                        {
                            ProductId = 1,
                            ProductDetails = new ProductDetails[]
                            {
                                new ProductDetails
                                { 
                                    VariantValueId = 7,
                                },
                                new ProductDetails
                                {
                                    VariantValueId = 11,
                                },
                            }
                          
                        }
                       

                 });
            }

        }


        private static string RandName()
        {
            string[] maleNames = new string[] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
            string[] femaleNames = new string[] { "abby", "abigail", "adele", "adrian" };
            string[] lastNames = new string[] { "abbott", "acosta", "adams", "adkins", "aguilar" };

            string name;
            if (rand.Next(1, 2) == 1)
            {
                name = maleNames[rand.Next(0, maleNames.Length - 1)];
            }
            else
            {
                name = femaleNames[rand.Next(0, femaleNames.Length - 1)];
            }

            return name;

        }

        public static string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }
    }
}

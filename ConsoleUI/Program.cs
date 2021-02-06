﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             ProductTest();
            //Ioc
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAll())//hepsini getirir
            //{
            //    Console.WriteLine(product.ProductName);

            //}

            //foreach (var product in productManager.GetAllByCategoryId(2))//kategorısı 2 olanlar gelen 
            //{
            //    Console.WriteLine(product.ProductName);

            //}

            //foreach (var product in productManager.GetByUnitPrice(40, 100))//kategorısı 2 olanlar gelen 
            //{
            //    Console.WriteLine(product.ProductName);

            //}

            foreach (var product in productManager.GetProductDetails())//kategorısı 2 olanlar gelen 
            {
                Console.WriteLine(product.ProductName +"/"+product.CategoryName);

            }
        }
    }
}

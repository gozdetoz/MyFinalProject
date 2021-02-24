using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static verildiğinde newlemiyoruz
    public static class Messages
    {
        public static string MaintanceTime="Sitem Bakımda";
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed="Ürünler Listelendi";
        public static string ProductCountOfCategoryError  ="Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün mevcuttur.Eklenemez!!";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldı.";


    }
}

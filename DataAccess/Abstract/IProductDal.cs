using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
//code Refactoring -kodun ıyılestırılmesı
namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
   {
        List<ProductDetailDto> GetProductDetails();
   }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //bir classın defaultu internaldır.Sadece o projede olanlar erişebilir .Diğer katmanlardında erişebilmesi için public yaptık
    public class Product: IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}

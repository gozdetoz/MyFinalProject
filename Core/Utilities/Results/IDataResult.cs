using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //List<Product> gibi nesneler ıcın yaptıgımız yer
    //Mesaj ve donus tıpını IResult dan aldık burda donecegımız datayı tanımlıyoruz
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}

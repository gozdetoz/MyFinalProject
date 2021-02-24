using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //Busines için iş kuralları genel olarak yazdıgımı yer.
    //params IResult[] logics  --run içerisine isteğimiz kadar kural gonderebliriz
    //başarısız olanı gonderrrıyoruz
    //logics  kurallar
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic;
                }

            }
            return null;
        }
    }
}

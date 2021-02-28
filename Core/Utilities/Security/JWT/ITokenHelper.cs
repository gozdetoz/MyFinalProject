using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kulanıcı bilgilerini dogru girdiği zaman api bu bılgilerle veritabanına gıdıp yetkılerını alıp jwt seklınde kullanıcıya verev-cek
        AccessToken CreateToken(User user ,List<OperationClaim> operationClaims);
    }
}

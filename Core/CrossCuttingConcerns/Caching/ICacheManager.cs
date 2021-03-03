using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value ,int duration);
        //cache de var mı 
        bool IsAdd(string key);
        //cache den ucurma
        void Remove(string key);
        //key anahtarını belirlemek için bir patern yarat orn GetAll ile baslayanlar gibi..
        void RemoveByPattern(string pattern);

    }
}

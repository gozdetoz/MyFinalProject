using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //Genel bağımlılıkları yükleyecek .Servislerımızı burası yukleyecek
    //
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}

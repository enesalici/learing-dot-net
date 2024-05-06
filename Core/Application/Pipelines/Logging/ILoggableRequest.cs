using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging
{
    public interface ILoggableRequest
    {
        // bu interface sadece imza için kullanılır loglama yapmak istediğimiz 
        // Classlara ILoggableRequest imzasını veririz ve o class calıstığında LoggingBehavior çalışır
        // imzalama yapmak için bu ILoggableRequest interfacesinden kalıtım alınır 
    }
}

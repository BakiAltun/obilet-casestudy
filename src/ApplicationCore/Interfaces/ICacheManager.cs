using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces
{
    public interface ICacheManager
    {
        T GetOrCreate<T>(Func<T> get) where T : class;
    }
}

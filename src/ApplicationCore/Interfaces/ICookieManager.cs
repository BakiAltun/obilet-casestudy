﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces
{
    public interface ICookieManager
    {
        string Get(string key);

        void Set(string key, string value, DateTime? expireDate);

        T Get<T>();
        void Set<T>(T model);
    }
}

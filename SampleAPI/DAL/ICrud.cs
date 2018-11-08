﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.DAL
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(string id);
    }
}

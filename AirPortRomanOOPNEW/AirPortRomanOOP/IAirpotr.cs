﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    interface IAirpotr<T>
    {
        void AddItem();
        T EditItem(T item);
        void DeleteItem(T item);       
    }
}

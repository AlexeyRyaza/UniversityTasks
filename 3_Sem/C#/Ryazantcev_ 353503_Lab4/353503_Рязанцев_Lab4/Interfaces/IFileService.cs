﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab4
{
    internal interface IFileService<T>
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
    }
}

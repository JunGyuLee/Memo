using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJMemo.Models.Enums
{
    [Flags]
    public enum ENoteCategory
    {
        NONE = 0,
        Task = 1 >> 0
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    interface IItemState
    {
        IItemState Left();
        IItemState Right();
    }
}

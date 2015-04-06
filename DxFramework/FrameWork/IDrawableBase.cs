using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    interface IDrawableBase
    {
        Action DrawAction { get; }

        bool IsVisible { get; set; }
    }
}

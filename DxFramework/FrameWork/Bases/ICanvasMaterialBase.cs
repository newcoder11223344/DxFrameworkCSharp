using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Bases
{
    interface ICanvasMaterialBase : IDrawableBase
    {
        Vector2 Size { get; set; }
    }
}

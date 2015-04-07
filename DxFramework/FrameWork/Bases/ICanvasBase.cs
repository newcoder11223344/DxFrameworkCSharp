using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Bases
{
    interface ICanvasBase : IDrawableBase
    {
        Vector2 Size { get; set; }　　　　　　　　 // 左上を基準にしたサイズ
    }
}

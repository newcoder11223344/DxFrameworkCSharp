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
        Vector2 Top { get; set; }　　　　　　　　　// 左上の座標

        Vector2 Size { get; set; }　　　　　　　　 // 左上を基準にしたサイズ

        Vector2 Bottom { get; set; }              // 右下の座標

        Vector2 Mid { get; set; }                 // 中心の座標
    }
}

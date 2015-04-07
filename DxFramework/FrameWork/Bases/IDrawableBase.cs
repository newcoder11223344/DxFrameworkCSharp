using System;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Bases
{
    interface IDrawableBase
    {
        Action<Vector2> DrawAction { get; }

        bool IsVisible { get; set; }
    }
}

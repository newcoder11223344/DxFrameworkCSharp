using System;

namespace DxFramework.FrameWork.Bases
{
    interface IDrawableBase
    {
        Action DrawAction { get; }

        bool IsVisible { get; set; }
    }
}

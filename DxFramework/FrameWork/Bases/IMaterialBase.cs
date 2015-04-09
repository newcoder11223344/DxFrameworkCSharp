using System;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Bases
{
    interface IMaterialBase
    {
        Action<Vector2> DrawAction { get; }

        bool IsVisible { get; set; }
    }
}

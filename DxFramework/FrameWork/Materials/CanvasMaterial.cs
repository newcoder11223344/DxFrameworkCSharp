using System;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork.Materials
{
    class CanvasMaterial : ICanvasMaterialBase
    {
        public CanvasMaterial()
            : this(new Vector2(100, 50))
        {
            IsVisible = true;
        }

        public CanvasMaterial(Vector2 size)
        {
            IsVisible = true;
            Size = size;
            BackGroundColor = new Color(0, 0, 0);　　　　　　// デフォルトカラーが設定されています。
            OutLineColor = new Color(255, 255, 255);
            DrawAction = (top) =>                            // デフォルトは長方形を描画します。
            {
                DX.DrawBox((int)top.x, (int)top.y, (int)(top.x+size.x), (int)(top.y+size.y), BackGroundColor.DxCoolor, DX.TRUE);
                DX.DrawBox((int)top.x, (int)top.y, (int)(top.x+size.x), (int)(top.y+size.y), OutLineColor.DxCoolor, DX.FALSE);
            };
        }

        public Vector2 Size { get; set; }　　　　　　　　 // 左上を基準にしたサイズ

        public Color BackGroundColor { get; set; }　　　　　// 背景色

        public Color OutLineColor { get; set; }　　　　　　 // 輪郭色

        public bool IsVisible { get; set; }

        public virtual Action<Vector2> DrawAction { get; set; }
    }
}

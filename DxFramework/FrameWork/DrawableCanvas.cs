using DxLibDLL;

namespace DxFramework.FrameWork
{
    class DrawableCanvas : DrawableObject
    {
        public DrawableCanvas()
            : this(new Vector2(0, 0), new Vector2(100, 50))
        {

        }

        public DrawableCanvas(Vector2 top, Vector2 size)
        {
            Top = top;
            Size = size;
            BackGroundColor=new Color(0, 0, 0);　　　　　　　　　// デフォルトカラーが設定されています。
            OutLineColor=new Color(255, 255, 255);
            DrawAction = () =>                            // デフォルトでは長方形を描画します。
            {
                DX.DrawBox((int)Top.x, (int)Top.y, (int)Bottom.x, (int)Bottom.y, BackGroundColor.DxCoolor, DX.TRUE);
                DX.DrawBox((int)Top.x, (int)Top.y, (int)Bottom.x, (int)Bottom.y, OutLineColor.DxCoolor, DX.FALSE);
            };
        }

        public Vector2 Top { get; set; }　　　　　　　　　// 左上の座標

        public Vector2 Size { get; set; }　　　　　　　　 // 左上を基準にしたサイズ

        public Vector2 Bottom { get { return Top + Size; } set { Top = value - Size; } }       // 右下の座標

        public Vector2 Mid { get { return Top + Size / 2; } set { Top = value - Size / 2; } }  // 中心の座標

        public Color BackGroundColor { get; set; }　　　　　// 背景色

        public Color OutLineColor { get; set; }　　　　　　 // 輪郭色
    }
}

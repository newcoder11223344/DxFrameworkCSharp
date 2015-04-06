using System;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    class Graphic : Canvas
    {
        protected int GraphHandle { get; private set; }

        public new Vector2 Top { get; set; }　　　　　　　　　// 左上の座標

        public new Vector2 Size { get; set; }　　　　　　　　 // 左上を基準にしたサイズ

        public new Vector2 Bottom { get { return Top + Size; } set { Top = value - Size; } }       // 右下の座標

        public new Vector2 Mid { get { return Top + Size / 2; } set { Top = value - Size / 2; } }  // 中心の座標

        public override Action DrawAction {
            get
            {
               return () =>
               {
                   DX.DrawGraphF((float) Top.x, (float) Top.y, GraphHandle, 1);
               };
            }
        }

        public Graphic()
        {
            Top = new Vector2(0, 0);
          
        }

        public Graphic(Vector2 top, string graphName)
        {
            setGraph(graphName);
            Top = top;
          
        }

        // グラフィックハンドルを設定します。
        // サイズも自動的に設定されます。
        public void setGraph(int handle)
        {
            GraphHandle = handle;
            int x, y;
            DX.GetGraphSize(GraphHandle, out x, out y);
            Size = new Vector2(x, y);
        }

        // ディレクトリからグラフィックハンドルを設定します。
        // サイズも自動的に設定されます。
        public void setGraph(string filename)
        {
            setGraph(DX.LoadGraph(filename));
        }

        // Action型引数からグラフィックハンドルを作成します。
        public void setSquare(Vector2 size, Action draw)
        {
            GraphHandle = DX.MakeGraph((int)size.x, (int)size.y);
            DX.SetDrawScreen(GraphHandle);
            draw();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        }


    }
}

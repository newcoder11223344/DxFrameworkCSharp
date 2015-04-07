using System;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    class Graphic : Canvas
    {
        public Graphic()
        {  
        }

        public Graphic(string graphName)
        {
            setGraph(graphName);
        }

        public Graphic(int handle)
        {
            IsVisible = true;
            setGraph(handle);

        }
        public int GraphHandle { get; private set; }

        public override Action<Vector2> DrawAction
        {
            get
            {
                return (top) =>
                {
                    DX.DrawGraphF((float)top.x, (float)top.y, GraphHandle, 1);
                };
            }
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

using System;
using System.Linq;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    internal class AutoDrawnButton : AutoDrawnText
    {
        public AutoDrawnButton(int layer)
            : base(layer)
        {
            init();
        }
        public AutoDrawnButton(int layer, Vector2 top)
            : base(layer)
        {
            init();
            Top = top;
        }
        public AutoDrawnButton(int layer, Vector2 top, Action clicked)
            : base(layer)
        {
            init();
            Top = top;
            ClickedEvent += (sender, e) =>
            {
                clicked();
            };
        }
        public AutoDrawnButton(int layer, Vector2 top, Action clicked, string text)
            : base(layer)
        {
            init();
            Top = top;
            Text.String = text;
            ClickedEvent += (sender, e) =>
            {
                clicked();
            };
        }

        public void init()
        {
            BackGroundFlag = true;
            Size = new Vector2(100, 50);
            Canvas = new MultiCanvas(new Canvas(Size), new Canvas(Size), new Canvas(Size), new Canvas(Size));
            BunedFlag = false;
            changeColor(new Color(200, 200, 200), new Color(0, 0, 0));
            setTextPosition(TextPos.Mid);
        }

        public MultiCanvas Canvas
        {
            get { return base.Canvas as MultiCanvas; }
            set { base.Canvas = value; }
        }

        public bool BunedFlag { get; set; } //有効かどうか

        public ICanvasBase DefaltCanvas 　// 通常時描画対象
        {
            get { return Canvas[0]; }
            set { Canvas[0] = value; }
        }

        public ICanvasBase MousOnCanvas // マウスオーバー時描画対象
        {
            get { return Canvas[1]; }
            set { Canvas[1] = value; }
        }

        public ICanvasBase ClickedCanvas // クリック時描画対象
        {
            get { return Canvas[2]; }
            set { Canvas[2] = value; }
        }

        public ICanvasBase BunedCanvas // 失効時描画対象
        {
            get { return Canvas[3]; }
            set { Canvas[3] = value; }
        }


        public void setGraph(Graphic canvas)
        {
            int handle1 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            int handle2 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            int handle3 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            DX.GraphFilterBlt(canvas.GraphHandle, handle1, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 50);
            DX.GraphFilterBlt(canvas.GraphHandle, handle2, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 100);
            DX.GraphFilterBlt(canvas.GraphHandle, handle3, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 100);
            DefaltCanvas = canvas;
            MousOnCanvas = new Graphic(handle1);
            ClickedCanvas = new Graphic(handle2);
            BunedCanvas = new Graphic(handle3);
            Size = canvas.Size;
        }

        public void changeColor(Color backgroundColor,Color outlineColor)
        {
            foreach (var itr in Canvas.OfType<Canvas>())
            {
                (itr).BackGroundColor = backgroundColor;
                (itr).OutLineColor = outlineColor;
            }

            ((Canvas)MousOnCanvas).BackGroundColor += new Color(20, 20, 20);
            ((Canvas)ClickedCanvas).BackGroundColor += new Color(50, 50, 50);
            ((Canvas)BunedCanvas).BackGroundColor += new Color(50, 50, 50);
        }
        public void setColor(Color backgroundColor)
        {
            changeColor(backgroundColor, backgroundColor);
        }

        public void setGraph(int handle)
        {
            setGraph(new Graphic(handle));
        }

        public void setGraph(string graphName)
        {
            setGraph(new Graphic(graphName));
        }

        public override void update()
        {
            if (BunedFlag)
            {
                Canvas.drawOnly(4);
                return;
            }
            else if (isPressed())
            {
                Canvas.drawOnly(3);
            }
            else if (isMouseOn())
            {
                Canvas.drawOnly(2);
            }
            else
            {
                Canvas.drawOnly(1);
            }
            base.update();
        }
    }
}


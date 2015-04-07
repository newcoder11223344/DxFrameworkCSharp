using System;
using System.Linq;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    internal class AutoDrawnButton : AutoDrawnCanvas
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
        public new MultiCanvas Canvas
        {
            get { return base.Canvas as MultiCanvas; }
            set { base.Canvas = value; }
        }

        public MultiCanvas ButtonCanvas { get; set; }

        public bool BunedFlag { get; set; } //有効かどうか

        public Text Text
        {
            get { return (Text)Canvas[1]; }
            set { Canvas[1] = value; }
        }

        public ICanvasBase DefaltCanvas 　// 通常時描画対象
        {
            get { return ButtonCanvas[0]; }
            set { ButtonCanvas[0] = value; }
        }

        public ICanvasBase MousOnCanvas // マウスオーバー時描画対象
        {
            get { return ButtonCanvas[1]; }
            set { ButtonCanvas[1] = value; }
        }

        public ICanvasBase ClickedCanvas // クリック時描画対象
        {
            get { return ButtonCanvas[2]; }
            set { ButtonCanvas[2] = value; }
        }

        public ICanvasBase BunedCanvas // 失効時描画対象
        {
            get { return ButtonCanvas[3]; }
            set { ButtonCanvas[3] = value; }

        }



        public void init()
        {
            ButtonCanvas = new MultiCanvas(new Canvas(Top, Size), new Canvas(Top, Size), new Canvas(Top, Size), new Canvas(Top, Size));
            Canvas = new MultiCanvas(ButtonCanvas, new Text("新しいボタン"));

            Text.Top = Top;
            Text.Size = Size;
            Text.Color = new Color(0, 0, 0);
            Text.setTextPosition(Text.TextPos.Mid);

            BunedFlag = false;

            changeColor(new Color(200, 200, 200), new Color(0, 0, 0));

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
            MousOnCanvas = new Graphic(Top, handle1);
            ClickedCanvas = new Graphic(Top, handle2);
            BunedCanvas = new Graphic(Top, handle3);
            Size = canvas.Size;
            Top = canvas.Top;
        }

        public void changeColor(Color backgroundColor,Color outlineColor)
        {
            foreach (var itr in ButtonCanvas.OfType<Canvas>())
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
            setGraph(new Graphic(Top, handle));
        }

        public void setGraph(string graphName)
        {
            setGraph(new Graphic(Top, graphName));
        }

        public override void update()
        {
            if (BunedFlag)
            {
                ButtonCanvas.drawOnly(4);
                return;
            }
            else if (isPressed())
            {
                ButtonCanvas.drawOnly(3);
            }
            else if (isMouseOn())
            {
                ButtonCanvas.drawOnly(2);
            }
            else
            {
                ButtonCanvas.drawOnly(1);
            }
            base.update();
        }
    }
}


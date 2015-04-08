using System;
using System.Linq;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Materials;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    internal class Button : TextBlock
    {
        public Button(int layer)
            : base(layer)
        {
            init();
        }
        public Button(int layer, Vector2 top)
            : base(layer)
        {
            init();
            Top = top;
        }
        public Button(int layer, Vector2 top, Action clicked)
            : base(layer)
        {
            init();
            Top = top;
            ClickedEvent += (sender, e) =>
            {
                clicked();
            };
        }
        public Button(int layer, Vector2 top, Action clicked, string text)
            : base(layer)
        {
            init();
            Top = top;
            TextMaterial.String = text;
            ClickedEvent += (sender, e) =>
            {
                clicked();
            };
        }

        public void init()
        {
            BackGroundFlag = true;
            Size = new Vector2(100, 50);
            Canvas = new MultiCanvasMaterial(new SquareMaterial(Size), new SquareMaterial(Size), new SquareMaterial(Size), new SquareMaterial(Size));
            BunedFlag = false;
            changeColor(new Color(200, 200, 200), new Color(0, 0, 0));
            setTextPosition(TextPos.Mid);
        }

        public MultiCanvasMaterial Canvas
        {
            get { return base.Material as MultiCanvasMaterial; }
            set { base.Material = value; }
        }

        public bool BunedFlag { get; set; } //有効かどうか

        public ISquareMaterialBase DefaltCanvas 　// 通常時描画対象
        {
            get { return Canvas[0]; }
            set { Canvas[0] = value; }
        }

        public ISquareMaterialBase MousOnCanvas // マウスオーバー時描画対象
        {
            get { return Canvas[1]; }
            set { Canvas[1] = value; }
        }

        public ISquareMaterialBase ClickedCanvas // クリック時描画対象
        {
            get { return Canvas[2]; }
            set { Canvas[2] = value; }
        }

        public ISquareMaterialBase BunedCanvas // 失効時描画対象
        {
            get { return Canvas[3]; }
            set { Canvas[3] = value; }
        }


        public void setGraph(GraphicMaterial canvas)
        {
            int handle1 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            int handle2 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            int handle3 = DX.MakeGraph((int)canvas.Size.x, (int)canvas.Size.y);
            DX.GraphFilterBlt(canvas.GraphHandle, handle1, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 50);
            DX.GraphFilterBlt(canvas.GraphHandle, handle2, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 100);
            DX.GraphFilterBlt(canvas.GraphHandle, handle3, DX.DX_GRAPH_FILTER_HSB, 0, 0, 0, 100);
            DefaltCanvas = canvas;
            MousOnCanvas = new GraphicMaterial(handle1);
            ClickedCanvas = new GraphicMaterial(handle2);
            BunedCanvas = new GraphicMaterial(handle3);
            Size = canvas.Size;
        }

        public void changeColor(Color backgroundColor,Color outlineColor)
        {
            foreach (var itr in Canvas.OfType<SquareMaterial>())
            {
                (itr).BackGroundColor = backgroundColor;
                (itr).OutLineColor = outlineColor;
            }

            ((SquareMaterial)MousOnCanvas).BackGroundColor += new Color(20, 20, 20);
            ((SquareMaterial)ClickedCanvas).BackGroundColor += new Color(50, 50, 50);
            ((SquareMaterial)BunedCanvas).BackGroundColor += new Color(50, 50, 50);
        }
        public void setColor(Color backgroundColor)
        {
            changeColor(backgroundColor, backgroundColor);
        }

        public void setGraph(int handle)
        {
            setGraph(new GraphicMaterial(handle));
        }

        public void setGraph(string graphName)
        {
            setGraph(new GraphicMaterial(graphName));
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


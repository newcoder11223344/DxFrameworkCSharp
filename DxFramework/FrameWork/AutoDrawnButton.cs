using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;
using DxLibDLL;

namespace DxFramework
{
    internal class AutoDrawnButton : AutoDrawnCanvas
    {
        public AutoDrawnButton(int layer)
            : base(layer)
        {
            init();
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

        public string Text { get; set; }

        public Color TextColor { get; set; }

        public Vector2 TextPosition { get; set; }

        public new MultiCanvas Canvas
        {
            get { return base.Canvas as MultiCanvas; }
            set { base.Canvas = value; }
        }

        public ICanvasBase DefaltCanvas // 通常時描画対象
        {
            get { return Canvas[0]; }
            set { Canvas[0] = value;}
        }

        public ICanvasBase MousOnCanvas // マウスオーバー時描画対象
        {
            get { return Canvas[1]; }
            set { Canvas[1] = value; }
        }

        public ICanvasBase ClikedCanvas // クリック時描画対象
        {
            get { return Canvas[2]; }
            set { Canvas[2] = value; }
        }

        public ICanvasBase BunedCanvas // 失効時描画対象
        {
            get { return Canvas[3]; }
            set { Canvas[3] = value; }

        } 

        public void init()
        {
            Canvas = new MultiCanvas(new Canvas(Top, Size),new Canvas(Top, Size),new Canvas(Top, Size), new Canvas(Top, Size));

            Text = "";
            TextColor = new Color(0, 0, 0);
            TextPosition = new Vector2(0, 0);
            BunedFlag = false;

            foreach (var itr in Canvas)
            {
                ((Canvas) itr).BackGroundColor = new Color(0, 0, 0);
                ((Canvas)itr).OutLineColor = new Color(200, 200, 200);
            }
           
            ((Canvas)MousOnCanvas).BackGroundColor += new Color(50, 50, 50);
         
            ((Canvas)ClikedCanvas).BackGroundColor += new Color(100, 100, 100);
          
            ((Canvas)BunedCanvas).BackGroundColor += new Color(50, 50, 50);
        }

        public override void draw()
        {
            if (BunedFlag)
            {
                Canvas.drawOnly(4);
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
            base.draw();
            DX.DrawStringF((float)(Top.x + TextPosition.x), (float)(Top.y + TextPosition.y), Text, TextColor.DxCoolor);
        }

        public bool BunedFlag { get; set; }
    }
}


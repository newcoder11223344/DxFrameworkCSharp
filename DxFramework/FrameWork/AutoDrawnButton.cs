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

        public DrawableCanvas MousOnCanvas { get; set; } // マウスオーバー時描画対象

        public DrawableCanvas ClikedCanvas { get; set; } // クリック時描画対象

        public DrawableCanvas BunedCanvas { get; set; } // 失効時描画対象


        public override Vector2 Top // 左上の座標
        {
            get { return _canvas.Top; }
            set
            {
                _canvas.Top = value;
                MousOnCanvas.Top = value;
                ClikedCanvas.Top = value;
                BunedCanvas.Top = value;
            }
        }

        public override Vector2 Size // 左上を基準にしたサイズ
        {
            get { return _canvas.Size; }
            set
            {
                _canvas.Size = value;
                MousOnCanvas.Size = value;
                ClikedCanvas.Size = value;
                BunedCanvas.Size = value;
            }
        }



        public void init()
        {
            Text = "";
            TextColor = new Color(0,0,0);
            TextPosition = new Vector2(0, 0);
            MousOnCanvas = new DrawableCanvas(Top,Size);
            MousOnCanvas.BackGroundColor += new Color(50, 50, 50);
            ClikedCanvas = new DrawableCanvas(Top, Size);
            ClikedCanvas.BackGroundColor += new Color(100, 100, 100);
            BunedCanvas = new DrawableCanvas(Top, Size);
            BunedCanvas.BackGroundColor += new Color(50, 50, 50);
        }

        public override void draw()
        {
            if (BunedFlag)
            {
                BunedCanvas.draw();
            }
            else if (isPressed())
            {
                ClikedCanvas.draw();
            }
            else if (isMouseOn())
            {
                MousOnCanvas.draw();
            }
            else
            {
                base.draw();
            }
            DX.DrawStringF((float) (Top.x + TextPosition.x), (float) (Top.y + TextPosition.y), Text, TextColor.DxCoolor);
        }

        public bool BunedFlag { get; set; }
    }
}

  
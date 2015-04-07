using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork
{
    class MultiCanvas : List<ICanvasBase>, ICanvasBase
    {
        public MultiCanvas(params ICanvasBase[] c)
        {
            IsVisible = true;
            foreach (var itr in c)
            {
                Add(itr);
            }
        }

        public Vector2 Top                            
        {                           
            get { return this[_activeCanvas].Top; }
            set
            {
                var del = value - this[_activeCanvas].Top;
                foreach (var itr in this)
                {
                    itr.Top += del;
                }
            }
        }　　　　　　　　　

        public Vector2 Size {
            get { return this[_activeCanvas].Size; }
            set
            {
                var delx = value.x / this[_activeCanvas].Size.x;
                var dely = value.y / this[_activeCanvas].Size.y;
                foreach (var itr in this)
                {
                    itr.Size = new Vector2(itr.Size.x*delx, itr.Size.y*dely);
                }
            }
        }　　　　　　　　

        public Vector2 Bottom { get { return Top + Size; } set { Top = value - Size; } }       // 右下の座標

        public Vector2 Mid { get { return Top + Size / 2; } set { Top = value - Size / 2; } }  // 中心の座標

        public bool IsVisible { get; set; }

        private int _activeCanvas = 0;

        public Action DrawAction
        {
            get
            {
                return () =>
                {
                    foreach (var itr in this)
                    {
                        if (itr.IsVisible)
                            itr.DrawAction();
                    }
                };
            }
        }

        public void drawOnly(int i)    // i番目のカンバスだけを描画します。
        {
            foreach (var itr in this)
            {
                itr.IsVisible = false;
            }
            if (Count >= i)
            {
                this[i - 1].IsVisible = true;
                _activeCanvas = i - 1;
            }
        }
    }
}

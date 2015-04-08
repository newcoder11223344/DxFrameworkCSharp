using System;
using System.Collections.Generic;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Materials
{
    class MultiSquareMaterial : List<ISquareMaterialBase>, ISquareMaterialBase
    {
        public MultiSquareMaterial(params ISquareMaterialBase[] c)
        {
            IsVisible = true;
            foreach (var itr in c)
            {
                Add(itr);
            }
        }

        public Vector2 Size
        {
            get { return this[_activeCanvas].Size; }
            set
            {
                var delx = value.x / this[_activeCanvas].Size.x;
                var dely = value.y / this[_activeCanvas].Size.y;
                foreach (var itr in this)
                {
                    itr.Size = new Vector2(itr.Size.x * delx, itr.Size.y * dely);
                }
            }
        }　　　　　　　　

        public bool IsVisible { get; set; }

        private int _activeCanvas = 0;

        public Action<Vector2> DrawAction
        {
            get
            {
                return (top) =>
                {
                    foreach (var itr in this)
                    {
                        if (itr.IsVisible)
                            itr.DrawAction(top);
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
                //_activeCanvas = i - 1;
            }
        }
    }
}

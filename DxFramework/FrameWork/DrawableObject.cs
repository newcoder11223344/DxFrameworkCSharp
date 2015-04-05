using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    interface IDrawableBase
    {
        void draw();
    }

    class DrawableObject : IDrawableBase
    {
        public DrawableObject()
        {

        }
        public void draw()
        {
            DrawAction();
        }

        public Action DrawAction { get; set; }
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
namespace DxFramework
{
    abstract class AutoDrawnBase
    {
        
        static Stack<Action<AutoDrawnBase>> autoAddFuncList = new Stack<Action<AutoDrawnBase>>();

        public static void SetAutoAddFunc(Action<AutoDrawnBase> addlistfunc)
        {
            autoAddFuncList.Push(addlistfunc);
        }

        public static void EndAutoAddFunc()
        {
            autoAddFuncList.Pop();
        }

        public AutoDrawnBase(int layer)
        {
            IsVisible = true;
            this.Layer = layer;
            if (autoAddFuncList != null)
                autoAddFuncList.Peek()(this);
        }

        public int Layer { get; set; }

        public bool IsVisible { get; set; }

        abstract public void draw();

        abstract public void update();
    }
}

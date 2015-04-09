using System.Collections.Generic;
using System.Linq;

namespace DxFramework.FrameWork.Bases
{
    abstract class PageBase
    {
        SortedDictionary<int, List<AutoDrawnBase>> DrawableList;

        protected PageBase()
        {
            DrawableList = new SortedDictionary<int, List<AutoDrawnBase>>();
            init();
        }

        public void init()
        {
            setAutoAddFunc(); //ここでリストをセット！
            subInit();
        }

        public abstract void subInit();

        public void update()
        {
            setAutoAddFunc(); //ここでリストをセット！
            foreach (KeyValuePair<int, List<AutoDrawnBase>> l in DrawableList.ToArray())
            {
                foreach (int i in Enumerable.Range(0, l.Value.Count()))
                {
                    l.Value[i].update();
                }
            }
            subUpdate();
        }

        public abstract void subUpdate();

        void setAutoAddFunc()
        {
            AutoDrawnBase.SetAutoAddFunc(addChild);
        }

        public virtual void draw()
        {
            foreach (KeyValuePair<int, List<AutoDrawnBase>> l in DrawableList.ToArray())
            {
                foreach (int i in Enumerable.Range(0, l.Value.Count()))
                {
                    if (l.Value[i].IsVisible) l.Value[i].draw();
                }
            }
        }

        public void addChild(AutoDrawnBase obj)
        {
            if (DrawableList.ContainsKey(obj.Layer) == false) { DrawableList.Add(obj.Layer, new List<AutoDrawnBase>()); }
            DrawableList[obj.Layer].Add(obj);
        }
    }
}

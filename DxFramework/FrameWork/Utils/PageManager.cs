using System;
using System.Collections.Generic;
using DxFramework.FrameWork.Bases;

namespace DxFramework.FrameWork.Utils
{
    static class PageManager
    {
        public static List<PageBase> PageList = new List<PageBase>()
        {
            new Page_1(),new Page_2()
        };

        private static PageBase _activPage = PageList[0];

        public static PageBase ActivePage {
            get { return _activPage; }
            set { _activPage = value; }
        }

        public static void changPage(Type pageName)
        {
            AutoDrawnBase.EndAutoAddFunc();
            foreach (var itr in PageList)
            {
                if (itr.GetType() == pageName)
                {
                    ActivePage = itr;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;

namespace DxFramework
{
    class Page_2 : PageBase
    {
        public override void
       subInit()
        {
            var GraphButton = new AutoDrawnButton(1,new Vector2(0,0), () =>
            {
                PageManager.changPage(typeof(Page_1));
            },"前のページ");
            GraphButton.DraggableFlag = true;
            GraphButton.setGraph("resource/img/angel.png");

        }
        public override void subUpdate()
        {

        }

    }
}

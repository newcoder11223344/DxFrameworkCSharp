using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Materials;
using DxFramework.FrameWork.Utils;

namespace DxFramework
{
    class Page_1 : PageBase
    {
        public override void subInit()
        {
            var back = new Square(1, new Vector2(0, 0), new GraphicMaterial("resource/img/back.png"));

            var title = new TextBlock(2, new Vector2(100, 50), new TextMaterial("DxFramework3.0", 52, "メイリオ", 2));

            var button1 = new Button(2, new Vector2(180, 200));
            button1.DraggableFlag = true;
            button1.setColor(new Color(200, 50, 50));
            button1.TextMaterial.Color = new Color(255, 255, 255);

            var button2 = new Button(2, new Vector2(300, 200), () =>
            {
                PageManager.changPage(typeof(Page_2));
            }, "次のページ");
        }
        public override void subUpdate()
        {

        }
    }
}

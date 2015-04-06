using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;

namespace DxFramework
{
	class MenuScene:Scene
	{
		public static MenuScene instance {get;private set; }
		public MenuScene() : base() { instance=this;}
		public override void subInit()
		{

            var Hana = new AutoDrawnButton(1);
            Hana.DraggableFlag = true;
            Hana.ClickedEvent += (sender, e) =>
            {
                Hana.MousOnCanvas = new Graphic(Hana.Top, "resource/img/angel.png");
            };


		    //Hana.Canvas("resource/img/angel.png");
		    //Hana.Top = new Vector2(300, 150);
		    //Hana.setTLight(200);
		    //Hana.DraggableFlag = true;
		    //Hana.setClickedAction(() => { });
		    //var devil = new AutoDrawnButton(1);
		    //devil.setGraph("resource/img/devil.png");
		    //var Back = new Graphic(new Vector2(0, 0), "resource/img/back.png", 0);
		    //Back.Top = new Vector2(0, 0);
		}
		public override void subUpdate()
		{
			

		}
	}
}

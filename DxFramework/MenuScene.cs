using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
	class MenuScene:Scene
	{
		public static MenuScene instance {get;private set; }
		public MenuScene() : base() { instance=this;}
		public override void init()
		{
		    base.init();
            var Hana =new Button(1);
			Hana.setGraph("resource/img/angel.png");
			Hana.top = new Vector2(300, 150);
			Hana.setTLight(200);
			Hana.draggableFlag = true;
			Hana.setClickedAction(() => { nextScene = GameScene.instance; });
			var devil = new Button(1);
			devil.setGraph("resource/img/devil.png");
			var Back = new Graphic(new Vector2(0, 0), "resource/img/back.png",0);
			Back.top =new  Vector2(0, 0);
		}
		public override Scene update()
		{
			base.update();
			//if(Hana.getClickedTimes!=0);//次シーンへ
			return nextScene;
		}
	}
}

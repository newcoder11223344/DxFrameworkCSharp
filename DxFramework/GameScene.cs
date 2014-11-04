using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
	class GameScene:Scene
	{
		public static GameScene instance{get;private set;}
		public GameScene():base(){
			init();
			instance = this;
		}
		public override void init(){
			base.init();
			var b=new Button(new Vector2(120, 300), 0, "resource/img/angel.png", () => {nextScene=MenuScene.instance;});
			b.setTLight(100);
			b.setClickedAction(() => { nextScene = MenuScene.instance; });
			var Hana = new Button(new Vector2(100, 100), 0, "resource/img/angel.png", () => { nextScene = MenuScene.instance; });
			Hana.setGraph("resource/img/angel.png");
		
		
		}
		public override Scene update()
		{
			base.update();
			return nextScene;
		}
		
	}
}

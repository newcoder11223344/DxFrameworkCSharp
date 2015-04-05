using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;

namespace DxFramework
{
	class GameScene:Scene
	{
		public static GameScene instance{get;private set;}
		public GameScene():base(){
			instance = this;
		}
		public override void subInit(){
            //var b = new AutoDrawnButton(new Vector2(120, 300), 0, "resource/img/angel.png", () => { });
            //b.setTLight(100);

            //var Hana = new AutoDrawnButton(new Vector2(100, 100), 0, "resource/img/angel.png", () => { });
            //Hana.setGraph("resource/img/angel.png");
		
		
		}
		public override void subUpdate()
		{
			
		}
		
	}
}

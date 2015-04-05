using System;
using DxFramework.FrameWork;
using DxLibDLL;

namespace DxFramework
{
	static class Test
	{
		[STAThread]
		static void Main()
		{
			//--------------------------initializing dxlib--------------------------
			DX.ChangeWindowMode(DX.TRUE);
			//DX.SetGraphMode(800, 600, 32);
			if (DX.DxLib_Init() == -1) return;
			DX.SetDrawScreen(DX.DX_SCREEN_BACK);
			//++++++++++++++++++++++++++initialized dxlib++++++++++++++++++++++++++++
			var menuscene = new MenuScene();
		    var gamescene = new GameScene();
			Scene scene=menuscene;
			while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
			{
				//-----------------------------mainloop---------------------------
				BasicInput.update();
                scene.update();
			    scene.draw();
			    //+++++++++++++++++++++++++++++++mainloop+++++++++++++++++++++++++
			}
			DX.DxLib_End();
		}
	}
}
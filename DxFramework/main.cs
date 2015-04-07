using System;
using DxFramework.FrameWork;
using DxFramework.FrameWork.Utils;
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
		    PageManager.ActivePage = new Page_1();
			//++++++++++++++++++++++++++initialized dxlib++++++++++++++++++++++++++++
			
			while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
			{
				//-----------------------------mainloop---------------------------
				BasicInput.update();
                PageManager.ActivePage.update();
                PageManager.ActivePage.draw();           
			    //+++++++++++++++++++++++++++++++mainloop+++++++++++++++++++++++++
			}
			DX.DxLib_End();
		}
	}
}
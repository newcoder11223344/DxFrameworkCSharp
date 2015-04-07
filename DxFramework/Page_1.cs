﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;

namespace DxFramework
{
	class Page_1:PageBase
	{
		public Page_1() : base() {}
		public override void subInit()
		{
		    var back = new AutoDrawnCanvas(1, new Graphic(new Vector2(0, 0), "resource/img/back.png"));


		    var title = new AutoDrawnCanvas(1,new Text("DxFramework3.0",52,"メイリオ",2));
            title.Top=new Vector2(100,50);

            var button1 = new AutoDrawnButton(1,new Vector2(180,200));
            button1.DraggableFlag = true;
            button1.setColor(new Color(200,50,50));
            button1.Text.Color=new Color(255,255,255);

            var button2 = new AutoDrawnButton(1,new Vector2(300,200), () =>
            {
                PageManager.changPage(typeof(Page_2));
            },"次のページ");
       

		}
		public override void subUpdate()
		{

		}
	}
}
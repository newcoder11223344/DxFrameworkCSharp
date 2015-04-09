using System;
using DxLibDLL;

namespace DxFramework.FrameWork.Utils
{
    public struct MouseButton
    {
        public int Button;
        public MouseButton(int button)
            : this()
        {
            Pressed = false;
            Up = false;
            Down = false;
            LastDown = new Vector2();
            this.Button = button;
        }
        public bool Pressed { get; set; }// ボタンが押されている
        public bool Up { get; set; }     // 離された
        public bool Down { get; set; }   // 押された
        public Vector2 LastDown { get; set; }
        public Vector2 LastUp { get; set; }
        public void SetInput(bool pressedthisframe, Vector2 pos)
        {
            Up = false; Down = false;
            if (pressedthisframe)
            {
                if (Pressed == false) Down = true;
            }
            else
            {
                if (Pressed == true) Up = true;
            }
            if (Up) LastUp = pos;
            if (Down) LastDown = pos;
            Pressed = pressedthisframe;
        }
        //public void setInputLog(bool input,Vector2 pos){
        //    ;
        //}//setinputlogの定義が謎　保留
        public string state()
        {
            var s = "";
            s += ("buttonid:" + Button + "\n");
            s += ("pressed:" + Pressed + "\n");
            s += ("up:" + Up + "\n");
            s += ("down:" + Down + "\n");
            s += ("lastdown:" + LastDown + "\n");
            s += ("lastup:" + LastUp + "\n");
            return s;
        }
    }
    public struct Mouse
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public int WheelRotVol { get; set; }
        public MouseButton Left;
        public MouseButton Right;
        public MouseButton Middle;
        public string state()
        {
            var s = "";
            s += ("pos:" + Position + "\n");
            s += ("speed:" + Speed + "\n");
            s += ("wheelrotvol:" + WheelRotVol + "\n");
            s += ("leftkeystates:" + Left.state() + "\n");
            s += ("rightkeystates:" + Right.state() + "\n");
            s += ("middlekeystates:" + Middle.state() + "\n");
            return s;
        }
    }
    public class BasicInput
    {
        public static Mouse Mouse;
        static byte[] Buf;
        static BasicInput()
        {
            Mouse.Left = new MouseButton(DX.MOUSE_INPUT_LEFT);
            Mouse.Right = new MouseButton(DX.MOUSE_INPUT_RIGHT);
            Mouse.Middle = new MouseButton(DX.MOUSE_INPUT_MIDDLE);
            Buf = new byte[256];
            update();
        }
        public static void update()
        {
            int x, y;
            DX.GetMousePoint(out x, out y);
            Mouse.Speed = new Vector2(x, y) - Mouse.Position;
            Mouse.Position = new Vector2(x, y);
            Mouse.WheelRotVol = DX.GetMouseWheelRotVol();
            int input = DX.GetMouseInput();
            Mouse.Left.SetInput((input & 1) != 0, Mouse.Position);
            Mouse.Right.SetInput((input & 2) != 0, Mouse.Position);
            Mouse.Middle.SetInput((input & 4) != 0, Mouse.Position);
            //DX.GetMouseInputLog(out input,out x,out y,1);
            DX.GetHitKeyStateAll(out Buf[0]);
            Console.WriteLine(state());
        }
        public static string state()
        {
            var s = "";
            int mouseinput = DX.GetMouseInput();
            s += ("getmouseinput: " + mouseinput + "\n");
            s += ("buttoninput & 1: " + (mouseinput & 1) + "\n");
            s += ("buttoninput & 2: " + (mouseinput & 2) + "\n");
            s += ("buttoninput & 4: " + (mouseinput & 4) + "\n");
            s += Mouse.state();
            return s;
        }
    }
}

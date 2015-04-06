namespace DxFramework.FrameWork
{
    interface IMouseObjectBase
    {
        bool DraggableFlag { get; set; }　　　　　 // ドラッグ機能

        event NomalEventHandler MouseOnEvent;　　　// マウスオーバー時に発生します。

        event NomalEventHandler ClickedEvent;  　　// クリック完了時に発生します。

        event NomalEventHandler ClickedOnEvent;　　// 上で押された時に発生します。

        event NomalEventHandler ClickedOffUpEvent; // 上で離された時に発生します。

        event NomalEventHandler PressingEvent; 　　// 押されている間に発生します。

        event NomalEventHandler DraggingEvent;     //ドラッグされている間に発生します。
    }
}

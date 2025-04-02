using UniFramework.Event;

/// <summary>
/// 场景相关事件定义类
/// 用于管理游戏中不同场景切换的事件
/// </summary>
public class SceneEventDefine
{
    /// <summary>
    /// 启动场景事件
    /// 当游戏启动初始场景时触发
    /// </summary>
    public class StartingScene : IEventMessage
    {
        /// <summary>
        /// 发送启动场景事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new StartingScene();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 主场景事件
    /// 当进入游戏主场景时触发
    /// </summary>
    public class MainScene : IEventMessage
    {
        /// <summary>
        /// 发送主场景事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new MainScene();
            UniEvent.SendMessage(msg);
        }
    }
}
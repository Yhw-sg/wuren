using UniFramework.Event;

/// <summary>
/// 用户交互相关事件定义类
/// 用于处理用户操作触发的各种系统事件
/// </summary>
public class UserEventDefine
{
    /// <summary>
    /// 用户尝试再次初始化资源包事件
    /// 当资源包初始化失败后，用户手动触发重试时发送
    /// </summary>
    public class UserTryInitialize : IEventMessage
    {
        /// <summary>
        /// 发送用户重试初始化事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new UserTryInitialize();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 用户开始下载网络文件事件
    /// 当用户确认开始下载更新文件时触发
    /// </summary>
    public class UserBeginDownloadWebFiles : IEventMessage
    {
        /// <summary>
        /// 发送用户开始下载事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new UserBeginDownloadWebFiles();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 用户尝试再次请求资源版本事件
    /// 当资源版本请求失败后，用户手动触发重试时发送
    /// </summary>
    public class UserTryRequestPackageVersion : IEventMessage
    {
        /// <summary>
        /// 发送用户重试请求版本事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new UserTryRequestPackageVersion();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 用户尝试再次更新补丁清单事件
    /// 当补丁清单更新失败后，用户手动触发重试时发送
    /// </summary>
    public class UserTryUpdatePackageManifest : IEventMessage
    {
        /// <summary>
        /// 发送用户重试更新清单事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new UserTryUpdatePackageManifest();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 用户尝试再次下载网络文件事件
    /// 当文件下载失败后，用户手动触发重试时发送
    /// </summary>
    public class UserTryDownloadWebFiles : IEventMessage
    {
        /// <summary>
        /// 发送用户重试下载文件事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new UserTryDownloadWebFiles();
            UniEvent.SendMessage(msg);
        }
    }
}
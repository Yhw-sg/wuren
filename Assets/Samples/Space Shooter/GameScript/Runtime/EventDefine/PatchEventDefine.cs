using UniFramework.Event;
using YooAsset;

/// <summary>
/// 补丁系统相关事件定义类
/// </summary>
public class PatchEventDefine
{
    /// <summary>
    /// 补丁包初始化失败事件
    /// 当补丁系统初始化过程中发生错误时触发
    /// </summary>
    public class InitializeFailed : IEventMessage
    {
        /// <summary>
        /// 发送初始化失败事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new InitializeFailed();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 补丁流程步骤改变事件
    /// 用于通知当前补丁更新的进度状态
    /// </summary>
    public class PatchStepsChange : IEventMessage
    {
        /// <summary>
        /// 当前步骤的提示信息
        /// </summary>
        public string Tips;

        /// <summary>
        /// 发送步骤改变事件消息
        /// </summary>
        /// <param name="tips">步骤提示信息</param>
        public static void SendEventMessage(string tips)
        {
            var msg = new PatchStepsChange();
            msg.Tips = tips;
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 发现更新文件事件
    /// 当检测到需要更新的文件时触发
    /// </summary>
    public class FoundUpdateFiles : IEventMessage
    {
        /// <summary>
        /// 需要更新的文件总数
        /// </summary>
        public int TotalCount;
        
        /// <summary>
        /// 需要更新的文件总大小（字节）
        /// </summary>
        public long TotalSizeBytes;

        /// <summary>
        /// 发送发现更新文件事件消息
        /// </summary>
        /// <param name="totalCount">文件总数</param>
        /// <param name="totalSizeBytes">总大小（字节）</param>
        public static void SendEventMessage(int totalCount, long totalSizeBytes)
        {
            var msg = new FoundUpdateFiles();
            msg.TotalCount = totalCount;
            msg.TotalSizeBytes = totalSizeBytes;
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 下载进度更新事件
    /// 用于通知文件下载的实时进度
    /// </summary>
    public class DownloadUpdate : IEventMessage
    {
        /// <summary>
        /// 需要下载的文件总数
        /// </summary>
        public int TotalDownloadCount;
        
        /// <summary>
        /// 当前已下载的文件数量
        /// </summary>
        public int CurrentDownloadCount;
        
        /// <summary>
        /// 需要下载的总字节数
        /// </summary>
        public long TotalDownloadSizeBytes;
        
        /// <summary>
        /// 当前已下载的字节数
        /// </summary>
        public long CurrentDownloadSizeBytes;

        /// <summary>
        /// 发送下载进度更新事件消息
        /// </summary>
        /// <param name="updateData">下载更新数据对象</param>
        public static void SendEventMessage(DownloadUpdateData updateData)
        {
            var msg = new DownloadUpdate();
            msg.TotalDownloadCount = updateData.TotalDownloadCount;
            msg.CurrentDownloadCount = updateData.CurrentDownloadCount;
            msg.TotalDownloadSizeBytes = updateData.TotalDownloadBytes;
            msg.CurrentDownloadSizeBytes = updateData.CurrentDownloadBytes;
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 资源版本请求失败事件
    /// 当无法获取远程资源版本信息时触发
    /// </summary>
    public class PackageVersionRequestFailed : IEventMessage
    {
        /// <summary>
        /// 发送版本请求失败事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new PackageVersionRequestFailed();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 资源清单更新失败事件
    /// 当更新资源清单文件失败时触发
    /// </summary>
    public class PackageManifestUpdateFailed : IEventMessage
    {
        /// <summary>
        /// 发送清单更新失败事件消息
        /// </summary>
        public static void SendEventMessage()
        {
            var msg = new PackageManifestUpdateFailed();
            UniEvent.SendMessage(msg);
        }
    }

    /// <summary>
    /// 网络文件下载失败事件
    /// 当文件下载过程中发生错误时触发
    /// </summary>
    public class WebFileDownloadFailed : IEventMessage
    {
        /// <summary>
        /// 下载失败的文件名
        /// </summary>
        public string FileName;
        
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error;

        /// <summary>
        /// 发送文件下载失败事件消息
        /// </summary>
        /// <param name="errorData">下载错误数据对象</param>
        public static void SendEventMessage(DownloadErrorData errorData)
        {
            var msg = new WebFileDownloadFailed();
            msg.FileName = errorData.FileName;
            msg.Error = errorData.ErrorInfo;
            UniEvent.SendMessage(msg);
        }
    }
}
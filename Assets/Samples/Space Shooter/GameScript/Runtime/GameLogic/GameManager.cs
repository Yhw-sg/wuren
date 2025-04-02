using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniFramework.Event;
using YooAsset;

/// <summary>
/// 游戏管理器类
/// 负责管理游戏全局状态和场景切换
/// </summary>
public class GameManager
{
    /// <summary>
    /// 单例实例
    /// </summary>
    private static GameManager _instance;

    /// <summary>
    /// 获取游戏管理器单例
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    /// <summary>
    /// 事件组，用于管理事件监听
    /// </summary>
    private readonly EventGroup _eventGroup = new EventGroup();

    /// <summary>
    /// 协程启动器
    /// 用于在非MonoBehaviour类中启动协程
    /// </summary>
    public MonoBehaviour Behaviour;

    /// <summary>
    /// 私有构造函数
    /// 初始化事件监听
    /// </summary>
    private GameManager()
    {
        // 注册场景切换相关事件监听
        _eventGroup.AddListener<SceneEventDefine.StartingScene>(OnHandleEventMessage);
        _eventGroup.AddListener<SceneEventDefine.MainScene>(OnHandleEventMessage);
    }

    /// <summary>
    /// 开启一个协程
    /// </summary>
    /// <param name="enumerator">协程迭代器</param>
    public void StartCoroutine(IEnumerator enumerator)
    {
        Behaviour.StartCoroutine(enumerator);
    }

    /// <summary>
    /// 处理场景切换事件
    /// 负责加载相应场景和UI界面
    /// </summary>
    /// <param name="message">事件消息</param>
    private void OnHandleEventMessage(IEventMessage message)
    {
        SceneHandle operationHandle = null;
        string uiName = null;

        // 根据不同的场景事件类型加载对应的场景和UI
        if (message is SceneEventDefine.StartingScene)
        {
            operationHandle = YooAssets.LoadSceneAsync("StartingScene");
            uiName = "StartPanel";
        }
        else if (message is SceneEventDefine.MainScene)
        {
            operationHandle = YooAssets.LoadSceneAsync("MainScene");
            uiName = "LoadingPanel";
        }

        // 如果没有找到对应的场景处理则返回
        if (operationHandle == null) return;

        // 注册场景加载完成的回调
        operationHandle.Completed += (op) =>
        {
            if (op.Status == EOperationStatus.Succeed)
            {
                //场景加载成功后打开对应的UI界面
                UIManager.Instance.OpenWindow(uiName);
            }
            else
            {
                Debug.LogError("Scene Failed to Load");
            }
        };
    }
}
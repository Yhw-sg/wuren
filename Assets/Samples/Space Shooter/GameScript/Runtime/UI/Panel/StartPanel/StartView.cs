using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YooAsset;

public class StartView : ViewBase
{
    Button _startBtn;
    public override void Init(UIWindow uiBase)
    {
        base.Init(uiBase);
       
        _startBtn = uiBase.transform.Find("StartBtn").GetComponent<Button>();
        _startBtn.onClick.AddListener(() =>
        {
            //Ìø×ªÖ÷³¡¾° MainScene
            SceneEventDefine.MainScene.SendEventMessage();
            UIManager.Instance.CloseWindow("StartPanel");
        });
    }
}

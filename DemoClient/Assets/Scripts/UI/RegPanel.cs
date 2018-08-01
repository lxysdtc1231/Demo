using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegPanel : PanelBase
{
    //面板按钮
    private InputField idInput;
    private InputField pwInput;
    private Button regBtn;
    private Button closeBtn;

    #region 生命周期
    //初始化
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "RegPanel";
        layer = PanelLayer.Panel;
    }

    public override void OnShowing()
    {

        base.OnShowing();
        Transform skinTrans = skin.transform;
        //获取面板组件
        idInput = skinTrans.Find("IDInput").GetComponent<InputField>();
        pwInput = skinTrans.Find("PWInput").GetComponent<InputField>();
        regBtn = skinTrans.Find("RegBtn").GetComponent<Button>();
        closeBtn = skinTrans.Find("CloseBtn").GetComponent<Button>();
        //添加回调监听
        regBtn.onClick.AddListener(OnRegClick);
        closeBtn.onClick.AddListener(OnCloseClick);
    }
    #endregion

    //注册点击
    public void OnRegClick()
    {
       
    }

    //注册回调
    public void OnRegBack()
    {
       
    }

    //回调方法
    public void OnCloseClick()
    {
        PanelMgr.instance.OpenPanel<LoginPanel>("");
        Close();
    }

}
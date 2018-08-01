using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanel : PanelBase
{
    //记录当前切换场景的名称
    public static string loadName="Main";
    public static string LoginInID;
    //UI
    private InputField idInput;
    private InputField pwInput;
    private Button loginBtn;
    private Button regBtn;

    #region 生命周期
    //初始化
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "LoginPanel";
        layer = PanelLayer.Panel;
    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        idInput = skinTrans.Find("Input_UserID").GetComponent<InputField>();
        pwInput = skinTrans.Find("Input_Passwaord").GetComponent<InputField>();
        loginBtn = skinTrans.Find("Btn_Login").GetComponent<Button>();
        regBtn = skinTrans.Find("Btn_Registered").GetComponent<Button>();

        loginBtn.onClick.AddListener(OnLoginClick);
        regBtn.onClick.AddListener(OnRegClick);
    }
    #endregion
    public void OnRegClick()
    {
        PanelMgr.instance.OpenPanel<RegPanel>("");
        Close();
    }

    public void OnLoginClick()
    {
        //用户名密码为空
        if (idInput.text == "" || pwInput.text == "")
        {
            Debug.Log("用户名密码不能为空!");
            return;
        }
    }
}
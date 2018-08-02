using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Net.Sockets;

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
        skinPath = "Skin/LoginPanel";
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
        if (Login(idInput.text, pwInput.text) == true)
        {
            //   PanelMgr.instance.OpenPanel<>("");
            Close();
        }
        else
        {
            Debug.Log("用户名或密码错误");
            idInput.text = "";
            pwInput.text = "";
        }
    }

    static bool Login(string name, string pw)
    {
        //服务器地址和端口
        var endport = new System.Net.IPEndPoint(System.Net.IPAddress.Loopback, 26000);
        var conn = new Socket(endport.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
        conn.Connect(endport);
        //编码字符串
        var nameb = System.Text.Encoding.Unicode.GetBytes(name);
        var pwb = System.Text.Encoding.Unicode.GetBytes(pw);
        //封装登陆请求
        byte[] buffer = new byte[5 + nameb.Length + pwb.Length];
        buffer[0] = 0x01; //协议ID
        buffer[1] = (byte)nameb.Length; //账号长度
        buffer[2] = (byte)(nameb.Length >> 8);
        buffer[3] = (byte)pwb.Length; //密码长度
        buffer[4] = (byte)(pwb.Length >> 8);
        //将账号密码数据填入发送缓冲区
        Buffer.BlockCopy(nameb, 0, buffer, 5, nameb.Length);
        Buffer.BlockCopy(pwb, 0, buffer, 5 + nameb.Length, pwb.Length);
        //发送登陆请求
        if (buffer.Length != conn.Send(buffer)) throw new Exception("网络连接异常");
        //接收响应
        if (2 != conn.Receive(buffer, 2, SocketFlags.None)) throw new Exception("网络连接异常");
        if (buffer[0] != 0x01) //应答协议ID
            throw new Exception("网络连接异常");
        //如果密码正确则成功建立连接
        if (0 != buffer[1])
        {
            return true;
           
        }
          
        //如果密码错误则关闭连接
        conn.Close();
        return false;
    }

}
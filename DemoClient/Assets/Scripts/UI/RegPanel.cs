using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net.Sockets;
using System;

public class RegPanel : PanelBase
{
    //面板按钮
    private InputField idInput;
    private InputField pwInput;
    private Button regBtn;
    private Button backBtn;

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
        regBtn = skinTrans.Find("Btn_Reg").GetComponent<Button>();
        backBtn = skinTrans.Find("Btn_Back").GetComponent<Button>();
        //添加回调监听
        regBtn.onClick.AddListener(OnRegClick);
        backBtn.onClick.AddListener(OnBackClick);
    }
    #endregion

    //注册点击
    public void OnRegClick()
    {
        if (Reg(idInput.text, pwInput.text) == true)
        {
            Debug.Log("注册成功");
            OnBackClick();
        }
        else
        {
            Debug.Log("用户名已被占用");
            idInput.text = "";
            pwInput.text = "";
        }
    }


    //返回登陆
    public void OnBackClick()
    {
        PanelMgr.instance.OpenPanel<LoginPanel>("");
        Close();
    }

    //注册
    static bool Reg(string name, string pw)
    {
        //服务器地址和端口
        var endport = new System.Net.IPEndPoint(System.Net.IPAddress.Loopback, 26000);
        var conn = new Socket(endport.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        conn.Connect(endport);
        //编码字符串
        var nameb = System.Text.Encoding.Unicode.GetBytes(name);
        var pwb = System.Text.Encoding.Unicode.GetBytes(pw);
        //封装注册请求
        byte[] buffer = new byte[5 + nameb.Length + pwb.Length];
        buffer[0] = 0x02; //协议ID
        buffer[1] = (byte)nameb.Length; //账号长度
        buffer[2] = (byte)(nameb.Length >> 8);
        buffer[3] = (byte)pwb.Length; //密码长度
        buffer[4] = (byte)(pwb.Length >> 8);
        //将账号密码数据填入发送缓冲区
        Buffer.BlockCopy(nameb, 0, buffer, 5, nameb.Length);
        Buffer.BlockCopy(pwb, 0, buffer, 5 + nameb.Length, pwb.Length);
        //发送注册请求
        if (buffer.Length != conn.Send(buffer)) throw new Exception("网络连接异常");
      
        //接收响应
        if (2 != conn.Receive(buffer, 2, SocketFlags.None)) throw new Exception("网络连接异常");
        if (buffer[0] != 0x02) //应答协议ID
            throw new Exception("网络连接异常");
        //注册成功
        if (0 != buffer[1])
        {
            conn.Close();
            return true;
            
        }

        //如果注册失败则关闭连接
        conn.Close();
        return false;
    }
}
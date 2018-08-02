using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MySocket : MonoBehaviour {

    #region 生命周期
    void Awake()
    {
        //切换场景不销毁
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        //打开登陆界面
        PanelMgr.instance.OpenPanel<LoginPanel>("");


    }

    // Update is called once per frame
    void Update () {
		
	}
    #endregion

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //UI显示
        PanelMgr.instance.OpenPanel<LoginPanel>("");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

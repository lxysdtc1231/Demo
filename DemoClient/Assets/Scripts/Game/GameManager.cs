using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    #region 周期
    void Start () {
		
	}	
	void Update () {
      
	}
    #endregion

    void StartGame(RoleInfo role)
    {
        //生成本地角色
        SpawnLocalPlayer(role);
     



    }

    //生成本地玩家
    public void SpawnLocalPlayer(RoleInfo role)
    {
        string name = "LocalPlayer";
        Vector3 pos = new Vector3(role.PosX, role.PosY, role.PosZ);
        Vector3 rot = new Vector3(role.RotX, role.RotY, role.RotZ);
        Common.LoadAndSpawn(name, pos, rot);
    }





}

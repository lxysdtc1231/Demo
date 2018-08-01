using UnityEngine;
using System.IO;
using LitJson;
using Assets.Scripts.Player;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

public class IOHelper : MonoBehaviour
{
    void Awake()
    {

     

    }
    void Start()
    {

        //   Save(myplayer);
        //   LoadPlayer();
    }

    /// <summary>
    /// 读取食物数据的方法
    /// </summary>
    //public static FoodInfo LoadItmeInfo()
    //{
    //    FoodInfo foodInfo = new FoodInfo();
    //    string jsonStr = GetJsonByWWW("/JsonFoods.json");
    //    List<FoodInfo> foodInfos = JsonMapper.ToObject<List<FoodInfo>>(jsonStr);
    //    //for (int i = 0; i < foodInfos.Count; i++)
    //    {
    //        Debug.Log("物品ID："+foodInfos[i].ItemID);
    //        Debug.Log(foodInfos[i].ItemName);
    //        Debug.Log("物品类型：" + foodInfos[i].ItmeType);
    //        Debug.Log("饥饿回复：" + foodInfos[i].StarStarvation);
    //        Debug.Log("口渴回复：" + foodInfos[i].Thirsty);
    //        Debug.Log("状态值：" + foodInfos[i].State);
    //        Debug.Log("物品描述：" + foodInfos[i].Describe);

    //    }
    //    return foodInfo;
    //}
    //用StreamReader读取Json
    public static string GetJson(string path)
    {
        string localPath = "";
        localPath = Application.persistentDataPath + path;
       
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);
        string jsonData = reader.ReadToEnd();
     
        return jsonData;

    }

    //用WWW从StreamAssets读取Json
    public static string GetJsonByWWW(string path)
    {
        //string localPath = "";
        //localPath = Application.streamingAssetsPath + path;
        //WWW t_WWW = new WWW(localPath);
        //return t_WWW.text;
        string localPath = "";
        localPath = Application.streamingAssetsPath + path;

        StreamReader reader = new StreamReader(localPath);
        string jsonData = reader.ReadToEnd();

        return jsonData;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour {
    /*---------------工具箱---------------*/

    //功能：生成物体
    //参数说明：
    //1、prefab：物体预设 
    //2、pos：生成位置
    //3、rot：生成方向
    public static GameObject SpawnObject(GameObject prefab,Vector3 pos,Quaternion rot)
    {
      GameObject get =  GameObject.Instantiate(prefab, pos, rot);
        return get;
    }

    //功能：遍历查找子物体
    //参数说明：
    //1、父物体
    //2、要查找的子物体名称
    public static GameObject FindHideChildGameObject(GameObject parent, string childName)
    {
        if (parent.name == childName)
        {
            return parent;
        }
        if (parent.transform.childCount < 1)
        {
            return null;
        }
        GameObject obj = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject go = parent.transform.GetChild(i).gameObject;
            obj = FindHideChildGameObject(go, childName);
            if (obj != null)
            {
                break;
            }
        }
        return obj;
    }

    //功能： 动态加载资源并生成
    //参数说明：
    //1、目标加载物体名称或路径
    //2、生成位置
    //3、生成方向
    public static void LoadAndSpawn(string name, Vector3 pos, Vector3 rot)
    {
     //四元转换
      Quaternion Rot=Quaternion.Euler(rot);
     //加载资源
      GameObject CurrentObjcet = Resources.Load(name) as GameObject;
      SpawnObject(CurrentObjcet,pos,Rot);                    
    }

    //功能： 旋转一定角度
    //参数说明：
    //1、目标物体
    //2、旋转轴 1-X轴；2-Y轴；3-Z轴；
    //3、旋转角度
    public static void RotateAngles(GameObject target,int axis,float angles)
    {
        if(axis==1)
        target.transform.eulerAngles =  new Vector3(angles, 0, 0);

        if(axis==2)
        target.transform.eulerAngles = new Vector3(0, angles, 0);

        if(axis==3)
        target.transform.eulerAngles = new Vector3(0, 0, angles);

    }

    //功能： 移动到指定位置
    //参数说明：
    //1、被移动物体
    //2、目标位置
    //3、最大单位速度
    public static void MoveToPosition(GameObject target, Vector3 position,float speed)
    {
        float step = speed * Time.deltaTime;
        target.transform.localPosition = Vector3.MoveTowards(target.transform.localPosition,position, step);

    }

    //功能： 自旋转
    //参数说明：
    //1、旋转物体
    //2、旋转速度
    //3、旋转方向 (Vector3.up|Vector3.back|Vector3.left|Vector3.right)
    public static void SelfRoate(GameObject Target,float Speed,Vector3 eulerAngles)
    {

        Target.transform.Rotate(eulerAngles * Speed);
        
    }




}

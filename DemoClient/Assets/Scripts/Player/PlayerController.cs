using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //主角面向变量 默认向前
    public int Player_Rot = 2;
    //移动速度
    public float MoveSpeed = 10;
    //8个方向
    public enum MoveDirection
    {
        N=1,
        S=2,
        W=3,
        E=4,
        NW=5,
        NE=6,
        SW=7,
        SE=8

    }
    float x;
    float z;
    void Update()
    {
        MoveNew();
       // Move();
       

    }
    //移动控制
    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Transform>().Rotate(0, 45, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Transform>().Rotate(0, -45, 0, 0);
        }
        //向下
        if (Input.GetKey(KeyCode.S) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 2);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            z = -MoveSpeed * Time.deltaTime;
            Player_Rot = 2;
        }
        if (Input.GetKeyUp(KeyCode.S) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 2)
        {

            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            z = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 2);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);

        }

        //向上
        if (Input.GetKey(KeyCode.W) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 1);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            z = MoveSpeed * Time.deltaTime;
            Player_Rot = 1;
        }
        if (Input.GetKeyUp(KeyCode.W) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 1)
        {

            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            z = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 1);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);

        }

        //向左
        if (Input.GetKey(KeyCode.A) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 3);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            x = -MoveSpeed * Time.deltaTime;
            Player_Rot = 3;
        }
        if (Input.GetKeyUp(KeyCode.A) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 3)
        {

            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            x = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 3);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);

        }

        //向右
        if (Input.GetKey(KeyCode.D) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 4);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            x = MoveSpeed * Time.deltaTime;
            Player_Rot = 4;
        }
        if (Input.GetKeyUp(KeyCode.D) && gameObject.GetComponent<Animator>().GetInteger("Walk") == 4)
        {

            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            x = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 4);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);

        }
        //WD
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
            x = MoveSpeed * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.D))
            {

            }
        }

        
    }
    //移动控制新版
    public void MoveNew()
    {
        //W
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetFloat("Blend", 0);

            gameObject.GetComponent<Animator>().SetFloat("WalkBlend", 1);
            transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }
        //S
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetFloat("Blend", 0);
            gameObject.GetComponent<Animator>().SetFloat("WalkBlend", 2);
            transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
        }
        //A
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetFloat("Blend", 0);
            gameObject.GetComponent<Animator>().SetFloat("WalkBlend", 3);
            transform.Translate(-MoveSpeed * Time.deltaTime, 0,0);
        }
        //D
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetFloat("Blend", 0);
            gameObject.GetComponent<Animator>().SetFloat("WalkBlend", 4);
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
      
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("Idle",false);
            gameObject.GetComponent<Animator>().SetFloat("Blend", 0);
            gameObject.GetComponent<Animator>().SetFloat("WalkBlend", 1);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.W))
        {

            gameObject.GetComponent<Animator>().SetFloat("Blend", 1);
            gameObject.GetComponent<Animator>().SetBool("Idle",true);
        }
    }
    //位置数据同
    public void SendPos(float X,float Y,float Z)
    {


    }
}

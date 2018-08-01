using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //主角面向变量 默认向右
    public int Player_Rot = 0;
    //移动速度
    public float MoveSpeed = 10;

    float x;
    float z;
    void Update()
    {
    
        Move();
        transform.Translate(x, 0, z);

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
    }

    //Android
    // 向上
    public void BtnUp_Down()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 1);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            z = MoveSpeed * Time.deltaTime;
            Player_Rot = 1;
        }

    }
    public void BtnUp_Up()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 1)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            z = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 1);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);
        }
    }


    //向下
    public void BtnDown_Down()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 2);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            z = -MoveSpeed * Time.deltaTime;
            Player_Rot = 2;
        }
    }

    public void BtnDown_Up()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 2)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            z = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 2);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);
        }
    }

    //向左
    public void BtnLeft_Down()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 3);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            x = -MoveSpeed * Time.deltaTime;
            Player_Rot = 3;
        }
    }
    public void BtnLeft_Up()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 3)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            x = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 3);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);
        }

    }

    //向右
    public void BtnRight_Down()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("Walk", 4);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            x = MoveSpeed * Time.deltaTime;
            Player_Rot = 4;
        }
    }

    public void BtnRight_Up()
    {
        if (gameObject.GetComponent<Animator>().GetInteger("Walk") == 4)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            x = 0;
            gameObject.GetComponent<Animator>().SetFloat("Blend", 4);
            gameObject.GetComponent<Animator>().SetInteger("Walk", 0);
        }
    }
}

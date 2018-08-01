using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFellow : MonoBehaviour {
    
    public Transform Player;
    public float distance_Y;
    public float distance_Z;
    void Start()
    {
       
           Player = GameObject.FindWithTag("LocalPlayer").GetComponent<Transform>();

    }

    void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x, Player.position.y+distance_Y, transform.position.z+distance_Z), Time.deltaTime * 3.0f);

        transform.position =Vector3.Lerp(transform.position,Player.GetComponent<Transform>().transform.position + new Vector3(0, distance_Y, distance_Z),Time.deltaTime*2);
        transform.rotation = Player.GetComponent<Transform>().transform.rotation;
    }
}

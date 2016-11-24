using UnityEngine;
using System.Collections;

public class moveTelecabine : MonoBehaviour {
    public Vector3 xyz;
    public float speed;

    void Start()
    {   
        Debug.Log(transform.position.z);
        xyz.z = 60;
    }
    
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, xyz, step);

    }
}

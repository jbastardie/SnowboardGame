using UnityEngine;
using System.Collections;

public class moveTelecabine : MonoBehaviour {
    public Vector3 xyz;
    public float speed;
    private bool insideCabine = false;
    public GameObject snowboarder;

    void Start()
    {   
        Debug.Log(transform.position.z);
        xyz.z = 60;
    }
    
    void Update()
    {
        Debug.Log("Dans la cabine: " + insideCabine);
        if (insideCabine)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, xyz, step); 
        }

    }

    void OnTriggerEnter(Collider other)
    {
        insideCabine = true;
        snowboarder.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        insideCabine = false;
        snowboarder.transform.parent = null;
    }
}

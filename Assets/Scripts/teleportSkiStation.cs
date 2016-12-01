using UnityEngine;
using System.Collections;

public class teleportSkiStation : MonoBehaviour {
    public GameObject snowboarder;
    //public Vector3 position;
    //public Quaternion rotation;
    // Use this for initialization
    public Vector3 positionArrivalTP;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        snowboarder.transform.position = positionArrivalTP;
        //snowboarder.transform.rotation = rotation;
    }
}

using UnityEngine;
using System.Collections;

public class teleportSkiStation : MonoBehaviour {
    public GameObject snowboarder;
    //public Vector3 position;
    //public Quaternion rotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        snowboarder.transform.position = new Vector3(39.34f,12.55f,103.49f);
        //snowboarder.transform.rotation = rotation;
    }
}

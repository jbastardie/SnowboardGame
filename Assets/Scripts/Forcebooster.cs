using UnityEngine;
using System.Collections;

public class Forcebooster : MonoBehaviour {
    public float thrust;
    public GameObject snowboarder;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("booster!");
        snowboarder.GetComponent<Rigidbody>().AddForce(snowboarder.transform.forward * thrust, ForceMode.Acceleration);
        //snowboarder.GetComponent<Rigidbody>().AddForce(snowboarder.transform.forward * thrust);
    }

}

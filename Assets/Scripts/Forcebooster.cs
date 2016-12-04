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
        snowboarder.GetComponent<skiController>().maxZXVelocity = 30;
        StartCoroutine(TimeoutBooster());
        //snowboarder.GetComponent<Rigidbody>().AddForce(snowboarder.transform.forward * thrust);
    }

    IEnumerator TimeoutBooster()
    {
        //disable the desired script here
        yield return new WaitForSeconds(2F);
        snowboarder.GetComponent<skiController>().maxZXVelocity = 25;
        //enable it here
    }

}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class danceScript : MonoBehaviour {
    public GameObject danceArea;
    public Animator snowboarder;
    private bool danceZone = false;
    private bool isDancing = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (danceZone && Input.GetKeyDown(KeyCode.F) && !switchWalkSnowboard.isSnowboarding)
        {
            if (!isDancing)
            {
                snowboarder.CrossFade("Dance", 0.1f);
                GetComponent<ThirdPersonUserControl>().enabled = false;
                isDancing = true;
            }
            else
            {
                snowboarder.CrossFade("Grounded", 0.1f);
                GetComponent<ThirdPersonUserControl>().enabled = true;
                isDancing = false;
            }
            
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == danceArea)
        {
            danceZone = true;
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == danceArea)
        {
            danceZone = false;
        }
    }
}

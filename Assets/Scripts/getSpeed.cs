using UnityEngine;
using System.Collections;

public class getSpeed : MonoBehaviour {

    public Rigidbody rigidbody;
    private float speed;
    public GameObject snowboarder;
    Animator animationObj;

    // Use this for initialization
    void Start () {
        animationObj = snowboarder.GetComponent<Animator>();
        //animationObj.Stop();
        //animationObj.Play("base");
    }
	
	// Update is called once per frame
	void Update () {

        var vel = rigidbody.velocity;      //to get a Vector3 representation of the velocity
        speed = vel.magnitude;             // to get magnitude
        if (speed > 5)
        {
            
            //animationObj.CrossFade("highSpeed", 0.5f);
        }

       if (Input.GetKeyDown(KeyCode.E))
        {
            //animationObj.enabled = true;
        }
    }
}

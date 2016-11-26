using UnityEngine;
using System.Collections;

public class getSpeed : MonoBehaviour {

    private Rigidbody rigidbody;
    public float speedForTransition;
    Animator animationObj;
    private GameObject parentGameObject;
    private bool isHighSpeed = false;

    // Use this for initialization
    void Start () {

        animationObj = GetComponent<Animator>();
        var animatorSnowboarder = parameterClass.currentCharacter.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        var vel = rigidbody.velocity;      //to get a Vector3 representation of the velocity
        var speed = vel.magnitude;             // to get magnitude
        if (speed > speedForTransition && !isHighSpeed)
        {
            Debug.Log("high speed");
            animationObj.CrossFade("highSpeedPosition", 0.1f);
            isHighSpeed = true;
        }
        else if (isHighSpeed && speed < speedForTransition)
        {
            Debug.Log("low speed");
            animationObj.CrossFade("snowboardState", 0.1f);
            isHighSpeed = false;
        }

    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}

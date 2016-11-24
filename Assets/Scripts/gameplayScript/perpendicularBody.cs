using UnityEngine;
using System.Collections;

public class perpendicularBody : MonoBehaviour {

    // Use this for initialization
    Animator animationObj;
    private GameObject parentGameObject;
    public float xOffset=0;
    public float yOffset=40;
    public float zOffset = 0;

    void Start () {
        parentGameObject = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        animationObj = parentGameObject.GetComponent<Animator>();
        var animatorSnowboarder = parameterClass.currentCharacter.GetComponent<Animator>();
        animatorSnowboarder.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("x et z angle: " + parentGameObject.transform.eulerAngles.x + " " + parentGameObject.transform.eulerAngles.z);
        var xAngle = parentGameObject.transform.eulerAngles.x;
        if (xAngle>0 && xAngle<180)
        {
            xAngle = -xAngle/1.5f;
        }
        transform.localRotation = Quaternion.Euler(-xAngle,0,-parentGameObject.transform.eulerAngles.z);
        //methode perpendiculaire dans tous les cas
        //transform.rotation = Quaternion.Euler(-3 + xOffset, parentGameObject.transform.eulerAngles.y+ yOffset, -9+zOffset);


        if ( 7 < Mathf.Abs(parentGameObject.transform.rotation.eulerAngles.x) && 353 > Mathf.Abs(parentGameObject.transform.rotation.eulerAngles.x))
        {       
            animationObj.enabled = false;


        }
        else if(parentGameObject.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            animationObj.enabled = true;
        }

    }

    void FixedUpdate()
    {
        parentGameObject.transform.rotation = Quaternion.Euler(parentGameObject.transform.rotation.eulerAngles.x, parentGameObject.transform.rotation.eulerAngles.y, 0);
    }

}

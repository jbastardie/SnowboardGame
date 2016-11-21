using UnityEngine;
using System.Collections;

public class perpendicularBody : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rigidbody;
    public GameObject snowboarder;
    Animator animationObj;
    
    void Start () {
        animationObj = snowboarder.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //cancel z rotation
        //rigidbody.transform.rotation = Quaternion.Euler(rigidbody.transform.rotation.eulerAngles.x, rigidbody.transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(3, rigidbody.transform.eulerAngles.y+40, 0);
        //transform.rotation(rigidbody.rotation.x, 0, rigidbody.rotation.z);
        //transform.eulerAngles.Set(0,transform.eulerAngles.y,0);

        //Debug.Log(transform.eulerAngles.z);
        Debug.Log(rigidbody.transform.rotation.eulerAngles.x);
        if ( 7 < Mathf.Abs(rigidbody.transform.rotation.eulerAngles.x) && 353 > Mathf.Abs(rigidbody.transform.rotation.eulerAngles.x))
        {       
            animationObj.enabled = false;
        }
        else 
        {
            animationObj.enabled = true;
        }

    }

    void FixedUpdate()
    {
        rigidbody.transform.rotation = Quaternion.Euler(rigidbody.transform.rotation.eulerAngles.x, rigidbody.transform.rotation.eulerAngles.y, 0);
    }
}

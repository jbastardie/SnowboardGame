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
        transform.rotation = Quaternion.Euler(-3 + xOffset, parentGameObject.transform.eulerAngles.y+ yOffset, -9+zOffset);

        //Debug.Log(transform.eulerAngles.z);
        //Debug.Log(parentGameObject.transform.rotation.eulerAngles.x);
        if ( 7 < Mathf.Abs(parentGameObject.transform.rotation.eulerAngles.x) && 353 > Mathf.Abs(parentGameObject.transform.rotation.eulerAngles.x))
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
        parentGameObject.transform.rotation = Quaternion.Euler(parentGameObject.transform.rotation.eulerAngles.x, parentGameObject.transform.rotation.eulerAngles.y, 0);
    }
}

using UnityEngine;
using System.Collections;

public class switchWalkSnowboard : MonoBehaviour {
    public GameObject snowboarderController;
    public GameObject snowboardObject;

    Animator animationObj;
    private bool isSnowboarding = false;
    // Use this for initialization
    void Start () {
        animationObj = snowboarderController.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isSnowboarding)
            {
                animationObj.CrossFade("Grounded", 0.3f);
                snowboardObject.SetActive(false);
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0, 0, 0);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                isSnowboarding = false;
            }
            else
            {
                animationObj.CrossFade("snowboardState",0.1f);
                snowboardObject.SetActive(true);
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0.2089f, 0.04038f, 0.015553f);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(3.644f, 37.479f, 1.097f);
                isSnowboarding = true;
            }
        }
    }
}

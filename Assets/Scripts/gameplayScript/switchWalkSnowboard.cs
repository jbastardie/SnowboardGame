using UnityEngine;
using System.Collections;

public class switchWalkSnowboard : MonoBehaviour {
    public GameObject snowboarderController;
    public GameObject snowboardObject;
    public RuntimeAnimatorController walkingController;
    public RuntimeAnimatorController snowboardingController;
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
                animationObj.runtimeAnimatorController = walkingController;
                snowboardObject.SetActive(false);
                isSnowboarding = false;
            }
            else
            {
                animationObj.runtimeAnimatorController = snowboardingController;
                snowboardObject.SetActive(true);
                isSnowboarding = true;
            }
        }
    }
}

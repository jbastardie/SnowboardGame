using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class switchWalkSnowboard : MonoBehaviour {
    public GameObject snowboarderController;
    public GameObject snowboardObject;
    public Collider snowCollinder;
    public Collider marcheCollider;
 
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
                snowCollinder.enabled = false;
                marcheCollider.enabled = true;
                GetComponent<ThirdPersonCharacter>().enabled = true;
                GetComponent<ThirdPersonUserControl>().enabled = true;
                GetComponent<skiController>().enabled = false;
                GetComponent<perpendicularBody>().enabled = false;
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0, 0, 0);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);                  
                isSnowboarding = false;
            }
            else
            {
                animationObj.CrossFade("snowboardState",0.1f);
                snowboardObject.SetActive(true);
                snowCollinder.enabled = true;
                marcheCollider.enabled = false;
                GetComponent<ThirdPersonCharacter>().enabled = false;
                GetComponent<ThirdPersonUserControl>().enabled = false;
                GetComponent<skiController>().enabled = true;
                GetComponent<perpendicularBody>().enabled = true;
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0.093f, -0.079f, 0.073f);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(0, 392.787f, 0);
                isSnowboarding = true;
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

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
                transform.rotation = Quaternion.Euler(0, 0, 0);
                parameterClass.currentCharacter.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<perpendicularBody>().enabled = false;
                animationObj.enabled = true;
                StartCoroutine(TimeoutSnowMarche());
                animationObj.CrossFade("Grounded", 0.3f);
                snowboardObject.SetActive(false);
                snowCollinder.enabled = false;
                marcheCollider.enabled = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                GetComponent<ThirdPersonCharacter>().enabled = true;
                GetComponent<ThirdPersonUserControl>().enabled = true;
                GetComponent<skiController>().enabled = false;
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0, 0, 0);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);                  
                isSnowboarding = false;
            }
            else
            {
                animationObj.enabled = true;
                animationObj.CrossFade("snowboardState",0.1f);
                snowboardObject.SetActive(true);
                snowCollinder.enabled = true;
                marcheCollider.enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                GetComponent<ThirdPersonCharacter>().enabled = false;
                GetComponent<ThirdPersonUserControl>().enabled = false;
                GetComponent<skiController>().enabled = true;
                StartCoroutine(TimeoutMarcheSnow());
                parameterClass.currentCharacter.transform.localPosition = new Vector3(0.093f, -0.079f, 0.073f);
                parameterClass.currentCharacter.transform.localRotation = Quaternion.Euler(0, 392.787f, 0);
                isSnowboarding = true;
            }
        }
    }

    IEnumerator TimeoutMarcheSnow()
    {
        //disable the desired script here
        yield return new WaitForSeconds(2F);
        parameterClass.currentCharacter.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<perpendicularBody>().enabled = true;
        //enable it here
    }
    IEnumerator TimeoutSnowMarche()
    {
        //disable the desired script here
        yield return new WaitForSeconds(2F);
        //enable it here
    }
}

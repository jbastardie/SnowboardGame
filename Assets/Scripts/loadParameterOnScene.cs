using UnityEngine;
using System.Collections;

public class loadParameterOnScene : MonoBehaviour {

    public GameObject snowboard;
    public GameObject ThirdPersonView;
	// Use this for initialization
	void Start () {
        if (parameterClass.snowboardMaterial != null)
        {
            Renderer rend = snowboard.GetComponent<Renderer>();
            rend.material = parameterClass.snowboardMaterial;
        }
        //Debug.Log("element du parameter class"+parameterClass.currentCharacter);
        if (parameterClass.currentCharacter != null)
        {

            parameterClass.currentCharacter.transform.position = ThirdPersonView.transform.position;
            parameterClass.currentCharacter.transform.rotation = ThirdPersonView.transform.rotation;
            parameterClass.currentCharacter.transform.parent = ThirdPersonView.transform;
            var animator = ThirdPersonView.GetComponent<Animator>();
            var loadedAnimator = parameterClass.currentCharacter.GetComponent<Animator>();
            animator.avatar = loadedAnimator.avatar;
            loadedAnimator.runtimeAnimatorController = null;
            UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter.m_MoveSpeedMultiplier = parameterClass.currentCharacter.transform.lossyScale.y;

            //Debug.Log("element chargé " + gameObjects.transform.Find("parameterClass.currentCharacter").gameObject.name);

            //parameterClass.currentCharacter;
            //character = GlobalControl.Instance.GetComponent<GameObject>();
            //Debug.Log("element chargé "+ character.name);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

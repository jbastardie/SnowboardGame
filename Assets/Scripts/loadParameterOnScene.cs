using UnityEngine;
using System.Collections;

public class loadParameterOnScene : MonoBehaviour {

    public GameObject snowboard;
    public GameObject character;
	// Use this for initialization
	void Start () {
        if (parameterClass.snowboardMaterial != null)
        {
            Renderer rend = snowboard.GetComponent<Renderer>();
            rend.material = parameterClass.snowboardMaterial;
        }
        Debug.Log(parameterClass.currentCharacter);
        if (parameterClass.currentCharacter != null)
        {
            character = (GameObject)Resources.Load("Assets/Characters/" + parameterClass.currentCharacter+".fbx", typeof(GameObject));
            //character = Instantiate(Resources.Load(parameterClass.currentCharacter+".prefab", typeof(GameObject))) as GameObject;
            Debug.Log("element chargé "+ character.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

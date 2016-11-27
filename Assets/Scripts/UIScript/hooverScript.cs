using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hooverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeColor()
    {
        GetComponent<Text>().color = Color.red;
    }

    public void revertColor()
    {
        GetComponent<Text>().color = Color.white;
    }
}

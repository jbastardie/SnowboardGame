using UnityEngine;
using System.Collections;

public class changeCharacters : MonoBehaviour {
    public GameObject[] characters = new GameObject[3];
    int maxCharacters;
    int arrayPos = 0;
    // Use this for initialization
    void Start () {
        maxCharacters = characters.Length - 1;
        parameterClass.currentCharacter = characters[arrayPos];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        characters[arrayPos].SetActive(false);
        if (arrayPos == maxCharacters)
        {
            arrayPos = 0;
        }
        else
        {
            arrayPos++;
        }
        characters[arrayPos].SetActive(true);
        parameterClass.currentCharacter = characters[arrayPos];
        Debug.Log(parameterClass.currentCharacter.name);
    }
  }

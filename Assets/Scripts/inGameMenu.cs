using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class inGameMenu : MonoBehaviour {
    public GameObject menuCanvas;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                menuCanvas.SetActive(false);
                GetComponent<MouseAimCamera>().enabled = true;
                GetComponent<BlurOptimized>().enabled = false;
                Time.timeScale = 1;
                
            }
            else
            {
                Cursor.visible = true;
                menuCanvas.SetActive(true);
                GetComponent<MouseAimCamera>().enabled = false;
                GetComponent<BlurOptimized>().enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}

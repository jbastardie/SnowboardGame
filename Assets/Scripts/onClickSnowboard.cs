using UnityEngine;
using System.Collections;

public class onClickSnowboard : MonoBehaviour {
    public Material[] myMaterials = new Material[5];
    int maxMaterials;
    int arrayPos = 1;
    // Use this for initialization
    void Start () {
        maxMaterials = myMaterials.Length - 1;
        parameterClass.snowboardMaterial = myMaterials[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "snowboard")
                {
                    Renderer rend = GameObject.Find(hit.collider.name).GetComponent<Renderer>();
                    rend.material = myMaterials[arrayPos];
                    parameterClass.snowboardMaterial = myMaterials[arrayPos];
                    if (arrayPos == maxMaterials)
                    {
                        arrayPos = 0;
                    }
                    else
                    {
                        arrayPos++;
                    }
                }
                //Debug.Log("Mouse Down hit: " + hit.collider.name);
                
            }
        }
    }
}

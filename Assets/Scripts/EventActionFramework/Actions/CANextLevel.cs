using UnityEngine;
using System.Collections;

public class CANextLevel : CustomActionScript {

	public override IEnumerator DoActionOnEvent (MonoBehaviour sender, GameObject args)
	{
		Application.LoadLevel(Application.loadedLevel + 1);
		yield return null;
	}
}

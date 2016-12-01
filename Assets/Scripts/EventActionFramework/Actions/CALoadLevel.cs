using UnityEngine;
using System.Collections;

public class CALoadLevel : CustomActionScript {

	public string _levelName;

	public override IEnumerator DoActionOnEvent (MonoBehaviour sender, GameObject args)
	{
		Application.LoadLevel(_levelName);
		yield return null;
	}
}

using UnityEngine;
using System.Collections;

public class CAPrintCustomMessageOnGUIForSeconds : CustomActionScript {

	public float _seconds;

	public string _message;

	public int _width;

	public int _height;

	private bool _printingMessage = false;

	public void OnGUI()
	{
		if (_printingMessage)
		{
			GUI.TextArea(new Rect(Screen.width / 2f - _width / 2f, Screen.height / 2f - _height / 2f, _width, _height), _message);
		}
	}

	public override IEnumerator DoActionOnEvent (MonoBehaviour sender, GameObject args)
	{
		_printingMessage = true;
		yield return new WaitForSeconds(_seconds);
		_printingMessage = false;
	}

}

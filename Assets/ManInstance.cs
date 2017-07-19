using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManInstance : MonoBehaviour 
{
	public static ManInstance instance = null;

	void Awake()
	{
		instance = this;
		StartCoroutine ("WaitToSendEvents");
	}

	IEnumerator WaitToSendEvents()
	{
		yield return new WaitForSecondsRealtime (5);
		//onInstanceChangedEventSender ();
		//onFloatAndStringChangedSender ();

		StartCoroutine ("WaitToSendEvents");
	}

	public event System.Action OnInstanceChanged;
	private void onInstanceChangedEventSender()
	{
		if (OnInstanceChanged != null) 
		{
			OnInstanceChanged ();
		}
	}

	public event System.Action<float, string> OnFloatAndStringChanged;
	private void onFloatAndStringChangedSender()
	{
		if (OnFloatAndStringChanged != null) 
		{
			OnFloatAndStringChanged (2f, "event on float and string changed");
		}
	}

}

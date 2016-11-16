using UnityEngine;
using System.Collections;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component {

	private static T instance;
	public static T Instance{
		get{
			if (instance == null)
				instance = GameObject.FindObjectOfType<T> ();
			return instance;
		}
	}

}

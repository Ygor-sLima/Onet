using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GhostController : MonoBehaviour {

	public static Vector2[] inputs;

	private int count = 0;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		count++;
		
		if(SceneManager.GetActiveScene().name.Equals("Cena5")) {
			transform.position = transform.position;
		} else {
			if(count >= inputs.Length) {
				transform.position = transform.position;
			} else {
				transform.position = inputs[count];
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D a) {
		if(a.gameObject.CompareTag("portal")) {
			GameObject.Find("Ctrl").GetComponent<EnableControllers>().Disable();
		}
	}
}

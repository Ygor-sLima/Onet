using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTyper : MonoBehaviour {

	public float letterPause;
	public Animator animator;
	public string animacao;
	string message;
	Text text;
	void Start () {
		text = GetComponent<Text>();
		message = text.text;
		text.text = "";
		StartCoroutine(TypeText());
	}
	
	IEnumerator TypeText() {
		foreach(char letter in message.ToCharArray()) {
			text.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
		animator.Play(animacao);
	}

	
}

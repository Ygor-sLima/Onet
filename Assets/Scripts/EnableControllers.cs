using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnableControllers : MonoBehaviour {

	public GameObject enableP;
	public GameObject enableG;
	public GameObject enablePl;
	public Animator start;

	public string nextScene;

	public Text text;

	private bool gameRunning = true;
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) && gameRunning) {
			enableP.GetComponent<PlayerController>().enabled = true;
			enablePl.GetComponent<PlataformaGirando>().enabled = true;
			start.Play("SobeDesce");
			if(enableG != null) {
				enableG.GetComponent<GhostController>().enabled = true;
			}
			text.enabled = false;
		}	
		if(!gameRunning) {
			if(SceneManager.GetActiveScene().name.Equals("Cena4")) {
				if(enableP.GetComponent<PlayerController>().andou == false) {
					SceneManager.LoadScene("Trans4-5");
					
				} else {
					text.text = "Try staying quiet. 'Return' to restart";
					text.enabled = true;
					if(Input.GetKeyDown(KeyCode.Return)) {
						SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					}
				}
			} else if(SceneManager.GetActiveScene().name.Equals("Cena5")) {
				text.text = "Try to 'forget' by hitting 'Space'. 'Return' to restart";
				text.enabled = true;
				if(Input.GetKeyDown(KeyCode.Return)) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			} else {
				text.text = "You lost to yourself! 'Return' to restart";
				text.enabled = true;
				if(Input.GetKeyDown(KeyCode.Return)) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
	}
	

	public void Disable() {
		enableP.GetComponent<PlayerController>().enabled = false;
		enablePl.GetComponent<PlataformaGirando>().enabled = false;
		start.Play("idle");
		enableG.GetComponent<GhostController>().enabled = false;
		enableP.GetComponent<PlayerController>().GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		gameRunning = false;
	}
}

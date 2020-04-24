using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	//	 J – K – L - j - k - l
	// Use this for initialization
	
	private List<Vector2> playerInputs = new List<Vector2>();
	private Rigidbody2D rb;
	public bool andou = false;

	// Movimento
	private Vector2 moveInput;
	public float speed;
	public Animator a;
	public BoxCollider2D atBox;
	public bool enemDead = false;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			a.Play("atq");
			atBox.enabled = true;
			Collider2D[] colliders = new Collider2D[3];
			atBox.OverlapCollider(new ContactFilter2D(), colliders);
			
			for (int i = 0; i < colliders.Length; i++) {
				if(colliders[i] != null && colliders[i].gameObject.CompareTag("enemy")) {
					Destroy(colliders[i].gameObject);
					enemDead = true;
				}
			}
			atBox.enabled = true;
		}
	}

	void FixedUpdate() {
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)) {
			andou = true;
		}

		playerInputs.Add(new Vector2(transform.position.x, transform.position.y));
		
		rb.velocity = moveInput * speed;
	}

	void OnTriggerEnter2D(Collider2D a) {
		if(a.gameObject.CompareTag("portal")) {
			if(andou && SceneManager.GetActiveScene().name.Equals("Cena4")) {
				GameObject.Find("Ctrl").GetComponent<EnableControllers>().Disable();
			} else if (SceneManager.GetActiveScene().name.Equals("Cena5")) {
				if(!enemDead) {
					GameObject.Find("Ctrl").GetComponent<EnableControllers>().Disable();
				} else {
					SceneManager.LoadScene(GameObject.Find("Ctrl").GetComponent<EnableControllers>().nextScene);
				}
			} else {
				playerInputs.Add(new Vector2(transform.position.x,transform.position.y));
				GhostController.inputs = playerInputs.ToArray();
				SceneManager.LoadScene(GameObject.Find("Ctrl").GetComponent<EnableControllers>().nextScene);
			}
		}
	}
}

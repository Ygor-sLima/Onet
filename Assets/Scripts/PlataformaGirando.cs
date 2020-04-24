using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGirando : MonoBehaviour {

	private float rot =0;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0,0, rot);
		rot += 5;
	}
}

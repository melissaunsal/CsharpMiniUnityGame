using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmas_kontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45)*Time.deltaTime); // x için 15 döndürme 

		
	}

}

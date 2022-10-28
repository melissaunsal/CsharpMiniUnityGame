using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour {
	Vector3 konumfarki;
	public GameObject oyuncu;// oyuncunun konumu transform ile bulabiliriz


	// Use this for initialization
	void Start () {
		
		//fark hesabi

		konumfarki = transform.position - oyuncu.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		//yeni konum güncellenmesi kameranın konumunu değiştiriyoruz 
		transform.position=oyuncu.transform.position+konumfarki;
	}
}

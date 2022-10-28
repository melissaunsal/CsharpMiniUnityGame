using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class oyuncu_kontrol : MonoBehaviour {
	Rigidbody rb;
	public float hiz=10;
	public Renderer rend;
	int Skor;
	public Text skorText;
	public Text hataText;
	public Text tebrikText;
	public Material m1;
	public Material m2;
	bool degisti =true;

	// Use this for initialization

	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	private void FixedUpdate () { 
		//yön- kullanıcı tarafında
		float yatay ;
		float dikey;
		yatay=Input.GetAxis("Horizontal");
		dikey= Input.GetAxis("Vertical");
	
		//kuvveti oluşturma
		Vector3 kuvvet = new Vector3(yatay, 0f, dikey); // z değeri 0f yukarı hareket yok
		//kuvveti uygulama-Addforce
		rb.AddForce(kuvvet*hiz);
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 zipla = new Vector3 (0f, 300f, 0f);
			rb.AddForce (zipla);
		}


		
	}
	//metaryel değiştirme fonksiyonu 
	private void OnMouseDown()

	{
		if (degisti) {
			rend.material = m1;
			degisti = !degisti;
		}
		else {
			rend.material = m2;
			degisti = !degisti;
		}
	}
	//etkileşim:collision , ontriggerEnter
	private void OnTriggerEnter(Collider other){
		if (other.CompareTag ("elmaslar")) {
			//Destroy (other);//yok eder
			other.gameObject.SetActive (false);//nesneyi gizler 
			Skor += 10;//puan arttırma
			skorText.text = "SKOR:" + Skor.ToString ();
			Debug.Log (Skor);
		}
			else if (other.CompareTag ("sonelmas") && Skor == 70)
			{
				Skor += 10;
				other.gameObject.SetActive (false);
			tebrikText.text="tebrikler";
			StartCoroutine (tebrikMesaj ());

			} else {
				//hata mesajı
				hataText.text = "Bu elmas en son toplanacaktır";
				StartCoroutine (hataMesaj ());
			}


		}
	
	IEnumerator tebrikMesaj()
	{
		yield return  new WaitForSeconds(3f);
		SceneManager.LoadScene ("sonSahne");
	}


		IEnumerator hataMesaj()
		{
			yield return  new WaitForSeconds(3.1f);
			hataText.text="";
		}

}


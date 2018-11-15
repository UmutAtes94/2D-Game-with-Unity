using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminTrigger : MonoBehaviour {


    Karakter kr; //karakter kodunun alt objesinin olusturuyoruz
	void Start () {
        kr = transform.root.gameObject.GetComponent<Karakter>(); //en üstteki objenin koduna erişiyor
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)//objenin yere değip değmediğini anlamak için
    {
        kr.yerdemi = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        kr.yerdemi = true; //girmişsse ve hala yerde duruyorsa true
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        kr.yerdemi = false; //eğer yere değmiyorsa false (yerden cıkıs yapmıssa obje)
    }
   
}

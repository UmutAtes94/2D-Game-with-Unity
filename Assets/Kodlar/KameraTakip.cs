using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//kameramız karakteri takip edecek bu yüzden karakterin x ve y kodrdinatları lazım
public class KameraTakip : MonoBehaviour {

    public float x,y;
    public Transform target;
    void Start () {
        target =GameObject.Find("Adam").transform; // target'ı Adam objesine eşitleedik Adam objesinin transformunu alacak
   
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x+x,target.position.y+y,-10); //kameranın karakter takibi için
	}
}

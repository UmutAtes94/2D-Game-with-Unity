using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //buton işlemlerini tanıması için
using UnityEngine;

public class Levelbuton: MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(gameObject.name == "1") //obje ismi 1 ise
        {
            GetComponent<Button>().interactable = true; //butonu tanıtmak için (obje 1. butonsa true yapacak)

        }
        else
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }

        }
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void leveller(int levelid)
    {
        SceneManager.LoadScene(levelid);
       
    }

    public void BaslaClick()
    {
        Application.LoadLevel("sahne1");
    }

    public void CıkısClick()
    {
        Debug.Log("cıktın");
        Application.Quit();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    public float hiz, ziplamagucu, maxHiz;
    public bool yerdemi;
    Rigidbody2D agirlik;
    Animator anim;
    public int can, maxcan,elmas;
    public GameObject[] canlar;
    public GameObject[] uyari;
    public Text elmasmiktar;
    public AudioClip[] sesler;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>(); //anim değişkenini objenin içindeki animatore eşitledik
        agirlik = GetComponent<Rigidbody2D>(); //agırlıgı karakterin agırlıgına eşitledik
        can = maxcan; //canı max cana eşitledik
        uyari[0].SetActive(true);
        Invoke("MesajKaldir",1.5f);

        CanSistemi();
    }

    // Update is called once per frame
    void Update()
    {


        elmasmiktar.text = "" + elmas;        
        if (Input.GetKeyDown(KeyCode.Space) && yerdemi)// boşluga bastıgımızda işleyecek kod
        {
            agirlik.AddForce(Vector2.up * ziplamagucu);//yukarı dogru 
        }

        if (can <= 0)
        {
            olme();
        }

    }

    private void İf(bool v)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        agirlik.AddForce(Vector2.right * h * hiz); //karakterin ağırlıgına sağ tarafa dogru güç uygula
        anim.SetFloat("Hiz", Mathf.Abs(h)); //a ya basınca hız - olmaması için
        anim.SetBool("Yerde", yerdemi);

        if (h > 0.1f)
        {
            transform.localScale = new Vector2(1, 1); //sağa dogru ilerleme
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (agirlik.velocity.x > maxHiz)//kosarken kaymayı önlemek için
        {
            agirlik.velocity = new Vector2(maxHiz, agirlik.velocity.y); //eğer hız belli bir değeri geçmişsse sabitliyor hızı o değere
        }

        if (agirlik.velocity.x < -maxHiz)//kosarken kaymayı önlemek için
        {
            agirlik.velocity = new Vector2(-maxHiz, agirlik.velocity.y); //eğer hız belli bir değeri geçmişsse sabitliyor hızı o değere (TERS YÖN İÇİN)
        }
    }


    private void OnTriggerEnter2D(Collider2D nesne)// elmasın içinden geçmeyi ayarlamak için trigger
    {

        if (nesne.gameObject.tag == "elmas")
        {
            Destroy(nesne.gameObject);//dokundugumuz elmas objesini sil
            GetComponent<AudioSource>().PlayOneShot(sesler[0]);
            elmas++;
        }

        if (nesne.gameObject.tag == "can") //değdiğimiz can ise canı ++ yap
        {
            if(can != maxcan)
            {
                can++;
                Destroy(nesne.gameObject);
                CanSistemi();
                GetComponent<AudioSource>().PlayOneShot(sesler[1]);

            }
            
        }

        if (nesne.gameObject.tag == "flag") //değdiğimiz nesnenin tagı flag ise
        {
            //Debug.Log("kapiya değdi"); //consolda değip değmediğini debug etmek için

            

            //Debug.Log(Application.loadedLevelName);
            //int sonrakiLevel = int.Parse(Application.loadedLevelName) + 1;//bir sonraki leveli kaydetmek için kullanıcaz (oldugumuz levelin üstüne bir ekliyoruz)
            //PlayerPrefs.SetInt(sonrakiLevel.ToString(), 1); // bulunduğumuz leveli kaydetmek için integer değerinde 1 se buton aktif olacak
            if (elmas >= 10) //10 elmastan fazla topladıysa level atlasın azsa atlamasın
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    

    }


    void olme()
    {
        Application.LoadLevel(Application.loadedLevelName); //ölme işlemi için gerekli fonksiyon
        
    }

    private void OnCollisionEnter2D(Collision2D nesne)
    {
        if(nesne.gameObject.tag == "Tuzak") //değdiğimiz obje tuzak ise canı azalt  öldür
        {
            Debug.Log("değdi");
            can--;
            agirlik.AddForce(Vector2.up * ziplamagucu/2); //düşmana değdikten sonra zıplatması için
            GetComponent<SpriteRenderer>().color = Color.red; //düşmana değdiği an rengi kırmız olması için
            Invoke("Duzelt",0.5f); //eski renge dönmesi için 0.5 sn de
            CanSistemi();
        }
        
        if(nesne.gameObject.tag == "dalga")
        {

            //olme();
            can--;
            CanSistemi();
            olme();
        }
      
        if(nesne.gameObject.tag == "buzkutu")
        {
            Destroy(nesne.gameObject);
        }
        
    }

    void CanSistemi() // canların sayısı için
    {
        for (int i = 0; i < maxcan; i++)
        {
            canlar[i].SetActive(false); //canlar dizisinde ne kadar eleman varsa o kadar canı ekranda kapatacak
        }
        for (int i = 0; i < can; i++)
        {
                canlar[i].SetActive(true); //canları tekrar açacak

        }
        
    }

    void Duzelt(){

        GetComponent<SpriteRenderer>().color = Color.white;//eski rengine dönmesi için

    }

    void MesajKaldir()
    {
        uyari[0].SetActive(false);


    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneryController : MonoBehaviour {

    GameObject Player;
    public Sprite AltSprite;
    public Sprite Sprite;
    public float MainTime;
    public float AltTime;
    float Timer;
    bool MainForm;
    SpriteRenderer SR;

	// Use this for initialization
	void Start () {
        //Player = GameObject.Find("Player");
        Timer = MainTime;
        MainForm = true;
        SR = (SpriteRenderer)GetComponent("SpriteRenderer");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position - Camera.main.transform.position;
        v.y = 0.0f;
        transform.rotation = Quaternion.LookRotation(v);
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            if (MainForm)
            {
                MainForm = false;
                SR.sprite = AltSprite;
                Timer = AltTime;
            }
            else
            {
                MainForm = true;
                SR.sprite = Sprite;
                Timer = MainTime;
            }
        }

	}
}

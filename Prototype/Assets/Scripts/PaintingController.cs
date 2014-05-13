using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintingController : MonoBehaviour {

    SpriteRenderer Paint;
    public List<Sprite> Paintings;

    public float MainTime;
    public float AltTime;
    float Timer;
    bool MainForm;

	// Use this for initialization
	void Start () {
        Paint = (SpriteRenderer)transform.GetChild(0).gameObject.GetComponent("SpriteRenderer");
        Paint.sprite = Paintings[Random.Range(0,Paintings.Count)];
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            if (MainForm)
            {
                MainForm = false;
                transform.position -= new Vector3(0, 0.1f, 0);
                Timer = AltTime;
            }
            else
            {
                MainForm = true;
                transform.position += new Vector3(0, 0.1f, 0);
                Timer = MainTime;
            }
        }
	}
}

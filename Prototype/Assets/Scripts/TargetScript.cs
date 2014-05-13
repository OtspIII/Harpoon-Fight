using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

    public Material Text1;
    public Material Text2;
    bool norm = true;

	// Use this for initialization
	void Start () {
        renderer.material = Text1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball Detector")
        {
            //Holdable what = (Holdable)collision.gameObject.GetComponent("Holdable");
            if (norm)
            {
                renderer.material = Text2;
                norm = false;
            }
            else
            {
                renderer.material = Text1;
                norm = true;
            }
        }
    }
}

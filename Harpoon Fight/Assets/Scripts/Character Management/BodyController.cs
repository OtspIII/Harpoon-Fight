using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour {

    public CharacterManager Character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision c)
    {
        Character.GetHit(c);
    }
}

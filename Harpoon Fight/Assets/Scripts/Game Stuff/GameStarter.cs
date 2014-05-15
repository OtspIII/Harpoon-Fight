using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStarter : MonoBehaviour {

    public List<SpawnableObject> Spawnables;

	// Use this for initialization
	void Awake () {
        HF.Library.Initialize(Spawnables);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

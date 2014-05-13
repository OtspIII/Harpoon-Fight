using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour {

    public List<GameObject> Scenery;
    public int MinScenery;
    public int MaxScenery;

	// Use this for initialization
	void Start () {
        int num = Random.Range(MinScenery, MaxScenery);
        for (int n = num; n > 0; n--)
        {
            GameObject scenType = Scenery[Random.Range(0, Scenery.Count)];
            Vector3 where = new Vector3(Random.Range(-8.75f,8.75f), 0.73f, Random.Range(-3.75f,3.75f));
            Instantiate(scenType, transform.position + where, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

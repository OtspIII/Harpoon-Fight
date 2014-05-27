using UnityEngine;
using System.Collections;
using HF;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{

    public RoomType Type;
    public List<SpawnerController> Spawners;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual SpawnerController GetSpawner()
    {
        return GetSpawner(0);
    }

    public virtual SpawnerController GetSpawner(int n)
    {
        if (Spawners.Count == 0)
        {
            Debug.Log("ERROR: NO SPAWNERS!");
            return null;
        }
        else if (Spawners.Count <= n)
        {
            Debug.Log("ERROR: Requested too big a number for a spawner!");
            return Spawners[0];
        }
        return Spawners[n];
    }

    public SpawnableObject SpawnObject(Spawnable what, Vector3 where, Quaternion rot)
    {
        SpawnableObject r = (SpawnableObject)((GameObject)Instantiate(HF.Library.GetSpawnable(what).gameObject)).GetComponent("SpawnableObject");
        r.transform.parent = gameObject.transform;
        r.transform.localPosition = where;
        r.transform.localRotation = rot;
        return r;
    }
}

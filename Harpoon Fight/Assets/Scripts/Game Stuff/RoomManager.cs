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
}

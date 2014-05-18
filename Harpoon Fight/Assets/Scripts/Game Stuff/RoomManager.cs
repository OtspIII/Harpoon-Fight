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

    public virtual void RespawnPlayer(CharacterManager who)
    {
        who.ComeAlive();
        int n = 0;
        if (who.Slot == PlayerSlot.PlayerTwo)
            n = 1;
        who.gameObject.transform.position = Spawners[n].transform.position;
        who.gameObject.transform.rotation = Spawners[n].transform.rotation;
    }
}

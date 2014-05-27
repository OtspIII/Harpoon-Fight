using HF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HF.Stages
{
    public class Lane5Stage : StageManager
    {
        public Lane5Stage()
        {
            Type = StageType.Lane5;
        }

        public override void Construct(GameMasterManager gm)
        {
            Rooms = new List<RoomManager>();
            Spawners = new List<SpawnerController>();
            for (float n = 0; n < 5; n++)
            {
                float x = n * 20 - 40;
                Vector3 where = new Vector3(x,0,0);
                RoomManager room = (RoomManager)gm.SpawnObject(Library.GetRoom(RoomType.CoreRoom).gameObject,where,Quaternion.identity)
                    .GetComponent("RoomManager");
                if (n == 0 || n == 4)
                {
                    SpawnerController s = room.GetSpawner();
                    Spawners.Add(s);
                    if (n == 4)
                        s.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
                }
                Rooms.Add(room);
            }
        }
    }
}

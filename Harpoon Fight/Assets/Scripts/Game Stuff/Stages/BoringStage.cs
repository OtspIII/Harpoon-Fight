using HF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HF.Stages
{
    public class BoringStage : StageManager
    {
        public BoringStage()
        {
            Type = StageType.Boring;
        }

        public override void Construct(GameMasterManager gm)
        {
            Rooms = new List<RoomManager>();
            RoomManager room = (RoomManager)gm.SpawnObject(Library.GetRoom(RoomType.Boring).gameObject).GetComponent("RoomManager");
            Spawners = room.Spawners.ToList();
            Rooms.Add(room);
        }
    }
}

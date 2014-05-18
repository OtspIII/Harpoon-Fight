using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HF
{
    public static class Library
    {
        public static CharacterManager Character { get; private set; }
        public static GameObject EyesOne { get; private set; }
        public static GameObject EyesTwo { get; private set; }
        public static HUDManager HUDOne { get; private set; }
        public static HUDManager HUDTwo { get; private set; }
        private static Dictionary<Spawnable, SpawnableObject> Spawnables;
        private static Dictionary<RoomType, RoomManager> Rooms;

        public static void Initialize(CharacterManager cm, GameObject e1, GameObject e2, HUDManager hud1, HUDManager hud2,
            List<SpawnableObject> spawnables, List<RoomManager> rooms)
        {
            Character = cm;
            EyesOne = e1;
            EyesTwo = e2;
            HUDOne = hud1;
            HUDTwo = hud2;
            Spawnables = new Dictionary<Spawnable, SpawnableObject>();
            foreach (SpawnableObject s in spawnables)
            {
                if (Spawnables.ContainsKey(s.Type))
                    continue;
                Spawnables.Add(s.Type, s);
            }

            Rooms = new Dictionary<RoomType, RoomManager>();
            foreach (RoomManager r in rooms)
            {
                if (Rooms.ContainsKey(r.Type))
                    continue;
                Rooms.Add(r.Type, r);
            }

        }

        public static UnityEngine.GameObject GetSpawnable(Spawnable s){
            if (!Spawnables.ContainsKey(s))
                return null;
            return Spawnables[s].gameObject;
        }

        public static UnityEngine.GameObject GetRoom(RoomType r)
        {
            if (!Rooms.ContainsKey(r))
                return null;
            return Rooms[r].gameObject;
        }
    }

    public enum Spawnable{
        Harpoon
    }
}

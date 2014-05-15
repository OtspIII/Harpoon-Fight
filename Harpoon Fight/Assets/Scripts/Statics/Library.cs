using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF
{
    public static class Library
    {
        public static Dictionary<Spawnable, SpawnableObject> Spawnables;

        public static void Initialize(List<SpawnableObject> spawnables)
        {
            Spawnables = new Dictionary<Spawnable, SpawnableObject>();
            foreach (SpawnableObject s in spawnables)
            {
                if (Spawnables.ContainsKey(s.Type))
                    continue;
                Spawnables.Add(s.Type, s);
            }

        }

        public static UnityEngine.GameObject GetSpawnable(Spawnable s){
            if (!Spawnables.ContainsKey(s))
                return null;
            return Spawnables[s].gameObject;
        }
    }

    public enum Spawnable{
        Harpoon
    }
}

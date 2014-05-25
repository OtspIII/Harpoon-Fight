using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF
{
    public class StageManager
    {
        public StageType Type;
        public List<SpawnerController> Spawners;

        public StageManager()
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
                UnityEngine.Debug.Log("ERROR: NO SPAWNERS!");
                return null;
            }
            else if (Spawners.Count <= n)
            {
                UnityEngine.Debug.Log("ERROR: Requested too big a number for a spawner!");
                return Spawners[0];
            }
            return Spawners[n];
        }

        public virtual void Construct(GameMasterManager gm)
        {

        }

        public virtual void RespawnPlayer(CharacterManager who)
        {
            who.ComeAlive();
            SpawnerController sc = FindSpawner(who.Slot);
            who.gameObject.transform.position = sc.transform.position;
            who.gameObject.transform.rotation = sc.transform.rotation;
        }

        protected virtual SpawnerController FindSpawner(PlayerSlot slot)
        {
            int n = 0;
            if (slot == PlayerSlot.PlayerTwo)
                n = 1;
            return Spawners[n];
        }
    }
}

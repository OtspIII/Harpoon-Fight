using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HF
{
    public static class Library
    {
        public static GameMasterManager GM { get; private set; }
        public static CharacterManager Character { get; private set; }
        public static GameObject EyesOne { get; private set; }
        public static GameObject EyesTwo { get; private set; }
        public static HUDManager HUDOne { get; private set; }
        public static HUDManager HUDTwo { get; private set; }
        private static Dictionary<Spawnable, SpawnableObject> Spawnables;
        private static Dictionary<RoomType, RoomManager> Rooms;
        private static Dictionary<SoundClip, AudioClip> SoundClips;
        private static Dictionary<GameMode, GameModeController> GameModes;
        private static Dictionary<StageType, StageManager> Stages;

        public static void Initialize(GameMasterManager gm, CharacterManager cm, GameObject e1, GameObject e2, HUDManager hud1, HUDManager hud2,
            List<SpawnableObject> spawnables, List<RoomManager> rooms, List<GameModeController> modes, List<StageManager> stages)
        {
            GM = gm;
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

            GameModes = new Dictionary<GameMode, GameModeController>();
            foreach (GameModeController m in modes)
            {
                if (GameModes.ContainsKey(m.Type))
                    continue;
                GameModes.Add(m.Type, m);
            }

            Stages = new Dictionary<StageType, StageManager>();
            foreach (StageManager s in stages)
            {
                if (Stages.ContainsKey(s.Type))
                    continue;
                Stages.Add(s.Type, s);
            }

            SoundClips = new Dictionary<SoundClip, AudioClip>();
            AddSound(SoundClip.Fire, "15901__someonesilly__knock");
            AddSound(SoundClip.Reload, "11100__jimpurbrick__fastmidtremelorise");
        }

        private static void AddSound(SoundClip sc, string file)
        {
            if (SoundClips.ContainsKey(sc) || file == "")
                return;
            AudioClip ac = Resources.Load<AudioClip>("Sounds/" + file);
            SoundClips.Add(sc, ac);
        }

        public static SpawnableObject GetSpawnable(Spawnable s){
            if (!Spawnables.ContainsKey(s))
                return null;
            return Spawnables[s];
        }

        public static RoomManager GetRoom(RoomType r)
        {
            if (!Rooms.ContainsKey(r))
                return null;
            return Rooms[r];
        }

        public static GameModeController GetMode(GameMode m)
        {
            if (!GameModes.ContainsKey(m))
                return null;
            return GameModes[m];
        }

        public static StageManager GetStage(StageType s)
        {
            if (!Stages.ContainsKey(s))
                return null;
            return Stages[s];
        }

        public static AudioClip GetSound(SoundClip s)
        {
            if (!SoundClips.ContainsKey(s))
                return null;
            return SoundClips[s];
        }
    }

    public enum Spawnable{
        Harpoon
    }
}

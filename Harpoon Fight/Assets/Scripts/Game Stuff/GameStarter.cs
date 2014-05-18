using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HF;
using HF.Modes;

public class GameStarter : MonoBehaviour
{
    public GameMasterManager GM;
    public CharacterManager Character;
    public GameObject Eyes1;
    public GameObject Eyes2;
    public HUDManager HUD1;
    public HUDManager HUD2;
    public SoundManager Sounds;
    public List<SpawnableObject> Spawnables;
    public List<RoomManager> Rooms;
    private List<GameModeController> Modes;

    // Use this for initialization
    void Awake()
    {
        Modes = new List<GameModeController>();
        Modes.Add(new DeathmatchMode(3));
        HF.Library.Initialize(GM, Character, Eyes1, Eyes2, HUD1, HUD2, Spawnables, Rooms, Modes);
        HF.Sounds.Initialize(Sounds);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

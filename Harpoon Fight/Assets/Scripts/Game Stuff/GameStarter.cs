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
    private List<StageManager> Stages;

    // Use this for initialization
    void Awake()
    {
        Modes = new List<GameModeController>();
        Modes.Add(new DeathmatchMode(3));
        Stages = new List<StageManager>();
        Stages.Add(new HF.Stages.BoringStage());
        Stages.Add(new HF.Stages.Lane5Stage());
        HF.Library.Initialize(GM, Character, Eyes1, Eyes2, HUD1, HUD2, Spawnables, Rooms, Modes, Stages);
        HF.Sounds.Initialize(Sounds);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

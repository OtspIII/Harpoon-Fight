using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStarter : MonoBehaviour
{
    public CharacterManager Character;
    public GameObject Eyes1;
    public GameObject Eyes2;
    public HUDManager HUD1;
    public HUDManager HUD2;
    public SoundManager Sounds;
    public List<SpawnableObject> Spawnables;
    public List<RoomManager> Rooms;

    // Use this for initialization
    void Awake()
    {
        HF.Library.Initialize(Character, Eyes1, Eyes2, HUD1, HUD2, Spawnables, Rooms);
        HF.Sounds.Initialize(Sounds);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

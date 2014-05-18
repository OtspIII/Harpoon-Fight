using UnityEngine;
using System.Collections;
using HF;

public class GameMasterManager : MonoBehaviour
{
    public ControlScheme P1Controls;
    public ControlScheme P2Controls;
    public RoomType Room;
    public HUDManager HUD1;
    public HUDManager HUD2;
    public GameObject Eyes1;
    public GameObject Eyes2;
    public GameMode Mode;

    public CharacterManager CharacterOne { get; private set; }
    public CharacterManager CharacterTwo { get; private set; }
    public GameModeController ModeCon { get; private set; }
    public RoomManager RoomMan { get; private set; }

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        Application.targetFrameRate = 60;
        RoomMan = 
            (RoomManager)((GameObject)Instantiate(HF.Library.GetRoom(Room), Vector3.zero, Quaternion.identity)).GetComponent("RoomManager");
        SpawnerController s1 = RoomMan.Spawners[0];
        SpawnerController s2 = RoomMan.Spawners[1];
        CharacterOne = (CharacterManager)((GameObject)Instantiate(HF.Library.Character.gameObject, s1.transform.position,
            s1.transform.rotation)).GetComponent("CharacterManager");
        CharacterTwo = (CharacterManager)((GameObject)Instantiate(HF.Library.Character.gameObject, s2.transform.position,
            s2.transform.rotation)).GetComponent("CharacterManager");
        CharacterOne.Setup(P1Controls, PlayerSlot.PlayerOne);
        CharacterTwo.Setup(P2Controls, PlayerSlot.PlayerTwo);
        ModeCon = HF.Library.GetMode(GameMode.Deathmatch);
        ModeCon.Setup(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

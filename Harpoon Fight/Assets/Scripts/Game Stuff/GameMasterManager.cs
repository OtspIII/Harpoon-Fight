using UnityEngine;
using System.Collections;
using HF;

public class GameMasterManager : MonoBehaviour
{
    public ControlScheme P1Controls;
    public ControlScheme P2Controls;
    public RoomType Room;
    public StageType Stage;
    public HUDManager HUD1;
    public HUDManager HUD2;
    public GameObject Eyes1;
    public GameObject Eyes2;
    public GameMode Mode;

    public CharacterManager CharacterOne { get; private set; }
    public CharacterManager CharacterTwo { get; private set; }
    public GameModeController ModeCon { get; private set; }
    //public RoomManager RoomMan { get; private set; }
    public StageManager StageMan { get; private set; }

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        Application.targetFrameRate = 60;
        StageMan = Library.GetStage(Stage);
        StageMan.Construct(this);
        //RoomMan = 
        //    (RoomManager)((GameObject)Instantiate(HF.Library.GetRoom(Room), Vector3.zero, Quaternion.identity)).GetComponent("RoomManager");
        SpawnerController s1 = StageMan.GetSpawner(0);
        SpawnerController s2 = StageMan.GetSpawner(1);
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

    public GameObject SpawnObject(GameObject o)
    {
        return (GameObject)Instantiate(o.gameObject, Vector3.zero, Quaternion.identity);
    }

    public GameObject SpawnObject(GameObject o, Vector3 where, Quaternion rot)
    {
        return (GameObject)Instantiate(o.gameObject, where, rot);
    }
}

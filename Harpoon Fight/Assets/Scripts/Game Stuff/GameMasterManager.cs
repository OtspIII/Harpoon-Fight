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

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        Application.targetFrameRate = 60;
        RoomManager room = 
            (RoomManager)((GameObject)Instantiate(HF.Library.GetRoom(Room), Vector3.zero, Quaternion.identity)).GetComponent("RoomManager");
        SpawnerController s1 = room.Spawners[0];
        SpawnerController s2 = room.Spawners[1];
        CharacterManager c1 = (CharacterManager)((GameObject)Instantiate(HF.Library.Character.gameObject, s1.transform.position,
            s1.transform.rotation)).GetComponent("CharacterManager");
        CharacterManager c2 = (CharacterManager)((GameObject)Instantiate(HF.Library.Character.gameObject, s2.transform.position,
            s2.transform.rotation)).GetComponent("CharacterManager");
        c1.Setup(P1Controls, PlayerSlot.PlayerOne);
        c2.Setup(P2Controls, PlayerSlot.PlayerTwo);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HF.Character;
using HF;

public class CharacterManager : MonoBehaviour
{

    public GameObject Body;
    public GameObject Eyes;
    public CharacterController CC;
    public CharacterMotor Motor;
    public HUDManager HUD { get; private set; }
    public Animator Anim;

    public CharacterState State;
    public PlayerSlot Slot { get; private set; }

    private Dictionary<PlayerState, CharacterState> States;
    private Dictionary<PlayerAction, CharacterAction> Actions;

    public bool Loaded = true;

    string InputName;

    // Use this for initialization
    void Start()
    {
        
    }

    public void Setup(ControlScheme con, PlayerSlot ps)
    {
        Slot = ps;
        switch (con)
        {
            case ControlScheme.MouseKeyboard:
                InputName = "MK";
                break;
            case ControlScheme.JoystickOne:
                InputName = "J1";
                break;
        }
        GameObject eyes = null;
        HUDManager hud = null;
        int layer = 0;
        switch (ps)
        {
            case PlayerSlot.PlayerOne:
                eyes = HF.Library.EyesOne;
                hud = HF.Library.HUDOne;
                layer = 9;
                break;
            case PlayerSlot.PlayerTwo:
                eyes = HF.Library.EyesTwo;
                hud = HF.Library.HUDTwo;
                layer = 11;
                break;
        }
        eyes.transform.parent = gameObject.transform;
        eyes.transform.localPosition = new Vector3(0, 0.5f, 0);
        eyes.transform.localRotation = Quaternion.identity;
        Eyes = eyes;
        HUD = hud;
        gameObject.layer = layer;
        Body.layer = layer;
        foreach (Transform t in Body.transform)
            t.gameObject.layer = layer;
        States = new Dictionary<PlayerState, CharacterState>();
        Actions = new Dictionary<PlayerAction, CharacterAction>();
        AddState(new GroundedState());
        AddState(new ReloadingState());
        AddState(new DodgingState());
        AddState(new DeadState());
        SwitchState(PlayerState.Grounded);
        AddAction(new MoveAction());
        AddAction(new LookAction());

        AddAction(new ReloadAction());
        AddAction(new FireAction());
        AddAction(new DodgeAction());
    }

    // Update is called once per frame
    void Update()
    {
        State.Execute();
        foreach (PlayerAction a in State.Actions)
        {
            ExecuteAction(a);
        }
    }

    public float GetInput(string name)
    {
        return Input.GetAxis(name + " " + InputName);
    }

    public bool GetButton(string name)
    {
        return Input.GetButton(name + " " + InputName);
    }

    public void ExecuteAction(PlayerAction a)
    {
        if (!Actions.ContainsKey(a))
            return;
        Actions[a].Execute();
    }

    public void SwitchState(PlayerState s)
    {
        if (!States.ContainsKey(s))
            s = PlayerState.Grounded;
        if (State != null)
            State.End();
        State = States[s];
        State.Start();
    }

    public void AddState(CharacterState s)
    {
        if (States.ContainsKey(s.PS))
            return;
        States.Add(s.PS, s);
        s.Setup(this);
    }

    public void AddAction(CharacterAction a)
    {
        if (Actions.ContainsKey(a.PA))
            return;
        Actions.Add(a.PA, a);
        a.Setup(this);
    }

    public GameObject SpawnObject(GameObject o, Vector3 where, Quaternion rot)
    {
        return (GameObject)Instantiate(o, where, rot);
    }

    public void GetHit(Collision c)
    {
        if ((gameObject.layer == 9 && c.gameObject.layer == 12) || (gameObject.layer == 11 && c.gameObject.layer == 10))
        {
            SwitchState(PlayerState.Dead);
            Debug.Log("DEAD");
        }
    }
}

public enum PlayerAction
{
    None,
    LookAround,
    Move,
    Fire,
    Reload,
    Dodge,
    Slam,
}

public enum PlayerState
{
    None,
    Grounded,
    Dodging,
    Reloading,
    Slamming,
    Dead
}
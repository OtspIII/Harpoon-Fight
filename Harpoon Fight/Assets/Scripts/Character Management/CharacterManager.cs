﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HF.Character;

public class CharacterManager : MonoBehaviour
{

    public GameObject Body;
    public GameObject Eyes;
    public CharacterMotor Motor;

    public CharacterState State;

    private Dictionary<PlayerState, CharacterState> States;
    private Dictionary<PlayerAction,CharacterAction> Actions;

    public string InputName;

    // Use this for initialization
    void Start()
    {
        Setup(new List<CharacterAction> { });
        States = new Dictionary<PlayerState, CharacterState>();
        Actions = new Dictionary<PlayerAction, CharacterAction>();
        AddState(new GroundedState());
        SwitchState(PlayerState.Grounded);
        AddAction(new MoveAction());
        AddAction(new LookAction());
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

    public void Setup(List<CharacterAction> acts)
    {
        foreach (CharacterAction a in acts)
        {
            if (a.PA == PlayerAction.None || Actions.ContainsKey(a.PA))
                continue;
            Actions.Add(a.PA,a);
            a.Setup(this);
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
    Fall
}

public enum PlayerState
{
    None,
    Grounded,
    Jumping,
    Firing,
    Dodging,
    Reloading,
    Slamming
}
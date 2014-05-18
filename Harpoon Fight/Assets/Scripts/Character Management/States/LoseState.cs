using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class LoseState : CharacterState
    {
        public LoseState()
        {
            PS = PlayerState.Lost;
            Actions = new List<PlayerAction> { };
        }

        public override void Start()
        {
            Debug.Log("LOSE STATE");
            C.HUD.SetHandsState(HandsState.Lost);
        }
    }
}
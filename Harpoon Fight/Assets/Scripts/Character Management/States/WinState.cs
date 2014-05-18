using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class WinState : CharacterState
    {
        public WinState()
        {
            PS = PlayerState.Won;
            Actions = new List<PlayerAction> { };
        }

        public override void Start()
        {
            Debug.Log("WIN STATE");
            C.HUD.SetHandsState(HandsState.Won);
        }
    }
}
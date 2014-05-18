using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class WinState : CharacterState
    {
        public WinState()
        {
            Type = PlayerState.Won;
            Actions = new List<PlayerAction> { };
        }

        public override void Start()
        {
            Debug.Log("WIN STATE");
            C.HUD.SetHandsState(HandsState.Won);
        }
    }
}
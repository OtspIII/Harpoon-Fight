using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class GroundedState : CharacterState
    {
        public GroundedState()
        {
            Type = PlayerState.Grounded;
            Actions = new List<PlayerAction> { PlayerAction.LookAround, PlayerAction.Move,
                PlayerAction.Fire, PlayerAction.Dodge, PlayerAction.Reload, PlayerAction.Slam };
        }

        public override void Start()
        {
            C.Anim.SetTrigger("Idle");
        }
    }
}
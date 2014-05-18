using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class DeadState : CharacterState
    {
        public DeadState()
        {
            PS = PlayerState.Dead;
            Actions = new List<PlayerAction> { };
        }

        public override void Start()
        {
            C.HUD.SetHandsState(HandsState.Dead);
            C.Anim.SetTrigger("Die");
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class GroundedState : CharacterState
    {
        public GroundedState()
        {
            PS = PlayerState.Grounded;
            Actions = new List<PlayerAction> { PlayerAction.LookAround, PlayerAction.Move, PlayerAction.Fall,
                PlayerAction.Fire, PlayerAction.Dodge, PlayerAction.Reload, PlayerAction.Slam };
        }
    }
}
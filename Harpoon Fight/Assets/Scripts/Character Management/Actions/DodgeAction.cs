using UnityEngine;
using System.Collections;

namespace HF.Character
{
    public class DodgeAction : CharacterAction
    {

        public DodgeAction()
        {
            PA = PlayerAction.Dodge;
        }

        public override void Execute()
        {
            if (!C.GetButton("Dodge") || (C.GetInput("Horizontal") == 0 && C.GetInput("Vertical") == 0))
                return;
            C.SwitchState(PlayerState.Dodging);
        }
    }
}
using UnityEngine;
using System.Collections;

namespace HF.Character
{
    public class ReloadAction : CharacterAction
    {
        

        public ReloadAction()
        {
            PA = PlayerAction.Reload;
        }

        public override void Execute()
        {
            if (!C.GetButton("Reload"))
                return;
            if (C.Loaded)
            {
                CantReloadFeedback();
                return;
            }
            C.SwitchState(PlayerState.Reloading);
        }

        public void CantReloadFeedback()
        {

        }
    }
}
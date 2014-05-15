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
            
        }
    }
}
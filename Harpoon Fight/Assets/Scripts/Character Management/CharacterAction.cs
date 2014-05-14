using UnityEngine;
using System.Collections;

namespace HF.Character
{
    public class CharacterAction
    {
        public CharacterManager C;
        public PlayerAction PA = PlayerAction.None;

        public virtual void Setup(CharacterManager c)
        {
            C = c;
        }

        public virtual void Execute()
        {
            
        }
    }
}
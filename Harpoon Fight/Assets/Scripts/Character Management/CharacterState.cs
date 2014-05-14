using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class CharacterState
    {
        public CharacterManager C;
        public List<PlayerAction> Actions;
        public PlayerState PS = PlayerState.None;

        public virtual CharacterState Setup(CharacterManager c)
        {
            C = c;
            return this;
        }

        public virtual void Start()
        {

        }

        public virtual void Execute()
        {
            
        }

        public virtual void End()
        {

        }
    }
}
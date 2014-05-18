using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class DeadState : CharacterState
    {
        float TimerMax = 3;
        float Timer = 0;

        public DeadState()
        {
            Type = PlayerState.Dead;
            Actions = new List<PlayerAction> { };
        }

        public override void Start()
        {
            C.HUD.SetHandsState(HandsState.Dead);
            C.Anim.SetTrigger("Die");
            HF.Library.GM.ModeCon.HearDeath(C.Slot);
            Timer = TimerMax;
        }

        public override void Execute()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
                HF.Library.GM.RoomMan.RespawnPlayer(C);
        }

        public override void End()
        {
            
        }
    }
}
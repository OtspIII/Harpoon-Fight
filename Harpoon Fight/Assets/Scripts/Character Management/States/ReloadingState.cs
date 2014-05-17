using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class ReloadingState : CharacterState
    {
        float TimerMax = 1;
        float Timer = 0;

        float SavedMF = 0;
        float SavedMS = 0;
        float SavedMB = 0;

        public ReloadingState()
        {
            PS = PlayerState.Reloading;
            Actions = new List<PlayerAction> { PlayerAction.LookAround };
        }

        public override void Start()
        {
            SavedMF = C.Motor.movement.maxForwardSpeed;
            C.Motor.movement.maxForwardSpeed = 0.001f;
            SavedMS = C.Motor.movement.maxSidewaysSpeed;
            C.Motor.movement.maxSidewaysSpeed = 0.001f;
            SavedMB = C.Motor.movement.maxBackwardsSpeed;
            C.Motor.movement.maxBackwardsSpeed = 0.001f;
            Timer = TimerMax;
            C.HUD.SetHandsState(HandsState.Reloading);
        }

        public override void Execute()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
                C.SwitchState(PlayerState.Grounded);
        }

        public override void End()
        {
            C.Motor.movement.maxForwardSpeed = SavedMF;
            C.Motor.movement.maxSidewaysSpeed = SavedMS;
            C.Motor.movement.maxBackwardsSpeed = SavedMB;
            C.HUD.SetHandsState(HandsState.Loaded);
            C.Loaded = true;
        }
    }
}
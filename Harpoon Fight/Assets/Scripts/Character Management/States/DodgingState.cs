using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HF.Character
{
    public class DodgingState : CharacterState
    {
        float DashSpeed = 0.1f;

        float TimerMax = 1;
        float Timer = 0;

        float EyeHeight = 0.5f;

        Vector3 DashDir = Vector3.zero;

        public DodgingState()
        {
            PS = PlayerState.Dodging;
            Actions = new List<PlayerAction> { PlayerAction.LookAround, PlayerAction.Fire };
        }

        public override void Start()
        {
            Timer = TimerMax;
            float forward = C.GetInput("Vertical");
            float right = C.GetInput("Horizontal");
            float sum = Mathf.Abs(forward) + Mathf.Abs(right);
            if (sum < 1)
            {
                float mult = 1 / sum;
                forward *= mult;
                right *= mult;
            }
            Vector3 dir = new Vector3(DashSpeed * right, 0, DashSpeed * forward);
            dir = C.transform.TransformDirection(dir);
            DashDir = dir;
            Timer = TimerMax;
        }

        public override void Execute()
        {
            float x = Mathf.Lerp(DashDir.x, 0, (TimerMax - Timer) / TimerMax);
            float y = Mathf.Lerp(DashDir.y, 0, (TimerMax - Timer) / TimerMax);
            float z = Mathf.Lerp(DashDir.z, 0, (TimerMax - Timer) / TimerMax);
            C.CC.Move(new Vector3(x, y, z));
            Vector3 eyePos = C.Eyes.transform.localPosition;
            if (Timer > 0.1f)
                eyePos.y = Mathf.Lerp(EyeHeight, -EyeHeight, (TimerMax - (Timer - 0.1f)) / (TimerMax - 0.1f));
            else
                eyePos.y = Mathf.Lerp(-EyeHeight, EyeHeight, (0.1f - Timer) / 0.1f);
            C.Eyes.transform.localPosition = eyePos;
            Timer -= Time.deltaTime;
            if (Timer <= 0)
                C.SwitchState(PlayerState.Grounded);
        }

        public override void End()
        {
        }
    }
}
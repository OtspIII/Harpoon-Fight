﻿using UnityEngine;
using System.Collections;

namespace HF.Character
{
    public class FireAction : CharacterAction
    {
        

        public FireAction()
        {
            PA = PlayerAction.Fire;
        }

        public override void Execute()
        {
            if (!C.GetButton("Fire"))
                return;
            if (!C.Loaded)
            {
                CantFireFeedback();
                return;
            }
            GameObject h = C.SpawnObject(HF.Library.GetSpawnable(Spawnable.Harpoon), C.Eyes.transform.position, C.Eyes.transform.rotation);
            Vector3 rot = h.transform.rotation.eulerAngles;
            rot.x += 90;

            h.transform.rotation = Quaternion.Euler(rot);
            //GameObject h = C.SpawnObject(HF.Library.GetSpawnable(Spawnable.Harpoon), C.transform.position, C.transform.rotation + new Quaternion(90, 0, 0, 0));
            h.rigidbody.velocity = C.Eyes.transform.forward * 25f;
            h.gameObject.layer = C.gameObject.layer + 1;
            C.Loaded = false;
            C.HUD.SetHandsState(HandsState.Empty);
            HF.Sounds.PlaySound(C.Slot, SoundClip.Fire);
        }

        public void CantFireFeedback()
        {

        }
    }
}
using UnityEngine;
using System.Collections;

namespace HF.Character
{
    public class LookAction : CharacterAction
    {
        public float sensitivityX = 15F;
        public float sensitivityY = 15F;

        public float minimumX = -360F;
        public float maximumX = 360F;

        public float minimumY = -60F;
        public float maximumY = 60F;

        float rotationY = 0F;

        public LookAction()
        {
            PA = PlayerAction.LookAround;
        }

        public override void Execute()
        {
            C.gameObject.transform.Rotate(0, C.GetInput("Aim X") * sensitivityX, 0);

            rotationY += C.GetInput("Aim Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            C.Eyes.transform.localEulerAngles = new Vector3(-rotationY, C.Eyes.transform.localEulerAngles.y, 0);
        }
    }
}
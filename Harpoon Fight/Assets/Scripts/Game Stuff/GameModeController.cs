using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF
{
    public class GameModeController
    {

        protected GameMasterManager GM;
        public GameMode Type { get; protected set; }

        public virtual void Setup(GameMasterManager gm)
        {
            GM = gm;
        }

        public virtual void HearDeath(PlayerSlot who)
        {

        }

        public virtual void SetWinner(PlayerSlot who)
        {
            UnityEngine.Debug.Log("WIN");
            CharacterManager winner = null;
            CharacterManager loser = null;
            switch (who)
            {
                case PlayerSlot.PlayerOne:
                    winner = GM.CharacterOne;
                    loser = GM.CharacterTwo;
                    break;
                case PlayerSlot.PlayerTwo:
                    winner = GM.CharacterTwo;
                    loser = GM.CharacterOne;
                    break;
            }
            winner.SwitchState(PlayerState.Won);
            loser.SwitchState(PlayerState.Lost);
        }

    }
}

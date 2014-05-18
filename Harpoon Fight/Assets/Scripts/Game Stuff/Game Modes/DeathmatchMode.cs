using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF.Modes
{
    class DeathmatchMode : GameModeController
    {
        protected int WinScore;
        protected int P1Score = 0;
        protected int P2Score = 0;

        public DeathmatchMode(int score)
        {
            Type = GameMode.Deathmatch;
            WinScore = score;
        }

        public override void HearDeath(PlayerSlot who)
        {
            switch (who)
            {
                case PlayerSlot.PlayerOne:
                    P2Score++;
                    if (P2Score >= WinScore)
                    {
                        SetWinner(PlayerSlot.PlayerTwo);
                    }
                    break;
                case PlayerSlot.PlayerTwo:
                    P1Score++;
                    if (P1Score >= WinScore)
                    {
                        SetWinner(PlayerSlot.PlayerOne);
                    }
                    break;
            }
        }

    }
}

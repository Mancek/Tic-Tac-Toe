using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    class Game
    {
        public Game(int nrPlayer)
        {
            NrPlayer = nrPlayer;
        }

        public int NrPlayer { get; private set; }

        public int[] Result { get; private set; } = { 0, 0 };

        private readonly int[] Positions = new int[10];

        public int Move(int pos)
        {
            if (IsTaken(pos))
            {
                return 4;
            }

            Positions[pos] = NrPlayer;
            return CheckWinner();
        }

        public void Reset()
        {
            for (int i = 0; i < Positions.Length; i++)
            {
                Positions[i] = 0;
            }
        }

        public void SetPlayer() => NrPlayer = NrPlayer == 1 ? 2 : 1;

        public bool IsTaken(int pos) => Positions[pos] != 0;

        private int CheckWinner()
        {
            if (Positions[1] != 0 && Positions[1] == Positions[2] && Positions[2] == Positions[3])
            {
                Result[Positions[1] - 1]++;
                return Positions[1];
            }
            else if (Positions[4] != 0 && Positions[4] == Positions[5] && Positions[5] == Positions[6])
            {
                Result[Positions[4] - 1]++;
                return Positions[4];
            }
            else if (Positions[7] != 0 && Positions[7] == Positions[8] && Positions[8] == Positions[9])
            {
                Result[Positions[7] - 1]++;
                return Positions[7];
            }
            else if (Positions[1] != 0 && Positions[1] == Positions[5] && Positions[5] == Positions[9])
            {
                Result[Positions[1] - 1]++;
                return Positions[1];
            }
            else if (Positions[3] != 0 && Positions[3] == Positions[5] && Positions[5] == Positions[7])
            {
                Result[Positions[3] - 1]++;
                return Positions[3];
            }
            else if (Positions[1] != 0 && Positions[1] == Positions[4] && Positions[4] == Positions[7])
            {
                Result[Positions[1] - 1]++;
                return Positions[1];
            }
            else if (Positions[2] != 0 && Positions[2] == Positions[5] && Positions[5] == Positions[8])
            {
                Result[Positions[2] - 1]++;
                return Positions[2];
            }
            else if (Positions[3] != 0 && Positions[3] == Positions[6] && Positions[6] == Positions[9])
            {
                Result[Positions[3] - 1]++;
                return Positions[3];
            }
            else if (Positions[1] != 0 && Positions[2] != 0 && Positions[3] != 0 && 
                Positions[4] != 0 && Positions[5] != 0 && Positions[6] != 0 &&
                Positions[7] != 0 && Positions[8] != 0 && Positions[9] != 0)
            { 
                return 3;
            }
            return 0;
        }
    }
}

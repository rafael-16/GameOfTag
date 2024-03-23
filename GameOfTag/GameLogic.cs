using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfTag
{
    internal class GameLogic
    {
        int size = 4;
        int[,] map;
        int spaceX;
        int spaceY;
        static Random random = new Random();

        public GameLogic()
        {
            map = new int[size, size];
        }

        public void Start()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    map[i, j] = ConvertCoordsToPosition(i, j) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }

        public bool CheckNumber()
        {
            if (!(spaceX == size - 1 && spaceY == size - 1))
                return false;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (!(i == size - 1 && j == size - 1))
                        if (map[i, j] != ConvertCoordsToPosition(i, j) + 1)
                            return false;
                }

            return true;
        }

        public int GetNumber(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        public void Shift(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }

        public void ShiftRandom()
        {
            int number = random.Next(0, 4);
            int x = spaceX;
            int y = spaceY;

            switch (number)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            Shift(ConvertCoordsToPosition(x, y));
        }

        private int ConvertCoordsToPosition(int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > size - 1) x = size - 1;
            if (y > size - 1) y = size - 1;

            return x * size + y;
        }

        private void ConvertPositionToCoords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;

            x = position * size;
            y = position / size;
        }
    }
}

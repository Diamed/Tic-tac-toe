namespace Tic_tac_toe.Model
{
    public sealed class ApplicationModel
    {
        private string[,] Field;
        public int Step { get; private set; } = 0;
        public string Marker => Step == 0 ? "X" : "O";

        public ApplicationModel()
        {
            Field = new string[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Field[row, column] = null;
                }
            }
        }

        public ApplicationModel NewGame()
        {
            return new ApplicationModel();
        }

        public void NextStep()
        {
            if (Step == 0)
            {
                Step++;
            }
            else
            {
                Step--;
            }
        }

        public bool SetField(string cell)
        {
            var indexes = cell.Split(',');
            int row = int.Parse(indexes[0]);
            int column = int.Parse(indexes[1]);

            if (Field[row, column] == null)
            {
                Field[row, column] = Step.ToString();
                return true;
            }

            return false;
        }

        public bool IsFinish()
        {
            int rowFlags = 0;
            int columnFlags = 0;
            int diagonalFlags = 0;
            // Проверяем ряды
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Field[row, column] == Step.ToString())
                    {
                        rowFlags++;
                    }
                    if (rowFlags == 3)
                    {
                        return true;
                    }
                }
                rowFlags = 0;
            }

            // Проверяем столбцы
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Field[row, column] == Step.ToString())
                    {
                        columnFlags++;
                    }
                    if (columnFlags == 3)
                    {
                        return true;
                    }
                }
                columnFlags = 0;
            }

            for (int row = 0, column = 0; row < 3; row++, column++)
            {
                if (Field[row, column] == Step.ToString())
                {
                    diagonalFlags++;
                }
                if (diagonalFlags == 3)
                {
                    return true;
                }
            }
            diagonalFlags = 0;

            for (int row = 0, column = 2; row < 3; row++, column--)
            {
                if (Field[row, column] == Step.ToString())
                {
                    diagonalFlags++;
                }
                if (diagonalFlags == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDraw()
        {
            int drawCount = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Field[row, column] != null)
                    {
                        drawCount++;
                    }
                }
            }

            return drawCount == 9;
        }
    }
}

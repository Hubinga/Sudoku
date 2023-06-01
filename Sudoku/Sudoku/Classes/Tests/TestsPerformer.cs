namespace Sudoku.Classes.Tests
{
    public class TestsPerformer
    {
        private string path = "..\\..\\TestSudokuInputs\\";
        private SudokuSolver solver = new SudokuSolver();
        private SudokuCreator creator = new SudokuCreator();

        public void StartTestCases()
        {
            Console.WriteLine("Tests started!");

            var directories = Directory.EnumerateDirectories(path);

            foreach (var dir in directories)
            {
                Console.WriteLine(Path.GetFileName(dir));
                string[] files = Directory.GetFiles(dir);
                if (files.Length < 2)
                {
                    Console.WriteLine("No input or solution file found!");
                    return;
                }
                IsCorrectSolution(files[0], files[1]);
                Console.WriteLine();
            }
        }

        private string ReadSudokuTestFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        private bool CompareBoards(int[,] solvedBoard, int[,] wantedSolvedBoard)
        {
            for (int i = 0; i < solvedBoard.GetLength(0); i++)
            {
                for (int j = 0; j < solvedBoard.GetLength(1); j++)
                {
                    if (solvedBoard[i, j] != wantedSolvedBoard[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Print(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            return true;
        }

        private bool IsCorrectSolution(string inputFileName, string solutionFileName)
        {
            try
            {
                string[] input = ReadSudokuTestFile(inputFileName).Split(",");
                string[] solution = ReadSudokuTestFile(solutionFileName).Split(",");

                int[,] originalBoard = creator.ConvertBoardStringToIntArray(input);
                int[,] wantedSolvedBoard = creator.ConvertBoardStringToIntArray(solution);

                Console.WriteLine("Original Board");
                Print(originalBoard);

                Sudoku sudoku = new Sudoku(originalBoard);

                bool isPossible = solver.IsSudokuPossible(sudoku);

                if (!isPossible)
                {
                    Console.WriteLine("Sudoku from TestFile \"{0}\" is not possible!", inputFileName);
                }

                solver.GenerateSolution(sudoku);
                bool result = CompareBoards(sudoku.SolvedBoard, wantedSolvedBoard);

                if (!result)
                {
                    Console.WriteLine("Sudoku from TestFile \"{0}\" is not correct resolved!", inputFileName);
                }
                else
                {
                    Console.WriteLine("Sudoku from TestFile \"{0}\" is correct resolved!", inputFileName);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

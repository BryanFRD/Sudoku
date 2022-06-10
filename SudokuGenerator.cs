namespace Sudoku{
    
    public class SudokuGenerator {
        
        private SudokuDifficulty difficulty;
        private int[,] generatedGameArray;
        
        public SudokuGenerator(SudokuDifficulty difficulty){
            this.difficulty = difficulty;
            
            switch (difficulty){
                case SudokuDifficulty.EASY:
                GenerateEasyArray();
                break;
                case SudokuDifficulty.HARD:
                GenerateHardArray();
                break;
                case SudokuDifficulty.TEST:
                GenerateTestArray();
                break;
                case SudokuDifficulty.NORMAL:
                GenerateNormalArray();
                break;
                default:
                generatedGameArray = new int[9, 9];
                break;
            }
        }
        
        public int[,] GetGameArray(){
            return generatedGameArray;
        }
        
        private void GenerateEasyArray(){
            generatedGameArray = new int[9, 9];
        }
        
        private void GenerateNormalArray(){
            generatedGameArray = new int[9, 9];
        }
        
        private void GenerateHardArray(){
            generatedGameArray = new int[9, 9];
        }
        
        private void GenerateTestArray(){
            generatedGameArray = new int[9, 9]{
                {0, 0, 6, 2, 5, 7, 8, 3, 1},
                {0, 1, 5, 9, 8, 4, 6, 7, 2},
                {2, 7, 8, 6, 1, 3, 5, 4, 9},
                {6, 2, 9, 3, 7, 8, 4, 1, 5},
                {8, 5, 1, 4, 2, 9, 7, 6, 3},
                {7, 4, 3, 5, 6, 1, 9, 2, 8},
                {1, 8, 2, 7, 4, 5, 3, 9, 6},
                {5, 3, 7, 1, 9, 6, 2, 8, 4},
                {9, 6, 4, 8, 3, 2, 1, 5, 7}
            };
        }
        
        public SudokuDifficulty GetDifficulty(){
            return difficulty;
        }
        
    }
    
}
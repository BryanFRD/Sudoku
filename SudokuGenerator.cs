namespace Sudoku{
    
    public class SudokuGenerator {
        
        private SudokuDifficulty difficulty;
        int total = 0;
        private int[,] generatedGameArray;
        
        public SudokuGenerator(SudokuDifficulty difficulty){
            this.difficulty = difficulty;
            
            if(difficulty == SudokuDifficulty.TEST){
                generatedGameArray = GenerateTestArray();
                total = 405 - 9 - 4 - 3;
            } else {
                generatedGameArray = new int[9, 9];
                total = 0;
            }
        }
        
        public int[,] GetGameArray(){
            return generatedGameArray;
        }
        
        private int[,] GenerateTestArray(){
            return new int[,]{
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
        
        public int GetTotal(){
            return total;
        }
        
    }
    
}
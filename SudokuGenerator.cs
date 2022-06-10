namespace Sudoku{
    
    public class SudokuGenerator {
        
        private int[,] generatedGameArray;
        
        public SudokuGenerator(SudokuDifficulty difficulty){
            //TODO Difficulty
            generatedGameArray = new int[9, 9];
        }
        
        public int[,] GetGameArray(){
            return generatedGameArray;
        }
        
    }
    
}
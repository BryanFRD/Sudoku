namespace Sudoku {
    
    public class SudokuGame {
        
        private const int TOTAL_SUDOKU = 405;
        private int total = 0;
        
        private int[,] gameArray;
        
        public SudokuGame(int[,] gameArray){
            this.gameArray = gameArray;
        }
        
        public void SetValue(int x, int y, int value){
            if(x < 0 || x > 9 || y < 0 || y > 9){
                return;
            }
            value = value >= 9 ? 9 : value <= 0 ? 0 : value;
            
            total += gameArray[x, y] + value;
            
            gameArray[x, y] = value;
        }
        
        public int GetValue(int x, int y){
            return gameArray[x, y];
        }
        
        public bool HasWon(){
            return SoftVerif() && HardVerif();
        }
        
        private bool SoftVerif(){
            foreach(int i in gameArray){
                if(i == 0){
                    return false;
                }
            }
            
            return total == TOTAL_SUDOKU;
        }
        
        private bool HardVerif(){
            for(int x = 0; x < 9; x++){
                int[] tempArray = new int[9];
                for(int y = 0; y < 9; y++){
                    if(tempArray.Contains(gameArray[x, y])){
                        return false;
                    }
                    tempArray[y] = gameArray[x, y];
                }
            }
            
            for(int y = 0; y < 9; y++){
                int[] tempArray = new int[9];
                for(int x = 0; x < 9; x++){
                    if(tempArray.Contains(gameArray[x, y])){
                        return false;
                    }
                    tempArray[x] = gameArray[x, y];
                }
            }
            
            for(int i = 0; i <= 9; i += 3){
                for(int j = 0; j <= 9; j += 3){
                    int[] tempArray = new int[9];
                    for(int x = 0; x < 3; x++){
                        for(int y = 0; y < 3; i++){
                            if(tempArray.Contains(gameArray[x + i, y + j])){
                                return false;
                            }
                            tempArray[x * 3 + y] = gameArray[x + i, y + j];
                        }
                    }
                }
            }
            
            return true;
        }
        
    }
    
}
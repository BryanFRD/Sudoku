namespace Sudoku
{
    class Program {
        
        private static SodokuGame sudokuGame;
        
        static void Main(){
            sudokuGame = new SodokuGame(new SudokuGenerator(SudokuDifficulty.NORMAL).GetGameArray());
            
            AskToPlay();
        }
        
        public static void AskToPlay(){
            string userInput;
            do {
                Write("Souhaitez lancez une partie ? (Y/N)");
                userInput = Console.ReadLine();
            } while(userInput != null && (userInput == "Y" || userInput == "N"));
            
            if(userInput == "Y"){
                LaunchGame();
            } else {
                WriteLine("Adieu !");
            }
        }
        
        private static void LaunchGame(){
            while(true){
                
                
                if(sudokuGame.HasWon()){
                    WriteLine("Félicitation, Vous avez gagné !", ConsoleColor.Green);
                }
            }
            
            AskToPlay();
        }
        
        private static void ShowGrid(){
            
        }
        
        private static void Write(String text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black){
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            Console.ResetColor();
        }
        
        private static void WriteLine(String text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black){
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        
    }
}
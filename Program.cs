namespace Sudoku
{
    using System.Text.RegularExpressions;
    class Program {
        
        private static SudokuGame sudokuGame;
        private static Regex regex = new Regex(@"([a-zA-Z])(\d)\s(\d)");
        
        static void Main(){
            sudokuGame = new SudokuGame(new SudokuGenerator(SudokuDifficulty.TEST));
            
            AskToPlay();
        }
        
        public static void AskToPlay(){
            string userInput;
            do {
                Write("Souhaitez lancez une partie ? (Y/N)");
                userInput = Console.ReadLine();
            } while(!string.IsNullOrWhiteSpace(userInput) && !((userInput.ToLower() == "y") || (userInput.ToLower() == "n")));
            
            if(userInput.ToLower() == "y"){
                LaunchGame();
            } else {
                WriteLine("Adieu !");
            }
        }
        
        private static void LaunchGame(){
            while(true){
                ShowGrid();
                
                Match match = AskPlayerInput();
                
                int x = char.Parse(match.Groups[1].Value.ToLower()) - 'a', y = int.Parse(match.Groups[2].Value),
                value = int.Parse(match.Groups[3].Value);
                
                sudokuGame.SetValue(x, y, value);
                
                if(sudokuGame.HasWon()){
                    WriteLine("Félicitation, Vous avez gagné !", ConsoleColor.Green);
                    ShowGrid();
                    break;
                }
            }
            
            AskToPlay();
        }
        
        private static Match AskPlayerInput(){
            Write("Entrez vos coordonnées et la valeur : (A5 2) ");
            string userInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(userInput) && regex.IsMatch(userInput)){
                return regex.Match(userInput);
            }
            
            WriteLine("Impossible de rentrer ses valeurs", ConsoleColor.Red);
            return AskPlayerInput();
        }
        
        public static void ShowGrid(){
            WriteLine("");
            int i = 1;
            ConsoleColor[] foregroundColors = {ConsoleColor.Black, ConsoleColor.White};
            ConsoleColor[] backgroundColors = {ConsoleColor.Gray, ConsoleColor.DarkGray};
            for(int x = -1; x < 9; x++){
                for(int y = -1; y < 9; y++){
                    if(y == -1 && x > 0 && x % 3 == 0){
                        WriteLine("");
                        i++;
                    }
                    if(y > 0 && y % 3 == 0){
                        Write("  ");
                        i++;
                    }
                    
                    
                    if(x == -1 && y > -1){
                        Write("" + y + " ");
                    } else if(x > -1 && y == -1){
                        Write("" + Convert.ToChar(x + 'A') + " ");
                    } else if(x > -1 && y > -1){
                        int value = sudokuGame.GetValue(x, y);
                        Write(value == 0 ? "  " : "" + value + " ", foregroundColors[i % foregroundColors.Length], backgroundColors[i % backgroundColors.Length]);
                    } else {
                        Write("  ");
                    }
                    i++;
                }
                i++;
                WriteLine("");
            }
        }
        
        public static void Write(String text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black){
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            Console.ResetColor();
        }
        
        public static void WriteLine(String text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black){
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        
    }
}
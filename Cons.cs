using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Cons
    {
        private static int chieuRongHangRao = 80;
        private static int chieuCaoHangRao = 25;
        
        private static int score = 0; // Điểm số
        
        private static int moneyX; // Tọa độ X của tiền
        private static int moneyY; // Tọa độ Y của tiền

        private static char money = '$'; // icon của tiền

        private static bool endGame = false; // Biến kiểm tra trạng thái kết thúc trò chơi

        private static char snake = 'O'; // icon vẽ con rắn
        private static int headX; // Tọa độ X của đầu rắn
        private static int headY; // Tọa độ Y của đầu rắn
        private static int directMove; // Hướng di chuyển của rắn (0: lên, 1: xuống, 2: trái, 3: phải)

        private static char selectNumber = Console.ReadKey().KeyChar;

        private static bool isBoosting = false;

        private static int speed = 100;

        public static int ChieuRongHangRao { get => chieuRongHangRao; set => chieuRongHangRao = value; }
        public static int ChieuCaoHangRao { get => chieuCaoHangRao; set => chieuCaoHangRao = value; }
        public static int Score { get => score; set => score = value; }
        public static int MoneyX { get => moneyX; set => moneyX = value; }
        public static int MoneyY { get => moneyY; set => moneyY = value; }
        public static char Money { get => money; set => money = value; }
        public static bool EndGame { get => endGame; set => endGame = value; }
        public static char Snake { get => snake; set => snake = value; }
        public static int HeadX { get => headX; set => headX = value; }
        public static int HeadY { get => headY; set => headY = value; }
        public static int DirectMove { get => directMove; set => directMove = value; }
        public static char SelectNumber { get => selectNumber; set => selectNumber = value; }
        public static bool IsBoosting { get => isBoosting; set => isBoosting = value; }
        public static int Speed { get => speed; set => speed = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    internal class DrawObject
    {
        #region
        public static List<int> snakeX = new List<int>(); // Danh sách lưu tọa độ X của con rắn
        public static List<int> snakeY = new List<int>(); // Danh sách lưu tọa độ Y của con rắn

        public static Random random = new Random();
        #endregion

        // Khởi tạo con rắn
        public static void GenerateSnake()
        {
            // Ban đầu con rắn có độ dài là 2
            // Tạo ra một con rắn có dạng ** ở giữa bảng

            // Vị trí xuất phát của đầu con rắn
            snakeX.Add(Cons.ChieuRongHangRao / 2);
            snakeY.Add(Cons.ChieuCaoHangRao / 2);

            snakeX.Add((Cons.ChieuRongHangRao / 2) - 1);
            snakeY.Add(Cons.ChieuCaoHangRao / 2);

            snakeX.Add((Cons.ChieuRongHangRao / 2) - 2);
            snakeY.Add(Cons.ChieuCaoHangRao / 2);

            // Đặt đầu rắn ở vị trí đầu tiên của danh sách
            Cons.HeadX = snakeX[0];
            Cons.HeadY = snakeY[0];

            // Đặt hướng di chuyển ban đầu là bên phải
            // Hướng di chuyển của rắn (0: lên, 1: xuống, 2: trái, 3: phải)
            Cons.DirectMove = 3;
        }
        public static void DrawSnake()
        {
            // Vẽ con rắn
            for (int i = 0; i < snakeX.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(snakeX[i], snakeY[i]);
                Console.Write(Cons.Snake);
                
            }
            Console.ResetColor();
        }

        // Random vị trí của tiền
        public static void GenerateMoney()
        {
            // Sinh tọa độ X và Y ngẫu nhiên trong phạm vi của hàng rào
            Cons.MoneyX = random.Next(1, Cons.ChieuRongHangRao - 1);
            Cons.MoneyY = random.Next(1, Cons.ChieuCaoHangRao - 1);

            // Kiểm tra xem tọa độ của tiền có trùng với con rắn hay không (rắn đã ăn tiền chưa)
            // Nếu có thì random chỗ khác
            for (int i = 0; i < snakeX.Count; i++)
            {
                if (Cons.MoneyX == snakeX[i] && Cons.MoneyY == snakeY[i])
                {
                    GenerateMoney();
                    break;
                }
                if (
                    ((Cons.MoneyX >= 4 && Cons.MoneyX <= 9) && Cons.MoneyY == 5) ||
                    ((Cons.MoneyX >= 8 && Cons.MoneyX <= 13) && Cons.MoneyY == 19) ||
                    ((Cons.MoneyX >= 14 && Cons.MoneyX <= 19) && Cons.MoneyY == 10) ||
                    ((Cons.MoneyX >= 24 && Cons.MoneyX <= 29) && Cons.MoneyY == 15) ||
                    ((Cons.MoneyX >= 34 && Cons.MoneyX <= 39) && Cons.MoneyY == 20) ||
                    ((Cons.MoneyX >= 64 && Cons.MoneyX <= 69) && Cons.MoneyY == 7) ||
                    ((Cons.MoneyX >= 44 && Cons.MoneyX <= 49) && Cons.MoneyY == 14) ||
                    ((Cons.MoneyX >= 46 && Cons.MoneyX <= 51) && Cons.MoneyY == 3) ||
                    ((Cons.MoneyX >= 33 && Cons.MoneyX <= 38) && Cons.MoneyY == 6) ||
                    ((Cons.MoneyX >= 60 && Cons.MoneyX <= 65) && Cons.MoneyY == 20)
                   )
                {
                    GenerateMoney();
                    break;
                }
            }
        }
        public static void DrawMoney()
        {
            // Vẽ icon tiền
            Console.SetCursorPosition(Cons.MoneyX, Cons.MoneyY);
            Console.Write(Cons.Money);
        }

        public static void DrawScore()
        {
            // Vẽ điểm số
            Console.SetCursorPosition((Cons.ChieuRongHangRao / 2) - 9, Cons.ChieuCaoHangRao);
            Console.Write("Điểm của bạn là: " + Cons.Score);
        }

        public static void DrawObstacle()
        {
            // Vẽ 10 bức tường làm vật cản
            for (int i = 4; i < 10; i++)
            {
                Console.SetCursorPosition(i, 5);
                Console.Write("+");
            }
            for (int i = 14; i < 20; i++)
            {
                Console.SetCursorPosition(i, 10);
                Console.Write("+");
            }
            for (int i = 24; i < 30; i++)
            {
                Console.SetCursorPosition(i, 15);
                Console.Write("+");
            }
            for (int i = 34; i < 40; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("+");
            }
            for (int i = 64; i < 70; i++)
            {
                Console.SetCursorPosition(i, 7);
                Console.Write("+");
            }
            for (int i = 44; i < 50; i++)
            {
                Console.SetCursorPosition(i, 14);
                Console.Write("+");
            }
            for (int i = 46; i < 52; i++)
            {
                Console.SetCursorPosition(i, 3);
                Console.Write("+");
            }
            for (int i = 33; i < 39; i++)
            {
                Console.SetCursorPosition(i, 6);
                Console.Write("+");
            }
            for (int i = 8; i < 14; i++)
            {
                Console.SetCursorPosition(i, 19);
                Console.Write("+");
            }
            for (int i = 60; i < 66; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write("+");
            }
        }
    }
}

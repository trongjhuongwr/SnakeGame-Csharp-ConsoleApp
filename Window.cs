using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Window
    {
        public static void WindowStart() 
        {
            //// Thiết lập cửa sổ console
            //Console.WindowWidth = 85;
            //Console.WindowHeight = 30;

            //Console.CursorVisible = false; // Ẩn con trỏ

            // Vẽ khung hàng rào
            for (int i = 0; i < Cons.ChieuRongHangRao; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, Cons.ChieuCaoHangRao - 1);
                Console.Write("#");
            }
            for (int i = 0; i < Cons.ChieuCaoHangRao; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(Cons.ChieuRongHangRao, i);
                Console.Write("#");
            }
        }
        public static void DrawMenu()
        {
            WindowStart();
            Console.SetCursorPosition(28, 7);
            Console.WriteLine("------------------------");
            Console.SetCursorPosition(28, 8);
            Console.WriteLine("|      SNAKE GAME      |");
            Console.SetCursorPosition(28, 9);
            Console.WriteLine("------------------------");
            Console.SetCursorPosition(28, 10);
            Console.ResetColor();

            Console.WriteLine("1. Start game");
            Console.SetCursorPosition(28, 11);
            Console.WriteLine("2. Guide");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine("3. Sound");
            Console.SetCursorPosition(28, 13);
            Console.WriteLine("Press 4 or ESC to exit");
            Console.SetCursorPosition(28, 14);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter number to select: ");

            Console.ResetColor();
        }
    }
}

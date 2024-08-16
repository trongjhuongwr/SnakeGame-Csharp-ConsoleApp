using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            // Thiết lập cửa sổ console
            Console.WindowWidth = 85;
            Console.WindowHeight = 30;

            Console.CursorVisible = false; // Ẩn con trỏ

            // Vẽ menu chính
            Window.DrawMenu();

            // Lấy lựa chọn của người chơi
            char choice = Console.ReadKey().KeyChar;

            // Xử lý lựa chọn
            Run.RunMenu(choice);

        }
    }
}

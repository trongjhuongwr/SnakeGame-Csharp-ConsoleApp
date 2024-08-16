using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Control
    {
        // Phương thức nhận phím nhập từ người chơi
        public static void GenerateControl()
        {
            // Nếu có phím được nhấn
            if (Console.KeyAvailable)
            {
                // Lấy phím nhấn
                ConsoleKey key = Console.ReadKey(true).Key;

                // Đổi hướng di chuyển của rắn tương ứng với phím nhấn
                // Chỉ đổi hướng nếu phím nhấn không trùng với hướng hiện tại hoặc hướng ngược lại
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (Cons.DirectMove != 0 && Cons.DirectMove != 1)
                            Cons.DirectMove = 0;
                        break;

                    case ConsoleKey.DownArrow:
                        if (Cons.DirectMove != 0 && Cons.DirectMove != 1)
                            Cons.DirectMove = 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (Cons.DirectMove != 2 && Cons.DirectMove != 3)
                            Cons.DirectMove = 2;
                        break;

                    case ConsoleKey.RightArrow:
                        if (Cons.DirectMove != 2 && Cons.DirectMove != 3)
                            Cons.DirectMove = 3;
                        break;
                }
            }
        }
    }
}

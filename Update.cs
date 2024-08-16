using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    internal class Update
    {
        // Cập nhật trạng thái của con rắn
        public static void UpdateInformation()
        {
            // Cập nhật tọa độ của đầu rắn theo hướng di chuyển
            // Sử dụng một câu lệnh switch-case để kiểm tra hướng di chuyển và tăng hoặc giảm tọa độ X hoặc Y tương ứng
            switch (Cons.DirectMove)
            {
                case 0:
                    Cons.HeadY--;
                    break;
                case 1:
                    Cons.HeadY++;
                    break;
                case 2:
                    Cons.HeadX--;
                    break;
                case 3:
                    Cons.HeadX++;
                    break;
            }

            // Đặt con trỏ ở vị trí cuối cùng của rắn và ghi một khoảng trắng để xóa ký tự rắn cũ
            Console.SetCursorPosition(DrawObject.snakeX[DrawObject.snakeX.Count - 1], DrawObject.snakeY[DrawObject.snakeY.Count - 1]);
            Console.Write(" ");

            // Kiểm tra xem đầu rắn có va chạm vào khung hàng rào không
            // Nếu có thì kết thúc trò chơi
            if (Cons.HeadX <= 0 || Cons.HeadX >= Cons.ChieuRongHangRao - 1 || Cons.HeadY <= 0 || Cons.HeadY >= Cons.ChieuCaoHangRao - 1)
            {
                Cons.EndGame = true;
                return;
            }

            // Kiểm tra xem đầu rắn có va chạm vào vật cản không
            // Nếu có thì kết thúc trò chơi
            if (
            ((Cons.HeadX >= 4 && Cons.HeadX <= 9) && Cons.HeadY == 5) ||
            ((Cons.HeadX >= 8 && Cons.HeadX <= 13) && Cons.HeadY == 19) ||
            ((Cons.HeadX >= 14 && Cons.HeadX <= 19) && Cons.HeadY == 10) ||
            ((Cons.HeadX >= 24 && Cons.HeadX <= 29) && Cons.HeadY == 15) ||
            ((Cons.HeadX >= 34 && Cons.HeadX <= 39) && Cons.HeadY == 20) ||
            ((Cons.HeadX >= 64 && Cons.HeadX <= 69) && Cons.HeadY == 7) ||
            ((Cons.HeadX >= 44 && Cons.HeadX <= 49) && Cons.HeadY == 14) ||
            ((Cons.HeadX >= 46 && Cons.HeadX <= 51) && Cons.HeadY == 3) ||
            ((Cons.HeadX >= 33 && Cons.HeadX <= 38) && Cons.HeadY == 6) ||
            ((Cons.HeadX >= 60 && Cons.HeadX <= 65) && Cons.HeadY == 20)
               )
            {
                Cons.EndGame = true;
                return;
            }

            // Kiểm tra xem đầu rắn có va chạm vào thân rắn không
            // Nếu có thì kết thúc trò chơi
            for (int i = 1; i < DrawObject.snakeX.Count; i++)
            {
                if (Cons.HeadX == DrawObject.snakeX[i] && Cons.HeadY == DrawObject.snakeY[i])
                {
                    Cons.EndGame = true;
                    return;
                }
            }

            // Kiểm tra xem đầu rắn có ăn tiền không
            // Nếu có thì tăng điểm số, tăng độ dài của rắn và tạo vị trí tiền mới
            if (Cons.HeadX == Cons.MoneyX && Cons.HeadY == Cons.MoneyY)
            {
                Cons.Score++;
                DrawObject.snakeX.Add(0);
                DrawObject.snakeY.Add(0);
                DrawObject.GenerateMoney();
            }

            // Cập nhật tọa độ của thân rắn theo đầu rắn
            // Bắt đầu từ phần cuối của rắn, gán tọa độ của mỗi phần bằng tọa độ của phần trước nó
            for (int i = DrawObject.snakeX.Count - 1; i > 0; i--)
            {
                DrawObject.snakeX[i] = DrawObject.snakeX[i - 1];
                DrawObject.snakeY[i] = DrawObject.snakeY[i - 1];
            }

            // Gán tọa độ của phần đầu của rắn bằng tọa độ mới của đầu rắn
            DrawObject.snakeX[0] = Cons.HeadX;
            DrawObject.snakeY[0] = Cons.HeadY;

            // Xóa con trỏ cũ
            Console.SetCursorPosition(DrawObject.snakeX[DrawObject.snakeX.Count - 1], DrawObject.snakeY[DrawObject.snakeY.Count - 1]);
            Console.Write(" ");

            // Vẽ con trỏ mới
            Console.SetCursorPosition(Cons.HeadX, Cons.HeadY);
            Console.Write(Cons.Snake);
        }
        public static void UpdateInformation(bool isBoosting)
        {
            // ...

            if (isBoosting)
            {
                // Tăng tốc độ di chuyển của rắn
                Cons.Speed = 50; // Ví dụ: tăng gấp đôi tốc độ
            }
            else
            {
                Cons.Speed = 100;
            }

            // ...
        }
    }
}

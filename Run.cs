using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SnakeGame
{
    internal class Run
    {
        public static void RunMenu(char selectNumber) 
        {
            switch (selectNumber)
            {
                case '1':
                    Console.Clear();
                    StartGame();
                    break;
                case '2':
                    Console.Clear();
                    Window.WindowStart();
                    Guide();
                    break;
                case '3':
                    Console.Clear();
                    
                    break;
                case '4':
                case '\u001b':
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            };
        }

        public static void StartGame()
        {
            Window.WindowStart();
            DrawObject.GenerateSnake();
            DrawObject.GenerateMoney();

            Playing();
            
            while (true)
            {
                Playing();

                Window.WindowStart();
                Console.SetCursorPosition(24, 16);
                Console.WriteLine("Bạn có muốn chơi lại không? (Y/N)");
                char choice = Console.ReadKey().KeyChar;
                if (char.ToUpper(choice) != 'y')
                {
                    break;
                }

                // Reset trò chơi
                Cons.EndGame = false;
                DrawObject.snakeX.Clear();
                DrawObject.snakeY.Clear();

                // Reset các biến khác...
                Console.Clear();

                // Khởi tạo lại trò chơi
                Window.WindowStart();
                DrawObject.GenerateSnake();
                DrawObject.GenerateMoney();
                Playing();
            }
        }
        
        public static void Playing()
        {
            //Sound();

            // Vòng lặp chính của trò chơi
            while (!Cons.EndGame)
            {
                // Vẽ màn hình và các đối tượng
                DrawObject.DrawObstacle();
                DrawObject.DrawMoney();
                DrawObject.DrawSnake();
                DrawObject.DrawScore();

                // Nhận phím nhập từ người chơi
                Control.GenerateControl();

                // Xử lý sự kiện tăng tốc độ nhấn giữ phím SPACE
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        Cons.IsBoosting = !Cons.IsBoosting;
                    }
                }
                // Cập nhật tốc độ
                // của rắn
                Update.UpdateInformation(Cons.IsBoosting);

                // Cập nhật trạng thái của con rắn
                Update.UpdateInformation();
                Thread.Sleep(Cons.Speed);
            }
            StopGame();

        }
        public static void StopGame()
        {
            // Kết thúc trò chơi
            Console.Clear();
            Console.SetCursorPosition(Cons.ChieuRongHangRao / 2 - 5, Cons.ChieuCaoHangRao / 2);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(Cons.ChieuRongHangRao / 2 - 9, Cons.ChieuCaoHangRao / 2 + 1);
            Console.WriteLine("Điểm của bạn là:" + Cons.Score + "\n");
        }

        //static SoundPlayer eatSound = new SoundPlayer("eat.wav");
        //static SoundPlayer gameOverSound = new SoundPlayer("gameover.wav");
        //public static void Sound()
        //{
        //    // Phát âm thanh khi ăn mồi
        //    if (Cons.HeadX == Cons.MoneyX && Cons.HeadY == Cons.MoneyY)
        //    {
        //        eatSound.Play();
        //    }

        //    // Phát âm thanh khi game over
        //    if (Cons.EndGame)
        //    {
        //        gameOverSound.Play();
        //    }
        //}

        public static void Guide()
        {
            Console.SetCursorPosition(22, 3);
            Console.WriteLine("Hướng dẫn chơi game Rắn Săn Tiền");
            Console.SetCursorPosition(30, 5);
            Console.WriteLine("------------------");
            Console.SetCursorPosition(4, 7);
            Console.WriteLine("Mục tiêu của trò chơi là điều khiển con rắn ăn càng nhiều tiền càng tốt.");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("Sử dụng các phím mũi tên để điều khiển con rắn.");
            Console.SetCursorPosition(19, 11);
            Console.WriteLine("Mỗi khi ăn được tiền, con rắn sẽ dài ra.");
            Console.SetCursorPosition(21, 13);
            Console.WriteLine("Tránh đụng vào tường hoặc thân mình.");
            Console.SetCursorPosition(24, 15);
            Console.WriteLine("Ấn ESC để thoát khỏi trò chơi.");
            Console.WriteLine();
            Console.SetCursorPosition(22, 22);
            Console.WriteLine("* Ấn phím SPACE để quay lại Menu *");
            
            char choice = Console.ReadKey().KeyChar;
            if (char.ToUpper(choice) != 'p')
            {
                Console.Clear();
                Window.WindowStart();
                Window.DrawMenu();
            }


        }
    }
}

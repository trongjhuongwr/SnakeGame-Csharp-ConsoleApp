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
                    
                    break;
                case '3':
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
                if (char.ToUpper(choice) != 'Y')
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

                // Cập nhật trạng thái của con rắn
                Update.UpdateInformation();
                Thread.Sleep(100);
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

        }
    }
}

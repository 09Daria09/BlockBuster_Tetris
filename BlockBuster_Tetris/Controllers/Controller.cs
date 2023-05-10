using BlockBuster_Tetris.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockBuster_Tetris.Controllers
{
    internal static class Controller
    {
        public static Block currentShape;
        public static int size;
        public static int[,] map = new int[20, 10];
        public static int linesRemoved;
        public static int score;
        public static int Interval;
        public static Image img_I = Image.FromFile("Turquoise.png");
        public static Image img_Z = Image.FromFile("Red.png");
        public static Image img_T = Image.FromFile("Violet.png");
        public static Image img_L = Image.FromFile("Green.png");
        public static Image img_J = Image.FromFile("Orange.png");
        public static Image img_Square = Image.FromFile("Blue.png");
        public static Image img_Z_ = Image.FromFile("Yellow.png");
        public static void ShowNextShape(Graphics e)
        {
            if (Settings.ThemeMult)
            {
                e.FillRectangle(Brushes.White, new Rectangle(977, 130, 150, 150));
            }
            else
            {
                e.FillRectangle(Brushes.Black, new Rectangle(977, 130, 150, 150));
            }

            for (int i = 0; i < currentShape.sizeNextMatrix; i++)
            {
                for (int j = 0; j < currentShape.sizeNextMatrix; j++)
                {
                    if (currentShape.nextMatrix[i, j] == 1)
                    {
                        e.DrawImage(img_I, new Rectangle(968 + j * (size) + 1, 135 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 2)
                    {
                        e.DrawImage(img_Z, new Rectangle(983 + j * (size) + 1, 149 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 3)
                    {
                        e.DrawImage(img_T, new Rectangle(1000 + j * (size) + 1, 140 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 4)
                    {
                        e.DrawImage(img_L, new Rectangle(1020 + j * (size) + 1, 150 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 5)
                    {
                        e.DrawImage(img_Square, new Rectangle(1018 + j * (size) + 1, 168 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 6)
                    {
                        e.DrawImage(img_Z_, new Rectangle(983 + j * (size) + 1,  149 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (currentShape.nextMatrix[i, j] == 7)
                    {
                        e.DrawImage(img_J, new Rectangle(980 + j * (size) + 1, 150 + i * (size) + 1, size - 1, size - 1));
                    }
                }
            }
        }

        public static void ClearMap()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        public static void DrawMap(Graphics e)
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - 10 * size) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - 20 * size) / 2;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                    {

                        e.DrawImage(img_I, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 2)
                    {
                        e.DrawImage(img_Z, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 3)
                    {
                        e.DrawImage(img_T, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 4)
                    {
                        e.DrawImage(img_L, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 5)
                    {
                        e.DrawImage(img_Square, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 6)
                    {
                        e.DrawImage(img_Z_, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 7)
                    {
                        e.DrawImage(img_J, new Rectangle(x + j * (size) + 1, y + i * (size) + 1, size - 1, size - 1));
                    }
                }
            }
        }

        public static void DrawGrid(Graphics g)
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - 10 * size) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - 20 * size) / 2;

            g.FillRectangle(Brushes.LightSlateGray, new Rectangle(x, y, 10 * size, 20 * size));

            for (int i = 0; i <= 20; i++)
            {
                g.DrawLine(Pens.Black, new Point(x, y + i * size), new Point(x + 10 * size, y + i * size));
            }
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, new Point(x + i * size, y), new Point(x + i * size, y + 20 * size));
            }
        }

        public static void SliceMap(Label label1, Label label2)
        {
            int count = 0;
            int curRemovedLines = 0;
            for (int i = 0; i < 20; i++)
            {
                count = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] != 0)
                        count++;
                }
                if (count == 10)
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < 10; o++)
                        {
                            map[k, o] = map[k - 1, o];
                        }
                    }
                }
            }
            for (int i = 0; i < curRemovedLines; i++)
            {
                score += 10 * (i + 1);
            }
            linesRemoved += curRemovedLines;

            if (linesRemoved % 5 == 0)
            {
                if (Interval > 60)
                    Interval -= 10;
            }

            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;
        }

        public static bool IsIntersects()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (j >= 0 && j <= 9)
                    {
                        if (map[i, j] != 0 && currentShape.matrix[i - currentShape.y, j - currentShape.x] == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public static void Merge()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        map[i, j] = currentShape.matrix[i - currentShape.y, j - currentShape.x];
                }
            }
        }

        public static bool Collide()
        {
            for (int i = currentShape.y + currentShape.sizeMatrix - 1; i >= currentShape.y; i--)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (i + 1 == 20)
                            return true;
                        if (map[i + 1, j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool CollideHor(int dir)
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (j + 1 * dir > 9 || j + 1 * dir < 0)
                            return true;

                        if (map[i, j + 1 * dir] != 0)
                        {
                            if (j - currentShape.x + 1 * dir >= currentShape.sizeMatrix || j - currentShape.x + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (currentShape.matrix[i - currentShape.y, j - currentShape.x + 1 * dir] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void ResetArea()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 20 && j < 10)
                    {
                        if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        {
                            map[i, j] = 0;
                        }
                    }
                }
            }
        }
    }
    
}

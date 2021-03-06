﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size;
        public Boolean ballRight, ballUp;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize, bool _ballRight, bool _ballUp)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
            ballRight = _ballRight;
            ballUp = _ballUp;

        }

        public void Move()
        { 
            //ball goes left/right
            if (ballRight == true)
            {
                x = x + xSpeed;
            }
            else
            {
                x = x - xSpeed;
            }

            // ball goes up/down
            if (ballUp == true)
            {
                y = y - ySpeed;
            }
            else
            {
                y = y + ySpeed;
            }
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                //ball changes up/down direction
                ballUp = !ballUp;
            }

            return blockRec.IntersectsWith(ballRec);         
        }

        public void PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                //ball hits paddle, goes up
                if (y + size >= p.y)
                {
                    ballUp = true;
                }

                if (pMovingLeft == true)
                {
                    ballRight = false;
                }
                else
                {
                    ballRight = true;
                }
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall, goes right
            if (x <= 1)
            {
                ballRight = true;
            }
            else if (x >= (UC.Width - size))
            {
                ballRight = false;
            }
            // Collision with top wall, goes down
            if (y <= 2)
            {
                ballUp = false;
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

        

    }
}

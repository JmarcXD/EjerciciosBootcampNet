﻿using System;

namespace EjerciciosBootcampNet
{
    public class SnakeApplication
    {
        public void SnakeV2Application()
        {

            //Comprueba
            TableSnake ts = new TableSnake();

            while (true)
            {

                ts.DrawTable();
                ts.InputKey();
                ts.Logic();
            }

            Console.Read();

        }


    }
}

﻿using GameEngine.GameElements.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameElements
{
    public class GameManager
    {
        public Player player { get; set; }

        public GameManager()
        {
            player = new Player(10, Application.WINDOW_WIDTH / 2, Application.WINDOW_HEIGHT - 100, 25, 25);
        }
    }
}

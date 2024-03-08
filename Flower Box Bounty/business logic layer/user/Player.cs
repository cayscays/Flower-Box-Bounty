/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamestateModule;

namespace UserModule
{
    public class Player: User
    {
        private GameState _gameState;
        public Player(string name, string password) : base(name, password) { }

        public Player(string name, string password, GameState gameState) : base(name, password) 
        {
            _gameState = gameState;
        }
    }
}

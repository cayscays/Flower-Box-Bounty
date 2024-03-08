/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ItemModule;

namespace NpcModule
{
    public class Npc : ICloneable
    {
        private Seed _receivedSeed = null;
        public string Name { get; protected set; }
        public string Id { get; protected set; }

        public Seed ReceivedSeed { get => _receivedSeed; }

        public Npc(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string ReceiveGift(ItemModule.IStoredItem item)
        {
            if (item is Seed)
            {
                _receivedSeed = (Seed)item;
            }
            else
            {
                _receivedSeed = null;
            }
            return $"{Name}: Thank you for the {item.ToString()} :)";
        }

        public object Clone()
        {
            return new Npc(Name, Id);
        }

        public override string ToString()
        {
            return $"{Name} {Id}";
        }

        /* Gift a seed to the player 
           If the last gift from the player was a seed:
            than gift the player a different seed.*/
        public Seed GiftSeed()
        {
            var result = Seed.GetRandomSeed();
            while ((_receivedSeed is not null) && (result == _receivedSeed))
            {
                result = Seed.GetRandomSeed();
            }
            return result;
        }



    }
}

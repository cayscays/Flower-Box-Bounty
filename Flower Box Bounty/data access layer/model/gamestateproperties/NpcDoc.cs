/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using ItemModule;
using NpcModule;

namespace Data.Models
{
    public class NpcDoc
    {
        public Seed ReceivedSeed { get; private set; }
        public string Name { get; private set; }
        public string Id { get; private set; }

        public NpcDoc(Npc npc)
        {
            ReceivedSeed = npc.ReceivedSeed;
            Name = npc.Name;
            Id = npc.Id;

        }
    }
}
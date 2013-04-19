﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface ILevel
    {
        List<ITank> Tanks { get; }
        List<IPhysicalObject> Objects { get; }
        List<Bullet> Bullets { get; }
        List<IArt> Arts { get; }
        void Update();
        IGameObject Collizion(IGameObject obj);
        void Load(int num);
        int Number { get; }
        bool EndCondition();
    }
}

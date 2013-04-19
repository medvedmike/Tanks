﻿using System;
using System.Collections.Generic;
using System.Threading;
using TanksInterfaces;

namespace Engine.Model
{
    public class DrawEventArgs : EventArgs
    {
        public List<ITank> Tanks;
        public List<IPhysicalObject> Objects;
        public List<Bullet> Bullets;
        public List<IArt> Arts;
        public DrawEventArgs(List<ITank> tanks, List<IPhysicalObject> objects, List<Bullet> bullets, List<IArt> arts)
        {
            Tanks = tanks;
            Objects = objects;
            Bullets = bullets;
            Arts = arts;
        }
    }

    public delegate void DrawEvent(object sender, DrawEventArgs e);

    public class Game
    {
        #region Singletone

        private Game()
        {
        }

        private static readonly Game _instance = new Game();
        public static Game Instance
        {
            get { return _instance; }
        }

        #endregion

        public event DrawEvent Draw;
        private void _draw()
        {
            if (Draw != null)
                Draw(this, new DrawEventArgs(_currentLevel.Tanks, _currentLevel.Objects, _currentLevel.Bullets, _currentLevel.Arts));
        }

        private System.Timers.Timer _timer;
        public void Initialize()
        {
            _timer = new System.Timers.Timer(28) {Enabled = false};
            _timer.Elapsed += timer_Elapsed;
            _currentLevel = new Level();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            Update();
            _draw();
            _timer.Start();
        }

        private ILevel _currentLevel;

        private void Update()
        {
            _currentLevel.Update();
        }

        public void Start()
        {
            _currentLevel = new Level();
            _currentLevel.Load(1);
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Continue()
        {
            _timer.Start();
        }
    }
}

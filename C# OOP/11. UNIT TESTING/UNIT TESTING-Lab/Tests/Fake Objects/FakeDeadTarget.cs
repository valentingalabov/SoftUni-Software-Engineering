﻿using Skeleton;

namespace Tests.Fake_Objects
{
    public class FakeDeadTarget : ITarget
    {
        public int Health => 0;

        public int GiveExperience() => 20;


        public bool IsDead() => true;
        

        public void TakeAttack(int attackPoints)
        {
        }
    }
}

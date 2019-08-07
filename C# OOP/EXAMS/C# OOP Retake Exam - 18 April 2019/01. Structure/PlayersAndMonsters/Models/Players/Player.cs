using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

using Validator = PlayersAndMonsters.Common.Validator;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;


        //Понеже класа ни е Aбстрактен използваме Protected конструктор!!!
        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Player's username cannot be null or an empty string. ");
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, "Player's health bonus cannot be less than zero. ");
                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, "Damage points cannot be less than zero.");

            this.Health = Math.Max(this.Health - damagePoints, 0);

            //int newHealth = this.Health - damagePoints;

            //if (newHealth<0)
            //{
            //    this.Health = 0;
            //}
            //else
            //{
            //    this.Health = newHealth;
            //}
        }
    }
}

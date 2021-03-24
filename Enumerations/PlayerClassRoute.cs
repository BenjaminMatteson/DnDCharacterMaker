using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterMaker.Enumerations;
namespace DnDCharacterMaker.Enumerations
{
    public sealed class PlayerClassRoute: TypeSafeEnum<string, PlayerClassRoute>
    {
        #region instance
        /// <summary>
        /// This is not publicly available
        /// </summary>
        /// <param name="representation">Database representation</param>
        /// <param name="description">Human-readable description</param>
        private PlayerClassRoute(string representation, string description)
        {
            Initialize(this, representation, description);
        }

        /// <summary>
        /// This is constructor for the defaultValue of the constructor
        /// </summary>
        /// <param name="representation"> Database representation </param>
        /// <param name="description">FriendlyName</param>
        /// <param name="index">Put it on the "Front" of the Enumeration</param>
        public PlayerClassRoute(string representation, string description, int index)
        {
            Index = index;
            Description = description;
            Value = representation;
            IsValid = false;
        }

        #endregion

        #region static

        static PlayerClassRoute()
        {
            //ensure the static constructors are initialized
        }

        /// <summary>
        /// Converts from a string representation to the appropriate Source.
        /// </summary>
        public static implicit operator PlayerClassRoute(string val)
        {
            return _staticLookupTable[val];
        }

        //values of enumeration
        public static readonly PlayerClassRoute Barbarian = new PlayerClassRoute("barbarian", "Barbarian");
        public static readonly PlayerClassRoute Bard = new PlayerClassRoute("bard", "Bard");
        public static readonly PlayerClassRoute Cleric = new PlayerClassRoute("cleric", "Cleric");
        public static readonly PlayerClassRoute Druid = new PlayerClassRoute("druid", "Druid");
        public static readonly PlayerClassRoute Fighter = new PlayerClassRoute("fighter", "Fighter");
        public static readonly PlayerClassRoute Monk = new PlayerClassRoute("monk", "Monk");
        public static readonly PlayerClassRoute Paladin = new PlayerClassRoute("paladin", "Paladin");
        public static readonly PlayerClassRoute Ranger = new PlayerClassRoute("ranger", "Ranger");
        public static readonly PlayerClassRoute Rogue = new PlayerClassRoute("rogue", "Rogue");
        public static readonly PlayerClassRoute Sorcerer = new PlayerClassRoute("sorcerer", "Sorcerer");
        public static readonly PlayerClassRoute Warlock = new PlayerClassRoute("warlock", "Warlock");
        public static readonly PlayerClassRoute Wizard = new PlayerClassRoute("wizard", "Wizard");

        #endregion
    }
}

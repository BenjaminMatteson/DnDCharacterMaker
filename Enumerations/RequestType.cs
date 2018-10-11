using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterMaker.Enumerations;
namespace DnDCharacterMaker.Enumerations
{
    public sealed class RequestType: TypeSafeEnum<string, RequestType>
    {
        #region instance
        /// <summary>
        /// This is not publicly available
        /// </summary>
        /// <param name="representation">Database representation</param>
        /// <param name="description">Human-readable description</param>
        private RequestType(string representation, string description)
        {
            Initialize(this, representation, description);
        }

        /// <summary>
        /// This is constructor for the defaultValue of the constructor
        /// </summary>
        /// <param name="representation"> Database representation </param>
        /// <param name="description">FriendlyName</param>
        /// <param name="index">Put it on the "Front" of the Enumeration</param>
        public RequestType(string representation, string description, int index)
        {
            Index = index;
            Description = description;
            Value = representation;
            IsValid = false;
        }

        #endregion

        #region static

        static RequestType()
        {
            //ensure the static constructors are initialized
        }

        /// <summary>
        /// Converts from a string representation to the appropriate Source.
        /// </summary>
        public static implicit operator RequestType(string val)
        {
            return _staticLookupTable[val];
        }

        //public static bool? GetFilterValue(TypeSafeEnum<string, RequestType> value)
        //{
        //    return !value.IsValid ? (bool?)null : Yes.Equals(value);
        //}

        //used for labels in Filter Controls
        public static readonly string LabelName = "Bid Board";

        //values of enumeration
        // public static readonly IsBidBoard Any = new IsBidBoard(-1, "Any", -1);
        // public static readonly IsBidBoard No = new IsBidBoard(0, "No");
        // public static readonly IsBidBoard Yes = new IsBidBoard(1, "Yes");

        #endregion
    }
}

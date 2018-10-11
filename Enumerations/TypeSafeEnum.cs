using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterMaker.Enumerations
{

    /// <summary>
    /// Type Safe Enum classes inherit from this.
    /// </summary>
    /// <typeparam name = "T">any type</typeparam>
    /// <typeparam name = "TParent">The parent class passed as a template</typeparam>
    [DebuggerDisplay("{Value}, {Description}")]
    [DataContract]
    public abstract class TypeSafeEnum<T, TParent>
        : IComparable<TParent>, IEquatable<TParent>, ITypeSafeEnum, IComparable
        where TParent : TypeSafeEnum<T, TParent>
    {
        #region static

        static TypeSafeEnum()
        {
            ForceInitializationOfStaticMembersOfChildClasses();
        }

        /// <summary>
        /// Enum representation, Enum index
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected static readonly IDictionary<T, TParent> _staticLookupTable = new Dictionary<T, TParent>();
        private static int Register(T val, TParent parent)
        {
            int result = _staticLookupTable.Count;
            _staticLookupTable[val] = parent;
            return result;
        }

        public static implicit operator T(TypeSafeEnum<T, TParent> val)
        {
            return val.Value;
        }

        /// <summary>
        /// This is to access the internal enum list
        /// </summary>
        public static ICollection<TParent> Contents
        {
            get { return _staticLookupTable.Values; }
        }

        public static bool IsDefined(T value)
        {
            return _staticLookupTable.ContainsKey(value);
        }

        private static void ForceInitializationOfStaticMembersOfChildClasses()
        {
            if (_staticLookupTable.Count != 0) return;

            /* HACK: Work around the fact that accessing a static member of a base class
             * doesn't trigger the initialization of static members of child classes. This
             * causes issues when a static member of this class needs to access _staticLookUpTable
             * which isn't initialized until the first time a static member of the child class
             * is accessed. */
            var field = typeof(TParent).GetRuntimeFields().FirstOrDefault(f => f.IsPublic && f.IsStatic && f.FieldType == typeof(TParent));
            if (field != null) field.GetValue(null);
        }

        #endregion

        #region instance
        /// <summary>
        /// This is the enum order index.
        /// </summary>
        public int Index { get; protected set; }
        /// <summary>
        /// This is the value as seen in the DB.
        /// </summary>
        [DataMember]
        public T Value { get; protected set; }
        /// <summary>
        /// This should be human readable, suitable for being shown in the application.
        /// </summary>
        [DataMember]
        public string Description { get; protected set; }
        /// <summary>
        /// This should not be publicly available
        /// </summary>
        // ReSharper disable once EmptyConstructor
        protected TypeSafeEnum() { }
        /// <summary>
        /// Registers this ParentT instance as a new static variable. Called from the parent's private constructor
        /// </summary>
        /// <param name="constVal"></param>
        /// <param name="parentVal"></param>
        /// <param name="desc"></param>
        protected void Initialize(TParent parentVal, T constVal, string desc)
        {
            Value = constVal;
            Description = desc;
            Index = Register(constVal, parentVal);
        }
        /// <summary>
        /// returns <c>Description</c>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        /// <summary>
        /// Compares Index
        /// </summary>
        public int CompareTo(TParent item)
        {
            if (item == null) return 1;
            return Index.CompareTo(item.Index);
        }

        public bool Equals(TParent item)
        {
            return CompareTo(item) == 0;
        }
        /// <summary>
        /// Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return CompareToForEquality(obj) == 0;
        }

        /// <summary>
        /// CompareTo used in junction with the Equals Override
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int CompareToForEquality(object obj)
        {
            var otherPt = obj as TParent;
            if (otherPt != null)
            {
                return CompareTo(otherPt);
            }
            return 1;
        }

        /// <summary>
        /// CompareTo used to see if the TypeSafeEnums are the same based on Description
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            var other2 = obj as TypeSafeEnum<T, TParent>;
            return other2 == null
                           ? 1
                           : string.Compare(Description, other2.Description, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Stops a warning about overriding equals without overriding hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        #endregion

        #region ITypeSafeEnum

        private bool _isValid = true;

        public virtual bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        #endregion
    }
}


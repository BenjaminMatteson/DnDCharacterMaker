using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterMaker.Enumerations
{
    public interface ITypeSafeEnum
    {
        bool IsValid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathCombo.Attributes
{
    /// <summary> Attribute designating Potion combos. </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class PotionAttribute : Attribute
    {
    }
}

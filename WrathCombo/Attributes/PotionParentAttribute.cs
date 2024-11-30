using System;
using WrathCombo.Combos;

namespace WrathCombo.Attributes
{
    /// <summary> Attribute documenting required combo relationships. </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class PotionParentAttribute : Attribute
    {
        /// <summary> Initializes a new instance of the <see cref="PotionParentAttribute"/> class. </summary>
        /// <param name="parentPresets"> Presets that require the given combo to be enabled. </param>
        internal PotionParentAttribute(params CustomComboPreset[] parentPresets) => ParentPresets = parentPresets;

        /// <summary> Gets the display name. </summary>
        public CustomComboPreset[] ParentPresets { get; }
    }
}

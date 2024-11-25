using WrathCombo.CustomComboNS.Functions;

namespace WrathCombo.Combos.PvE;

internal partial class ALL
{
    internal static class Config
    {
        //Config goes here
        public static UserFloat
            All_Custom_Potion_Time1 = new("All_Custom_Potion_Time1", 365),
            All_Custom_Potion_Time2 = new("All_Custom_Potion_Time2", 710),
            All_Custom_Potion_Time3 = new("All_Custom_Potion_Time3", 1080),
            All_Custom_Potion_Time4 = new("All_Custom_Potion_Time4", 1475),
            All_Custom_Potion_Time5 = new("All_Custom_Potion_Time5", 1895);

        internal static void Draw(CustomComboPreset preset)
        {
            //switch (preset)
            //{
            //    //Presets
            //}
        }
    }
}

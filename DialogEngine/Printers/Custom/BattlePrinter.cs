using System.Collections.Generic;

namespace DialogEngine.Printers.Custom
{
    class BattlePrinter : CustomPrinter
    {
        const int DAMAGE_TAKEN_TEXT = 1;
        const int DAMAGE_DEALT_TEXT = 2;
        const int DAMAGE_DEALT_MAGIC_TEXT = 3;

        public BattlePrinter(Queue<string> lines) : base(lines)
        {
        }

        public string GetDamageTaken(string[] parameters)
        {
            //string formatStr = GetDialogLine(DAMAGE_TAKEN_TEXT);
            return GetDialog(GetDialogLine(DAMAGE_TAKEN_TEXT), parameters);
        }

        public string GetDamageDealt(string[] parameters)
        {
            return GetDialog(GetDialogLine(DAMAGE_DEALT_TEXT), parameters);
        }

        public string GetMagicDamageDealt(string[] parameters)
        {
            return GetDialog(GetDialogLine(DAMAGE_DEALT_MAGIC_TEXT), parameters);
        }

        private string GetDialog(string fmt, string[] parameters)
        {
            return string.Format(fmt, parameters);
        }
    }
}

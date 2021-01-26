using CommandSystem;
using Exiled.Events.EventArgs;
using LightContainmentZoneDecontamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioControl_EXILED2.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Decontamination : ICommand
    {
        static bool WillDecont;
        public string Command { get; set; } = "Decont";

        public string[] Aliases { get; set; } = { };

        public string Description { get; set; } = "Disable or enable decontamination by doing 0 or 1 for disabled or enabled.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.At(0) != "")
            {
                if (arguments.At(0) == "0")
                {
                    WillDecont = true;
                    response = "Decontamination is now disabled!";
                    return true;
                }
                else if (arguments.At(0) == "1")
                {
                    WillDecont = false;
                    response = "Decontamination is now enabled!";
                    return true;
                }
                else
                {
                    response = "invalid argument. please input 0 for disabled or 1 for enabled.";
                    return false;
                }
            }
            else
            {
                response = "please input 0 for disabled or 1 for enabled.";
                return false;
            }
        }

        internal static void OnDecont(DecontaminatingEventArgs obj)
        {
            obj.IsAllowed = WillDecont;
        }
    }
}

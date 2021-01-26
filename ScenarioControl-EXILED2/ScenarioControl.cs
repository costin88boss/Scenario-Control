using Exiled.API.Features;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Map = Exiled.Events.Handlers.Map;

namespace ScenarioControl_EXILED2
{
    public class ScenarioControl : Plugin<Config>
    {
        public Harmony Harmony { get; set; }
        private int _PatchesThing;

        public override void OnDisabled()
        {
            Harmony.UnpatchAll();
        }
        public override void OnEnabled()
        {
            try
            {
                Harmony = new Harmony($"ScenarioControl{++_PatchesThing}");

                var LastDebugThing = Harmony.DEBUG;
                Harmony.DEBUG = true;

                Harmony.PatchAll();
            }
            catch(Exception e)
            {
                Log.Error("An error has occured: " + e);
            }
        }
        public void Register()
        {
            Map.Decontaminating += ScenarioControl_EXILED2.Commands.Decontamination.OnDecont;
        }
        public void UnRegister()
        {

        }
    }
}

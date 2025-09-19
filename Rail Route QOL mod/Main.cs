using System.Threading.Tasks;
using Game.Mod;
using HarmonyLib;
using Utils;

namespace Rail_Route_QOL_mod
{
    public class Main : AbstractMod
    {
        private const string ID = "mod.Turtle.RailRouteQolMod";
        public override CachedLocalizedString Title => "Rail Route QOL mod";
        public override CachedLocalizedString Description => "A mod that changes some things to improve the gameplay experience.";

        private readonly Harmony _harmony = new Harmony(ID);

        public override async Task OnEnable()
        {
            _harmony.PatchAll();
            await Task.Yield();
        }

        public override async Task OnDisable()
        {
            _harmony.UnpatchAll(ID);
            await Task.Yield();
        }
    }
}
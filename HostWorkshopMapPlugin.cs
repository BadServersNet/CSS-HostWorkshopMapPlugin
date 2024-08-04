using System.Reflection;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;

namespace MapChooserPlugin;

public class MapChooserPlugin : BasePlugin
{
  public override string ModuleName => "HostWorkshopMapPlugin";
  public override string ModuleVersion =>
    $"v{Assembly.GetExecutingAssembly().GetName().Version ??
    throw new Exception("Version not found.")}";

  [ConsoleCommand("css_hostmap", "Change the map to a workshop map.")]
  [RequiresPermissions("@css/changemap")]
  [CommandHelper(minArgs: 1, usage: "[id]", whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
  public void OnHostWorkshopMapCommand(CCSPlayerController? player, CommandInfo commandInfo)
  {
    var id = commandInfo.GetArg(1);

    Server.ExecuteCommand($"host_workshop_map {id}");
  }
}

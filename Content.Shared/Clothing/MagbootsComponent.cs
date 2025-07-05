using Content.Shared.Alert;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Audio; // LOP edit

namespace Content.Shared.Clothing;

[RegisterComponent, NetworkedComponent]
[Access(typeof(SharedMagbootsSystem))]
public sealed partial class MagbootsComponent : Component
{
    [DataField]
    public ProtoId<AlertPrototype> MagbootsAlert = "Magboots";

    /// <summary>
    /// If true, the user must be standing on a grid or planet map to experience the weightlessness-canceling effect
    /// </summary>
    [DataField]
    public bool RequiresGrid = true;

    /// <summary>
    /// Slot the clothing has to be worn in to work.
    /// </summary>
    [DataField]
    public string Slot = "shoes";

    // LOP edit start
    [DataField]
    public SoundSpecifier SoundOn = new SoundPathSpecifier("/Audio/_NewParadise/SoundUse/magboots_on.ogg");

    [DataField]
    public SoundSpecifier SoundOff = new SoundPathSpecifier("/Audio/_NewParadise/SoundUse/magboots_off.ogg");
    // LOP edit end
}

using Robust.Shared.GameStates;

namespace Content.Shared._EstacaoPirata;

/// <summary>
///     An item with this component is always hidden in the strip menu, regardless of other circumstances.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class StripMenuHiddenComponent : Component;

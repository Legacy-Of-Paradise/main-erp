namespace Content.Server._ADT.Emp;

[RegisterComponent]
public sealed partial class EmpContainerProtectionComponent : Component
{
    public EntityUid? BatteryUid;
    [DataField]
    public string ContainerId = "cell_slot";
}

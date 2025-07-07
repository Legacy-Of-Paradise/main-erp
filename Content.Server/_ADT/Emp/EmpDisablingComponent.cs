namespace Content.Server._ADT.EMPProtaction;

[RegisterComponent]
public sealed partial class EmpDisablingComponent : Component
{
    [DataField]
    public TimeSpan DisablingTime;
}

using Content.Server.Emp;

namespace Content.Server._ADT.EMPProtaction;

public sealed class EmpDisablingSystem : EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<EmpDisablingComponent, EmpPulseEvent>(OnEmpPulse);
    }
    private void OnEmpPulse(EntityUid uid, EmpDisablingComponent component, ref EmpPulseEvent args)
    {
        args.Disabled = true;
        args.Duration = component.DisablingTime;
    }
}

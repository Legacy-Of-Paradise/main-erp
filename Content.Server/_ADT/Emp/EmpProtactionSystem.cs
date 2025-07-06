using Content.Shared.Containers.ItemSlots;

namespace Content.Server._ADT.Emp;

public sealed class EmpProtectionSystem : EntitySystem
{
    [Dependency] private readonly ItemSlotsSystem _slot = default!;
    public override void Initialize()
    {
        SubscribeLocalEvent<EmpContainerProtectionComponent, ItemSlotInsertAttemptEvent>(OnInserted);
        SubscribeLocalEvent<EmpContainerProtectionComponent, ItemSlotEjectedEvent>(OnEjected);
        SubscribeLocalEvent<EmpContainerProtectionComponent, ComponentShutdown>(OnShutdown);
        SubscribeLocalEvent<EmpContainerProtectionComponent, MapInitEvent>(OnInit);
    }
    private void OnInserted(EntityUid uid, EmpContainerProtectionComponent component, ref ItemSlotInsertAttemptEvent args)
    {
        if (args.Cancelled)
            return;
        EnsureComp<Shared._ADT.EmpProtection.EmpProtectionComponent>(args.Item);
        component.BatteryUid = args.Item;
    }
    private void OnEjected(EntityUid uid, EmpContainerProtectionComponent component, ref ItemSlotEjectedEvent args)
    {
        if (args.Cancelled)
            return;
        RemComp<Shared._ADT.EmpProtection.EmpProtectionComponent>(args.Item);
        component.BatteryUid = null;
    }
    private void OnShutdown(EntityUid uid, EmpContainerProtectionComponent component, ComponentShutdown args)
    {
        if (component.BatteryUid == null)
            return;
        RemComp<Shared._ADT.EmpProtection.EmpProtectionComponent>(component.BatteryUid.Value);
    }
    private void OnInit(EntityUid uid, EmpContainerProtectionComponent component, MapInitEvent args)
    {
        var battery = _slot.GetItemOrNull(uid, component.ContainerId);
        if (battery == null)
            return;
        EnsureComp<Shared._ADT.EmpProtection.EmpProtectionComponent>(battery.Value);
    }
}

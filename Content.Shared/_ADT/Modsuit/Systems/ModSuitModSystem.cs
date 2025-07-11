using Content.Shared.Interaction;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects; // LOP edit
using Robust.Shared.IoC; // LOP edit
using Robust.Shared.Timing;

namespace Content.Shared._ADT.ModSuits;

public sealed class SharedModSuitModSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly SharedContainerSystem _container = default!;
    [Dependency] private readonly ModSuitSystem _mod = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ModSuitModComponent, BeforeRangedInteractEvent>(OnAfterInteract);
        SubscribeLocalEvent<ModSuitModComponent, ModModulesUiStateReadyEvent>(OnGetUIState);

        SubscribeLocalEvent<ModSuitComponent, ModModuleRemoveMessage>(OnEject);
        SubscribeLocalEvent<ModSuitComponent, ModModulActivateMessage>(OnActivate);
        SubscribeLocalEvent<ModSuitComponent, ModModulDeactivateMessage>(OnDeactivate);
    }
    private void OnEject(EntityUid uid, ModSuitComponent component, ModModuleRemoveMessage args)
    {
        if (!_timing.IsFirstTimePredicted)
            return;
        var module = GetEntity(args.Module);
        if (!TryComp<ModSuitModComponent>(module, out var mod))
            return;
        if (mod.Ejecttick + TimeSpan.FromSeconds(5) >= _timing.CurTime)
            return;
        mod.Ejecttick = _timing.CurTime;
        component.CurrentComplexity -= mod.Complexity;
        if (mod.Active)
            DeactivateModule(uid, module, mod, component);
        _container.Remove(module, component.ModuleContainer);
        Dirty(module, mod);
        Dirty(uid, component);
        _mod.UpdateUserInterface(uid, component);
    }
    private void OnActivate(EntityUid uid, ModSuitComponent component, ModModulActivateMessage args)
    {
        var module = GetEntity(args.Module);
        if (!TryComp<ModSuitModComponent>(module, out var mod))
            return;

        ActivateModule(uid, module, mod, component);
        Dirty(module, mod);
        Dirty(uid, component);
        _mod.UpdateUserInterface(uid, component);
    }
    private void OnDeactivate(EntityUid uid, ModSuitComponent component, ModModulDeactivateMessage args)
    {
        if (!_timing.IsFirstTimePredicted)
            return;
        var module = GetEntity(args.Module);
        if (!TryComp<ModSuitModComponent>(module, out var mod))
            return;

        DeactivateModule(uid, module, mod, component);

        Dirty(module, mod);
        Dirty(uid, component);
        _mod.UpdateUserInterface(uid, component);
    }
    private void OnAfterInteract(EntityUid uid, ModSuitModComponent component, ref BeforeRangedInteractEvent args)
    {
        if (!_timing.IsFirstTimePredicted)
            return;
        if (!TryComp<ModSuitComponent>(args.Target, out var modsuit))
            return;
        if (modsuit.CurrentComplexity + component.Complexity > modsuit.MaxComplexity)
            return;
        _container.Insert(uid, modsuit.ModuleContainer);
        modsuit.CurrentComplexity += component.Complexity;
        if (component.IsInstantlyActive)
            ActivateModule(args.Target.Value, uid, component, modsuit);
        Dirty(uid, component);
        Dirty(args.Target.Value, modsuit);
        _mod.UpdateUserInterface(args.Target.Value, modsuit);
    }
    private void OnGetUIState(EntityUid uid, ModSuitModComponent component, ModModulesUiStateReadyEvent args)
    {
        args.States.Add(GetNetEntity(uid), null);
    }
    public bool ActivateModule(EntityUid modSuit, EntityUid module, ModSuitModComponent component, ModSuitComponent modcomp)
    {
        var attachedClothings = modcomp.ClothingUids;

        if (component.Slots.Contains("MODcore"))
        {
            foreach (var compEntry in component.Components)
            {
                if (!EntityManager.HasComponent(modSuit, compEntry.Value.Component.GetType()))
                {
                    // LOP edit start
                    var newComponent = (Component)IoCManager.Resolve<IComponentFactory>().GetComponent(compEntry.Value.Component.GetType());
                    newComponent.Owner = modSuit;
                    EntityManager.AddComponent(modSuit, newComponent);
                    // LOP edit end
                }
            }
        }

        component.Active = true;

        foreach (var attached in attachedClothings)
        {
            if (!component.Slots.Contains(attached.Value))
                continue;

            foreach (var compEntry in component.Components)
            {
                if (!EntityManager.HasComponent(attached.Key, compEntry.Value.Component.GetType()))
                {
                    // LOP edit start
                    var newComponent = (Component)IoCManager.Resolve<IComponentFactory>().GetComponent(compEntry.Value.Component.GetType());
                    newComponent.Owner = attached.Key;
                    EntityManager.AddComponent(attached.Key, newComponent);
                    // LOP edit end
                }
            }

            if (component.RemoveComponents != null)
            {
                foreach (var compEntry in component.RemoveComponents)
                {
                    if (EntityManager.HasComponent(attached.Key, compEntry.Value.Component.GetType()))
                        EntityManager.RemoveComponent(attached.Key, compEntry.Value.Component.GetType());
                }
            }
        }

        Dirty(module, component);
        Dirty(modSuit, modcomp);
        Timer.Spawn(1, () => _mod.UpdateUserInterface(modSuit, modcomp));
        return true;
    }

    public bool DeactivateModule(EntityUid modSuit, EntityUid module, ModSuitModComponent component, ModSuitComponent modcomp)
    {
        var attachedClothings = modcomp.ClothingUids;

        if (component.Slots.Contains("MODcore"))
        {
            foreach (var compEntry in component.Components)
            {
                if (EntityManager.HasComponent(modSuit, compEntry.Value.Component.GetType()))
                    EntityManager.RemoveComponent(modSuit, compEntry.Value.Component.GetType());
            }
        }

        foreach (var attached in attachedClothings)
        {
            if (!component.Slots.Contains(attached.Value))
                continue;

            foreach (var compEntry in component.Components)
            {
                if (EntityManager.HasComponent(attached.Key, compEntry.Value.Component.GetType()))
                    EntityManager.RemoveComponent(attached.Key, compEntry.Value.Component.GetType());
            }

            if (component.RemoveComponents != null)
            {
                foreach (var compEntry in component.RemoveComponents)
                {
                    if (!EntityManager.HasComponent(attached.Key, compEntry.Value.Component.GetType()))
                        EntityManager.AddComponent(attached.Key, compEntry.Value.Component);
                }
            }
        }

        component.Active = false;
        Dirty(module, component);
        Dirty(modSuit, modcomp);
        Timer.Spawn(1, () => _mod.UpdateUserInterface(modSuit, modcomp));
        return true;
    }
}

﻿using System.Collections.Generic;
using Verse;

namespace CustomPrisonerInteractions;

public class ExtraInteractionsTracker : MapComponent
{
    private Dictionary<Pawn, CustomPrisonerInteractions.ExtraMode> extraInteractions =
        new Dictionary<Pawn, CustomPrisonerInteractions.ExtraMode>();

    private List<Pawn> extraInteractionsKeys;
    private List<CustomPrisonerInteractions.ExtraMode> extraInteractionsValues;

    public ExtraInteractionsTracker(Map map) : base(map)
    {
    }

    public CustomPrisonerInteractions.ExtraMode this[Pawn prisoner]
    {
        get => extraInteractions[prisoner];
        set => extraInteractions[prisoner] = value;
    }

    public bool Has(Pawn prisoner)
    {
        return extraInteractions.ContainsKey(prisoner);
    }

    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_Collections.Look(ref extraInteractions, "ExtraInteractions", LookMode.Reference, LookMode.Value,
            ref extraInteractionsKeys, ref extraInteractionsValues);
    }
}
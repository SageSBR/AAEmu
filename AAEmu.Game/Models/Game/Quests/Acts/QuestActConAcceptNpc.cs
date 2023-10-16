﻿using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.NPChar;
using AAEmu.Game.Models.Game.Quests.Static;
using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts;

public class QuestActConAcceptNpc : QuestActTemplate
{
    public uint NpcId { get; set; }

    public override bool Use(ICharacter character, Quest quest, int objective)
    {
        Logger.Debug("QuestActConAcceptNpc");

        if (character.CurrentTarget is null or not Npc)
            return false;

        quest.QuestAcceptorType = QuestAcceptorType.Npc;
        quest.AcceptorType = NpcId;

        // Current target is the expected?
        return character.CurrentTarget.TemplateId == NpcId;
    }
}

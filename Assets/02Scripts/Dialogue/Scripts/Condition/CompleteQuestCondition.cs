using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/AcceptionCondition/CompleteQuestCondition", fileName = "CompleteQuestCondition")]
    public class CompleteQuestCondition : DialogueAcceptionCondition
    {

        [SerializeField] Quest quest;
        public override bool IsPass(DialogueGraph dialogue)
        {
            Quest realQuest = Access.QuestM.CompletedQuests.Find(x => x.ID == quest.ID);
            return realQuest != null && realQuest.IsComplete;
        }

    }
}

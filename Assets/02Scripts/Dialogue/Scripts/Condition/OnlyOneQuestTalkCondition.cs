using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/AcceptionCondition/OnlyOneQuestTalkCondition", fileName = "OnlyOneQuestTalkCondition")]
    public class OnlyOneQuestTalkCondition : DialogueAcceptionCondition {

        [SerializeField] Quest quest;
        public override bool IsPass(DialogueGraph dialogue) {
            Quest realQuest = Access.QuestM.CompletedQuests.Find(x => x.ID == quest.ID);
            return realQuest == null;
        }

    }
}

using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/AcceptionCondition/CompleteQuestCondition", fileName = "CompleteQuestCondition")]
    public class CompleteQuestCondition : DialogueAcceptionCondition {

        [SerializeField] Quest quest;
        public override bool IsPass(DialogueGraph dialogue) {
            return quest.;
        }

    }
}

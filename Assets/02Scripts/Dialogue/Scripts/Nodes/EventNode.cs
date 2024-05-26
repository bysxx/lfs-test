using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace Dialogue {
	public class EventNode : DialogueBaseNode {

		public string eventName;
		public UnityEvent trigger;

		public override void Trigger() {
			trigger?.Invoke();
        }
	}
}
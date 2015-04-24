using Quark.Targeting;
using UnityEngine;
using Quark;
using Quark.Utilities;

namespace Assets.QuarkDefault.TargetMacros
{
    class CharacterClick : TargetMacro
    {
		public override void Run ()
		{
			Messenger.AddListener ("Update", OnUpdate);
		}
		
		void OnUpdate()
		{
			if (Input.GetMouseButton (0)) {
				Messenger.RemoveListener("Update", OnUpdate);

				Character selected;
				if ((selected = RunRaycast()) == null)
					OnTargetingFail(TargetingError.NotFound);
				else
				{
					OnTargetSelected(selected);
					OnTargetingSuccess();
				}
			}
		}
		
		Character RunRaycast()
		{
			Character HoveringCharacter = null;
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
				if (hit.collider.GetComponent<Character>() != null)
					HoveringCharacter = hit.collider.GetComponent<Character>();

			return HoveringCharacter;
		}
		
    }
}

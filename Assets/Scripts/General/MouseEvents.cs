using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour 
{
	private GameObject hitObject;
	private GameObject lastHitObject;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		MouseUpdate ();
	}

	private void MouseUpdate()
	{
		RaycastHit hit = new RaycastHit();
		
		Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit))
		{
			GameObject hitObject = hit.transform.gameObject;
			
			if (Input.GetMouseButtonDown(0))
			{
				lastHitObject = hitObject;
				hitObject.gameObject.SendMessage("OnPointerDown", new Vector2(Input.mousePosition.x, Input.mousePosition.y), SendMessageOptions.DontRequireReceiver);
			}

			if (Input.GetMouseButtonUp(0))
			{
				if (lastHitObject == hitObject)
				{
					hitObject.gameObject.SendMessage("OnPointerUpAsButton", SendMessageOptions.DontRequireReceiver);
				}
				
				hitObject.gameObject.SendMessage("OnPointerUp", new Vector2(Input.mousePosition.x, Input.mousePosition.y), SendMessageOptions.DontRequireReceiver);
				lastHitObject = null;
			}
		}
	}
}
















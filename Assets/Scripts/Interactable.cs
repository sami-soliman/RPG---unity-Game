using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour {

	public float radius = 1f;
    public Transform interactionTransform;

    bool hasInteracted = false;

    bool isFocus = false;
    Transform player;

    public virtual void Interact()
    {
        // this is meant to be overwriiten
        //Debug.Log("interacting with " + transform);
    }

    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance<=radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

	void OnDrawGizmosSelected ()
	{
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}

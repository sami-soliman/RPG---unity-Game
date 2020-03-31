using UnityEngine;
using UnityEngine.EventSystems;

/* Controls the player. Here we chose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;      // The ground

    PlayerMotor motor;      // Reference to our motor
    Camera cam;             // Reference to our camera

    // Get references
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // If we press left mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot out a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If we hit
            if (Physics.Raycast(ray, out hit, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
                
            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            // Shoot out a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }

            }

        }

    }

    private void SetFocus(Interactable newFocus)
    {
        if( newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

  
}


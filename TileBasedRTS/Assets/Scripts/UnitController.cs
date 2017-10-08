using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class UnitController : MonoBehaviour {

    public GameObject selectedObject;
    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    Renderer rend;
    public bool isSelected = false;

	// Use this for initialization
	void Start () {
       
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000, movementMask))
            {
                RemoveFocus();
                GameObject hitObject = hit.transform.root.gameObject;
                SelectObject(hitObject);
            }
            else
            {
                ClearSelection();
            }
        }
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                motor.MoveToPoint(hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }
    void SelectObject(GameObject obj)
    {
        if(selectedObject != null)
        {
            if (obj == selectedObject)
                return;

            ClearSelection();
        }
        selectedObject = obj;
        Renderer r = selectedObject.GetComponent<Renderer>();
        Material m = r.material;
        m.color = Color.green;
        r.material = m;
        isSelected = true;
    }

    void ClearSelection()
    {
        if (selectedObject == null)
            return;
        Renderer r = selectedObject.GetComponent<Renderer>();
        Material m = r.material;
        m.color = Color.blue;
        r.material = m;
        selectedObject = null;
        isSelected = false;
    }
    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }       
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}

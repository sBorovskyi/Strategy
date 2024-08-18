using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event Action OnSelectedUnitChanged;

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private BaseUnitAction selectedAction;
  

    [SerializeField] private Camera mainCamera;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one UnitActionSystem");
        }
        Instance = this;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() && !Input.GetKey(KeyCode.LeftControl))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray cursorRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cursorRay, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.TryGetComponent(out Unit unit))
                {
                    selectedUnit = unit;
                    selectedAction = null;
                    OnSelectedUnitChanged?.Invoke();
                }
                else
                {
                    if (selectedAction != null)
                    {
                        selectedAction.UseAction(raycastHit.transform.gameObject, raycastHit.point);
                    }
                }
               
            }
        }
    }

    public void SetSelectedAction(BaseUnitAction action)
    {
        selectedAction = action;
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}








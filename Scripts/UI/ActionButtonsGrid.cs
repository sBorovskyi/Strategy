using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ActionButtonsGrid : MonoBehaviour
{
    [SerializeField] private GameObject actionButtonPrefab;
    [SerializeField] private Transform gridTransform;

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

    private void UnitActionSystem_OnSelectedUnitChanged()
    {
        DestroyAllButtons();
        SpawnAllButtons();
    }

    private void SpawnButton(string buttonName, BaseUnitAction baseUnitAction)
    {
        GameObject spawnedButton = Instantiate(actionButtonPrefab, gridTransform);
        ActionButton spawnedActionButton = spawnedButton.GetComponent<ActionButton>();
        spawnedActionButton.SetButtonName(buttonName);
        spawnedActionButton.GetButton().onClick.AddListener(() => UnitActionSystem.Instance.SetSelectedAction(baseUnitAction));
        

    }

    private void SpawnAllButtons()
    {

        BaseUnitAction[] baseUnitActionsArray = UnitActionSystem.Instance.GetSelectedUnit().GetBaseUnitActions();
        int buttonsCount = baseUnitActionsArray.Length;
        for (int i = 0; i < buttonsCount; i++)
        {
            string buttonName = baseUnitActionsArray[i].GetActionName();
            SpawnButton(buttonName, baseUnitActionsArray[i]);
        }
    }

    private void DestroyAllButtons()
    {
        foreach (Transform button in gridTransform)
        {
            Destroy(button.gameObject);
        }
    }
}








/*
    [SerializeField] private GameObject actionButtonPrefab;
    [SerializeField] private Transform gridTransform;

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

    private void UnitActionSystem_OnSelectedUnitChanged()
    {
        DestroyAllButtons();
        SpawnAllButtons();
    }

    private void SpawnButton(string buttonName, BaseUnitAction baseUnitAction)
    {
        GameObject spawnedButton = Instantiate(actionButtonPrefab, gridTransform);
        ActionButton spawnedActionButton = spawnedButton.GetComponent<ActionButton>();
        spawnedActionButton.SetButtonName(buttonName);
        spawnedActionButton.GetButton().onClick.AddListener(() => baseUnitAction.UseAction(new GameObject(), Vector3.zero));
      
    }


    private void SpawnAllButtons()
    {
        BaseUnitAction[] baseUnitActionsArray = UnitActionSystem.Instance.GetSelectedUnit().GetBaseUnitActions();
        int buttonsCount = baseUnitActionsArray.Length;
        for (int i = 0; i < buttonsCount; i++)
        {
            string buttonName = baseUnitActionsArray[i].GetActionName();
            SpawnButton(buttonName, baseUnitActionsArray[i]);
        }
    }   
    
    private void DestroyAllButtons()
    {
        foreach (Transform button in gridTransform)
        {
            Destroy(button.gameObject);
        }
    }
    }*/
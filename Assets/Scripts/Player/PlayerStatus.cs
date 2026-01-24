using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    public List<Mission> myMissions  = new List<Mission>();
    public Mission activeMission;
    public bool HasMission => myMissions.Count > 0;

    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            OnNextMission();
        }
    }
    public void AddMission(Mission newMission)
    {
        myMissions.Add(newMission);
        activeMission = newMission;
        Debug.Log("Mission Added: " + newMission.description);
    }
    public void SwitchMission(int index)
    {
        if (index >= 0 && index < myMissions.Count)
        {
            activeMission = myMissions[index];
            Debug.Log("Switched to: " + activeMission.description);
        }
    }

    private void OnNextMission()
    {
        if (myMissions.Count <= 1) return;
        int currentIndex = myMissions.IndexOf(activeMission);
        int nextIndex = (currentIndex + 1) % myMissions.Count;

        SwitchMission(nextIndex);
    }

    public void CompleteActiveMission()
    {
        if (activeMission == null) return;
        Debug.Log("Mission Completed: " + activeMission.description);
        activeMission.isCompleted = true;
        myMissions.Remove(activeMission);

        if(myMissions.Count > 0)
        {
            activeMission = myMissions[0];
        }
        else
        {
            activeMission = null;
        }
    }
}

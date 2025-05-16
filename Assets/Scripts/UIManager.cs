using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using UnityEditor.ProjectWindowCallback;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text ui_txtScore;
    [SerializeField] private TMP_Text ui_txtFinalMission;
    [SerializeField] private ControllerPlane plane;
    private float time_txt = 0.08f;
    private int totalmines;
    private string endmission = "MISION COMPLETA. ELIMINA A LOS TESTIGOS";
    private bool hasWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalmines = GameObject.FindGameObjectsWithTag("pillmine").Length;
        hasWin = false;
    }
    void Update()
    {
        int minesleft = totalmines - GameObject.FindGameObjectsWithTag("pillmine").Length;
        ui_txtScore.text = "Score: " + minesleft + "/" + totalmines;
        if(minesleft == 5 && !hasWin)
        {
            hasWin = true;
            StartCoroutine(ShowFinalMission());
        }
    }

    IEnumerator ShowFinalMission()
    {
        ui_txtFinalMission.text = endmission;
        ui_txtFinalMission.maxVisibleCharacters = 0;

        foreach (char c in endmission)
        {
            ui_txtFinalMission.maxVisibleCharacters++;
            yield return new WaitForSeconds(time_txt);
        }
    }


}

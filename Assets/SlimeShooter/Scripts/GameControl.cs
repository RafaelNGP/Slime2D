using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] List<GameObject> barriersGO;
    [SerializeField] GameObject canvasComeco;
    [SerializeField] GameObject canvasFinal;
    [SerializeField] int points;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) canvasComeco.SetActive(false);
   
        if (points >= 2) barriersGO[0].SetActive(false);
        if (points >= 6) barriersGO[1].SetActive(false);
        if (points >= 9) barriersGO[2].SetActive(false);
        if (points >= 10) canvasFinal.SetActive(true);
    }

    public void EnemyKilled()
    {
        points++;
    }
}

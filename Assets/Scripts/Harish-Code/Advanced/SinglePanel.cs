using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePanel
{
    public List<GameObject> panelObjects = new List<GameObject>();

    public SinglePanel(GameObject firstPanel,GameObject secondPanel, GameObject answerPanel)
    {
        panelObjects.Add(firstPanel);
        panelObjects.Add(secondPanel);
        panelObjects.Add(answerPanel);
    }
}

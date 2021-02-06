using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxManager : MonoBehaviour
{
    public OxViewer[] oxen;
    public OxViewer[,] oxGrid = new OxViewer[2, 4];

    void Start()
    {
		for (int i = 0; i < oxen.Length; i++)
		{
			if (i < 4)
			{
				oxGrid[0, i] = oxen[i];
			} else
            {
				oxGrid[1, i - 4] = oxen[i];
            }
		}
	}
}

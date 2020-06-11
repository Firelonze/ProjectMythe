using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [SerializeField] protected GameObject[] topRow;
    [SerializeField] protected GameObject[] bottomRow;
    [SerializeField] protected GameObject[] leftRow;
    [SerializeField] protected GameObject[] rightRow;

    [SerializeField] protected GameObject[] topLeftCorner;
    [SerializeField] protected GameObject[] topRightCorner;
    [SerializeField] protected GameObject[] bottomLeftCorner;
    [SerializeField] protected GameObject[] bottomRightCorner;

    [SerializeField] protected GameObject[] center;

}

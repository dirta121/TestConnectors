using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelectController : MonoBehaviour
{
    private void OnMouseUp()
    {
        ObjectsController.instance.Deselect();
    }
}

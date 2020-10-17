using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectsController : Singleton<ObjectsController>
{
    public GameObject spawnObjectPREFAB;
    List<GameObject> _selectables;
    GameObject _selectedObject;

    public UnityAction<Vector3> onObjectsConnect;
    public UnityAction<Vector3> onObjectsDisconnect;
    private void Awake()
    {
        _selectables = new List<GameObject>();
    }
    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        GameObject go = Instantiate(spawnObjectPREFAB, position, rotation);

        _selectables.Add(go);
        return go;
    }
    public void Select(GameObject go)
    {
        if (_selectedObject == null)//first selection
        {
            _selectedObject = go;
            var selectable = _selectedObject.GetComponentInChildren<ISelectable>();
            var connectable = _selectedObject.GetComponentInChildren<IConnectable>();
            PrepareAll();
            selectable.Select();
            connectable.Disconnect();
        }
        else
        {
            if (go != _selectedObject)//make connection between selected and selectable
            {
                var connectable = _selectedObject.GetComponentInChildren<IConnectable>();
                if (connectable != null)
                {
                    connectable.Connect(go);
                }
            }
            Deselect();           
        }
    }
    public void Deselect()
    {
        var selectable = _selectedObject.GetComponentInChildren<ISelectable>();
        if (selectable == null)
            return;
        selectable.Deselect();
        _selectedObject = null;
        UnpreparedAll();
    }
    private void PrepareAll()
    {
        foreach (ISelectable s in _selectables.Select(s => s.GetComponentInChildren<ISelectable>()))
        {
            s.Prepare();
        }
    }
    private void UnpreparedAll()
    {
        foreach (ISelectable s in _selectables.Select(s => s.GetComponentInChildren<ISelectable>()))
        {
            s.Unprepare();
        }
    }
   
}

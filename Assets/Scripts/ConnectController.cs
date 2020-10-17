using UnityEngine;
public class ConnectController : MonoBehaviour, IConnectable
{
    private IConnectable _connectable;
    private ISelectable _selectable;
    private LineRenderer _lineRenderer;
    private void Start()
    {
        _selectable = GetComponent<ISelectable>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void LateUpdate()
    {
        DrawLine();
    }
    public void Connect(GameObject go)
    {
        var connectable = go.GetComponentInChildren<IConnectable>();
        if (connectable == null)
            return;
        _connectable = connectable;
    }
    public void Disconnect()
    {
        _connectable = null;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public bool TryGetConnectable(out IConnectable connectable)
    {
        connectable = null;
        if (_connectable == null)
            return false;

        connectable = _connectable;
        return true;
    }
    private void DrawLine()
    {
        Vector3 from = Vector3.zero;
        Vector3 to = Vector3.zero;

        if (_connectable == null)
        {
            if (_selectable.selected)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    to = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    from = transform.position;
                }
            }
        }
        else
        {
            to = _connectable.GetPosition();
            from = transform.position;
        }
        _lineRenderer.SetPosition(0, from);
        _lineRenderer.SetPosition(1, to);
    }
}

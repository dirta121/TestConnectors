using UnityEngine;
public class MoveController : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private float _yDefault;
    private void Start()
    {
        _yDefault = gameObject.transform.position.y;
    }
    void OnMouseDown()
    {
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + _offset;
        cursorPosition = new Vector3(cursorPosition.x, _yDefault, cursorPosition.z);
        transform.position = cursorPosition;
    }
}

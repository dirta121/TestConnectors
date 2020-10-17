using UnityEngine;
[RequireComponent(typeof(Collider))]
public class SelectController : MonoBehaviour, ISelectable
{
    public Color selectColor;
    public Color prepareColor;
    public bool selected { get { return _selected; } }
    private Color _normalColor;
    [SerializeField]
    private bool _selected;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;

        if (_material)
        {
            _normalColor = _material.color;
        }
    }
    public void Select()
    {
        _selected = true;
        SetColor(selectColor);
    }
    public void Deselect()
    {
        _selected = false;
        SetColor(_normalColor);
    }
    public void Prepare()
    {
        SetColor(prepareColor);
    }
    public void Unprepare()
    {
        SetColor(_normalColor);
    }
    private bool _mouseDown;
    private void OnMouseDown()
    {
        _mouseDown = true;
    }
    private void OnMouseUp()
    {
        if (_mouseDown)
        {
            ObjectsController.instance.Select(gameObject);
        }
    }
    private void SetColor(Color color)
    {
        if (_material != null)
        {
            _material.color = color;
        }
    }
}

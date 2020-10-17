using UnityEngine;
public interface IConnectable
{
    bool TryGetConnectable(out IConnectable connectable);
    Vector3 GetPosition();
    void Connect(GameObject go);
    void Disconnect();
}

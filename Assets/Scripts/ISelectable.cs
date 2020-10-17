public interface ISelectable
{
    bool selected{ get;}
    void Select();
    void Deselect();
    void Prepare();//blue
    void Unprepare();//!blue
}

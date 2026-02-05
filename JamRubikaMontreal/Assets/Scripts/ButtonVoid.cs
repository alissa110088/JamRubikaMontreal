using System.Collections.Generic;
using UnityEngine;

public class ButtonVoid : ButtonMaster
{
    public List<GameObject> workers = new List<GameObject>();
    private int _indexList = 0;
    protected override void OnClick()
    {
        if (_indexList <  workers.Count)
        {
            print(workers[_indexList].name);
            workers[_indexList].GetComponent<BoxCollider>().enabled = false;
            _indexList++;
        }
        else
        {
            Camera.main.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

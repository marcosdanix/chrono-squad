using UnityEngine;
using System.Collections;

public struct CharacterState
{
    public Vector3 position;
    public Vector3 localScale;

    public CharacterState(Transform tr)
    {
        this.position = tr.position;
        this.localScale = tr.localScale;
    }

    public void loadState(Transform tr)
    {
        tr.position = this.position;
        tr.localScale = this.localScale;
    }
}

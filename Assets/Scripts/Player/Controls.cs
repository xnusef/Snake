using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public void Up() => GameManager.GM.IM.OnUp();
    public void Down() => GameManager.GM.IM.OnDown();
    public void Left() => GameManager.GM.IM.OnLeft();
    public void Right() => GameManager.GM.IM.OnRight();
}

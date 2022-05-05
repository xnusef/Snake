using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnUp()
    {
        if (GameManager.GM.PM != null)
            GameManager.GM.PM.SetDir(Vector2.up);
    }
    public void OnDown()
    {
        if (GameManager.GM.PM != null)
            GameManager.GM.PM.SetDir(Vector2.down);
    }
    public void OnLeft()
    {
        if (GameManager.GM.PM != null)
            GameManager.GM.PM.SetDir(Vector2.left);
    }
    public void OnRight()
    {
        if (GameManager.GM.PM != null)
            GameManager.GM.PM.SetDir(Vector2.right);
    }
    void OnTap()
    {
        if (GameManager.GM.InGame == false)
            GameManager.GM.StartGame();
    }
}

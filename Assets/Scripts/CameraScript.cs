using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    int rows;
    int collumns;

    int curRow;
    int curCol;

    public RoomManager RoomManager;

	// Use this for initialization
	void Start () {
        rows = RoomManager.getRows();
        collumns = RoomManager.getCollumns();
        curRow = RoomManager.getActiveRow();
        curCol = RoomManager.getActiveCol();

        transform.position = RoomManager.getRoomTransform(curRow, curCol).position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (curCol < collumns - 1)
            {
                RoomManager.EnableRoom(curRow, curCol + 1);
                RoomManager.DisableRoom(curRow, curCol);
                curCol++;
                //TransitionRoom(curRow, curCol);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (curCol > 0)
            {
                RoomManager.EnableRoom(curRow, curCol - 1);
                RoomManager.DisableRoom(curRow, curCol);
                curCol--;
                //TransitionRoom(curRow, curCol);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (curRow > 0)
            {
                RoomManager.EnableRoom(curRow - 1, curCol);
                RoomManager.DisableRoom(curRow, curCol);
                curRow--;
                //TransitionRoom(curRow, curCol);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (curRow < (rows - 1))
            {
                RoomManager.EnableRoom(curRow + 1, curCol);
                RoomManager.DisableRoom(curRow, curCol);
                curRow++;
                //TransitionRoom(curRow, curCol);
            }
        }
        Vector3 t = Vector3.Lerp(transform.position, RoomManager.getRoomTransform(curRow, curCol).position, .6f);
        t.z = -10f;
        transform.position = t;
    }

    void TransitionRoom(int i , int j)
    {
        
    }
}

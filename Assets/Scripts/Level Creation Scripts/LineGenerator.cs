using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineGenerator : MonoBehaviour
{

    public lineCreator[] lineSetUp;

    private void Start()
    {

        foreach (lineCreator line in lineSetUp)
        {
            GameObject newLine = new GameObject(); // Creates GameObject
            newLine.AddComponent<LineRenderer>(); // Adds Component
            newLine.name = line.branchName + " Line"; // Renames
            newLine.transform.parent = gameObject.transform; // Sets Parent to Scripted Object
            
            for (int i = 1; i < line.branch.Length; i++)
            {
                CreateLine(newLine, line, line.branch[i-1].position, line.branch[i].position, i);
            }
        }
    }


    
    void CreateLine(GameObject line, lineCreator lineData, Vector2 startPoint, Vector2 endPoint, int index) // Moves index vertex  points to each Object in the array
    {

        // Creates the lineRender Component on GameObject and then inputs all perameters into the new component
        LineRenderer lr = line.GetComponent<LineRenderer>();

        lr.positionCount = lineData.branch.Length;
        lr.sortingOrder = -1;
        lr.material = lineData.branchMat;
        //color
        lr.startColor = lineData.branchColor;
        lr.endColor = lineData.branchColor;
        //width
        lr.startWidth = lineData.lineWidth;
        lr.endWidth = lineData.lineWidth;
        //position
        lr.SetPosition(index-1, startPoint);
        lr.SetPosition(index, endPoint);

        lr.textureMode = LineTextureMode.Tile;
        
    }

    [System.Serializable]
    public struct lineCreator
    {
        public string branchName; // User inputed name
        public Color branchColor; // color of line
        public Material branchMat; // creates a material for line
        public float lineWidth; // width of Line
        public Transform[] branch; // all objects that are on the branch
    }


}

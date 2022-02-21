using UnityEngine;
using UnityEngine.UI;

public class EmotionGraph : Graphic
{
    public Vector2Int gridSize;
    public float thickness;

    public Vector2 point;

    float width;
    float height;
    float unitWidth;
    float unitHeight;
/*
    protected override void OnEnable()
    {
        if (this.transform.childCount != 1)
        {
            GameObject circleUI = new GameObject("circle", typeof(Image));
            circleUI.transform.SetParent(this.transform,false);
            circleUI.GetComponent<Image>().sprite = circleSprite;
            RectTransform rectTransform = circleUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(points[1].x * unitWidth,points[1].y * unitHeight);
            rectTransform.sizeDelta = new Vector2(15,15);
            rectTransform.anchorMin = new Vector2(0,0);
            rectTransform.anchorMax = new Vector2(0,0); 
        } else
        {
            DestroyImmediate(this.transform.GetChild(0).gameObject);
            GameObject circleUI = new GameObject("circle", typeof(Image));
            circleUI.transform.SetParent(this.transform,false);
            circleUI.GetComponent<Image>().sprite = circleSprite;
            RectTransform rectTransform = circleUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(points[1].x * unitWidth,points[1].y * unitHeight);
            rectTransform.sizeDelta = new Vector2(15,15);
            rectTransform.anchorMin = new Vector2(0,0);
            rectTransform.anchorMax = new Vector2(0,0); 
        }

    }   */

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        unitWidth = width / gridSize.x/2;
        unitHeight = height / gridSize.y/2;

        //creates point relative to this parent
        DrawVerticesForPoint(point, vh);

        //creates points on the edges of this game object
        DrawBackground(vh, width, height);

        //Draws triangles from indexed made in previous functions
        DrawTriangles(vh);
    }

    private static void DrawTriangles(VertexHelper vh)
    {
        int index = 0;
        //Background
        vh.AddTriangle(index + 4, index + 5, index + 6);
        vh.AddTriangle(index + 4, index + 6, index + 7);

        //Point
        vh.AddTriangle(index + 0, index + 1, index + 2);
        vh.AddTriangle(index + 0, index + 3, index + 2);
    }

    void DrawBackground(VertexHelper vh, float width, float height)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = new Color32(255,255,255,150);

        //5
        vertex.position = new Vector3(-width / 2, -height / 2);
        vh.AddVert(vertex);
        //6
        vertex.position = new Vector3(width / 2, -height / 2);
        vh.AddVert(vertex);
        //7
        vertex.position = new Vector3(width / 2, height / 2);
        vh.AddVert(vertex);
        //8
        vertex.position = new Vector3(-width / 2, height / 2);
        vh.AddVert(vertex);
    }

    void DrawVerticesForPoint(Vector2 point, VertexHelper vh) 
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        //left bottom
        vertex.position = new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x-thickness, unitHeight * point.y-thickness/2);
        vh.AddVert(vertex);

        //right bottom
        vertex.position = new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y-thickness/2);
        vh.AddVert(vertex);

        //right top
        vertex.position = new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y+thickness/2);
        vh.AddVert(vertex); 

        //left top
        vertex.position = new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x-thickness, unitHeight * point.y+thickness/2);
        vh.AddVert(vertex);
    }
}

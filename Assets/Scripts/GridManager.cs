using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject gridContainer;
    public Tile[] tiles;
    private float[,] grid;
    public int boardSize = 4;

    private void Start() {
        adjustBoard(boardSize);
        grid = new float[boardSize, boardSize];
        for(int i = 0; i < boardSize; i++){
            for(int j = 0; j < boardSize; j++){
                SpawnTile(i, j);
            }
        }
    }

    private void adjustBoard(int boardSize){
        switch(boardSize){
            case 6: gridContainer.transform.position = new Vector2(gridContainer.transform.position.x - 1, gridContainer.transform.position.y - 1); break;
            case 7: gridContainer.transform.position = new Vector2(gridContainer.transform.position.x - 2, gridContainer.transform.position.y - 2); break;
            case 8: gridContainer.transform.position = new Vector2(gridContainer.transform.position.x - 2, gridContainer.transform.position.y - 2); break;
            default: return;
        }
    }

    private void SpawnTile(int x, int y){
        Tile selectedTile = tiles[Random.Range(0, boardSize)];
        GameObject[] allTiles = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;
        for (int i = 0; i < allTiles.Length; i++)
        {
            if(allTiles[i].name == selectedTile.color){
                count++;
            }
        }
        if(count < boardSize){
            GameObject g = new GameObject(selectedTile.color);
            Vector2 gridPos = gridContainer.transform.position;
            var s = g.AddComponent<SpriteRenderer>();
            s.sprite = selectedTile.tileSprite;
            g.transform.position = new Vector2((gridPos.x + x), (gridPos.y + y));
        }else{
            SpawnTile(x,y);
        }
    }
}
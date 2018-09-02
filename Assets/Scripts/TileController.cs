﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    #region Class Imports

    #endregion

    // Set class attributes
    #region Class Attributes

    private Queue<Tile> _tiles;
    public GameObject tilePrefab;

    enum Letter { A, B, C, D, E, F, G, H, I, J };

    #endregion

    #region Unity Specific

    // Use this for initialization
    void Awake () {
        _tiles = new Queue<Tile>();
        CreatePile();
	}

    #endregion

    #region Class Functions

    /// <summary>
    /// Create a tile array of 100 tiles rather than a 2D array of 10, 10 and then shuffles it.
    /// </summary>
    public void CreatePile() {
        int id = 0;
        for (int x = 0; x < 10; ++x) {
            // Loop along y axis
            for (int y = 0; y < 10; ++y) {
                _tiles.Enqueue(new Tile(id, y.ToString(), GetLetterFromInt(x)));
                ++id;
            }
        }

        ShufflePile();
    }

    /// <summary>
    /// Supply an enum int-value and get the string-value
    /// </summary>
    /// <param name="id">int value</param>
    /// <returns>string value</returns>
    public string GetLetterFromInt(int id) {
        Letter letter = (Letter)id;
        return letter.ToString();
    }

    /// <summary>
    /// Print a list of the tiles left
    /// </summary>
    public void PrintPile() {
        // TODO: Print to somewhere or return string
        foreach (Tile tile in _tiles)
            Debug.Log("Tile: " + tile.Number + tile.Letter);
    }

    /// <summary>
    /// Return the number of tiles left, what's remaining in the tiles array
    /// </summary>
    /// <returns>Count of tiles queue</returns>
    public int LeftInPile() {
        return _tiles.Count;
    }

    /// <summary>
    /// Shuffles the array of tiles using CommonFunctions
    /// </summary>
    public void ShufflePile() {
        // TODO: Look into using a List instead or benchmark this
        Tile[] tileArray = _tiles.ToArray();
        _tiles.Clear();
        CommonFunctions.Shuffle<Tile>(new System.Random(), tileArray);
        foreach (Tile tile in tileArray)
            _tiles.Enqueue(tile);
    }

    /// <summary>
    /// Draws a tile from the queue of available tiles
    /// </summary>
    /// <returns>First tile off queue</returns>
    public Tile DrawTile() {
        return _tiles.Dequeue();
    }

    /// <summary>
    /// Take the old tile and replace with the next tile
    /// </summary>
    /// <param name="oldTile">Tile being traded in</param>
    /// <returns>New Tile from pile, never oldTile</returns>
    public Tile TradeTile(Tile oldTile) {
        Tile newTile = DrawTile();
        _tiles.Enqueue(oldTile);
        ShufflePile();
        return newTile;
    }

    public void PlaceTile(Tile tile) {
        // TODO: Place the tile on the board
    }

    public void HighLightBoard(Tile tile) {
        // TODO: Highlight where on the board the tile would go
    }

    public void CreateTileObject(Tile tile, Vector3 position) {
        // TODO know the transform
        position = new Vector3(-8, -.5f, 0);
        Vector3 scale = new Vector3(1.5f, 1.5f, 1f);
        GameObject newTile = Instantiate(tilePrefab);

        // Give the TileObject script the tile
        newTile.GetComponent<TileObject>().Tile = tile;

        // Move and resize the tile
        newTile.transform.position = position;
        newTile.transform.localScale = scale;

        SetTileText(newTile, tile.Letter, tile.Number);

    }

    /// <summary>
    /// // set number and letter of tile
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="letter"></param>
    /// <param name="number"></param>
    public void SetTileText(GameObject tile, string letter, string number) {
        
        TextMesh[] tileText = tile.GetComponentsInChildren<TextMesh>();
        foreach (TextMesh textMesh in tileText)
            if (textMesh.name == "Letter")
                textMesh.text = letter;
            else
                textMesh.text = number;
    }

    #endregion
}

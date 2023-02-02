using UnityEngine;
using UnityEngine.Tilemaps;

namespace Platformer
{
    public class GeneratorLevelView : MonoBehaviour
    {

        public Tilemap _tilemap;
        public Tile _tile;
        public int _mapHeight;
        public int _mapWidth;

        [Range(0,100)] public int _fillPercent;
        [Range(0,100)] public int _smoothPercent;

        public bool _borders;
    }
}
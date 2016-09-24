using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class SceneView
    {
        private SceneModel model;

        public SceneView(SceneModel model)
        {
            this.model = model;
            InitializeSymbolMap();
        }

        const float CubeSizeX = 0.05F;
        const float CubeSizeY = 0.05F;
        public void DrawText()
        {
            char[] text = model.TextParameter.ToUpper().ToCharArray();
            int height = SymbolMap['A'].GetLength(0);

            // Calculating text length with spaces.
            int length = 0;
            foreach (char c in text)
            {
                length += (c == ' ') ? 1 : SymbolMap[c].GetLength(1);
            }

            // Starting position.
            float position = -CubeSizeX*length/2;

            // Drawing.
            foreach (char c in text)
            {
                if (c == ' ')
                {
                    position += CubeSizeX * 2;
                    continue;
                }

                byte[,] symbolBytes = SymbolMap[c];

                for (int i = 0; i < symbolBytes.GetLength(0); ++i)
                {
                    for (int j = 0; j < symbolBytes.GetLength(1); ++j)
                    {
                        if (symbolBytes[i, j] == 1)
                        {
                            PlaceCube(position + CubeSizeX * j, height - CubeSizeY * i);
                        }
                    }
                }
                position += CubeSizeX + CubeSizeX * symbolBytes.GetLength(1);
            }
        }

        private void PlaceCube(float x, float y)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(x, y, 0);
            cube.transform.localScale = new Vector3(CubeSizeX, CubeSizeY);
            Debug.Log("Cube placed: (" + x + ", " + y + ")");
        }

        private Dictionary<char, byte[,]> SymbolMap = new Dictionary<char, byte[,]>();

        private void InitializeSymbolMap()
        {
            SymbolMap.Add('A', new byte[,]
            {
                { 0, 1, 0 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 1, 1 },
                { 1, 0, 1 },
            });

            SymbolMap.Add('B', new byte[,]
            {
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 1, 0 },
            });

            SymbolMap.Add('C', new byte[,]
            {
                { 0, 1, 1 },
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 0, 1, 1 },
            });

            SymbolMap.Add('D', new byte[,]
            {
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 1, 0 },
            });

            SymbolMap.Add('E', new byte[,]
            {
                { 1, 1, 1 },
                { 1, 0, 0 },
                { 1, 1, 1 },
                { 1, 0, 0 },
                { 1, 1, 1 },
            });

            SymbolMap.Add('F', new byte[,]
            {
                { 1, 1, 1 },
                { 1, 0, 0 },
                { 1, 1, 1 },
                { 1, 0, 0 },
                { 1, 0, 0 },
            });

            SymbolMap.Add('G', new byte[,]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 0, 0 },
                { 1, 0, 1, 1 },
                { 1, 0, 0, 1 },
                { 1, 1, 1, 1 },
            });

            SymbolMap.Add('H', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 1, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
            });

            SymbolMap.Add('I', new byte[,]
            {
                { 1 },
                { 1 },
                { 1 },
                { 1 },
                { 1 },
            });

            SymbolMap.Add('J', new byte[,]
            {
                { 0, 0, 1 },
                { 0, 0, 1 },
                { 0, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
            });

            SymbolMap.Add('K', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 0, 1 },
            });

            SymbolMap.Add('L', new byte[,]
            {
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 1, 1 },
            });

            SymbolMap.Add('M', new byte[,]
            {
                { 1, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
            });

            SymbolMap.Add('N', new byte[,]
            {
                { 1, 0, 0, 1 },
                { 1, 1, 0, 1 },
                { 1, 0, 1, 1 },
                { 1, 0, 0, 1 },
                { 1, 0, 0, 1 },
            });

            SymbolMap.Add('O', new byte[,]
            {
                { 0, 1, 0 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
            });

            SymbolMap.Add('P', new byte[,]
            {
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 1, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 },
            });

            SymbolMap.Add('Q', new byte[,]
            {
                { 0, 1, 0, 0 },
                { 1, 0, 1, 0 },
                { 1, 0, 1, 0 },
                { 1, 0, 1, 0 },
                { 0, 1, 0, 1 },
            });

            SymbolMap.Add('R', new byte[,]
            {
                { 1, 1, 0 },
                { 1, 0, 1 },
                { 1, 1, 0 },
                { 1, 1, 0 },
                { 1, 0, 1 },
            });

            SymbolMap.Add('S', new byte[,]
            {
                { 1, 1, 1 },
                { 1, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 1 },
                { 1, 1, 1 },
            });

            SymbolMap.Add('T', new byte[,]
            {
                { 1, 1, 1 },
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 },
            });

            SymbolMap.Add('U', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 1, 1 },
            });

            SymbolMap.Add('V', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
            });

            SymbolMap.Add('W', new byte[,]
            {
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 0, 1, 0, 1, 0 },
            });

            SymbolMap.Add('X', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 1, 0, 1 },
                { 1, 0, 1 },
            });

            SymbolMap.Add('Y', new byte[,]
            {
                { 1, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 },
            });

            SymbolMap.Add('Z', new byte[,]
            {
                { 1, 1, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 1, 0, 0 },
                { 1, 1, 1 },
            });
        }
    }
}

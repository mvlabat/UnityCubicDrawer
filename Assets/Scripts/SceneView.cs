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

        public void DrawText()
        {
            char[] text = model.TextParameter.ToUpper().ToCharArray();

            // Calculating text height and width with spaces.
            int textWidth = 0;
            foreach (char c in text)
            {
                textWidth += 1 + (c == ' ' ? 1 : SymbolMap[c].GetLength(1));
            }
            int textHeight = SymbolMap['A'].GetLength(0);

            // Getting view sizes;
            float middleClipPane = Camera.main.nearClipPlane + (Camera.main.farClipPlane - Camera.main.nearClipPlane) / 2;
            Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, middleClipPane));
            Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, middleClipPane));
            float screenWidth = topRight.x - bottomLeft.x;
            float screenHeight = topRight.y - bottomLeft.y;

            // Setting cube size.
            float maxMagnitude = Mathf.Max(screenWidth, screenHeight);
            float cubeSize = (maxMagnitude - maxMagnitude / 10) / (screenWidth > screenHeight ? textWidth : textHeight);
            Debug.Log(maxMagnitude);
            Debug.Log(cubeSize);

            // Starting position.
            Vector3 position = bottomLeft + (topRight - bottomLeft) / 2;
            position.x -= cubeSize * textWidth / 2;
            position.y -= cubeSize * textHeight / 2;

            // Drawing.
            foreach (char c in text)
            {
                if (c == ' ')
                {
                    position.x += cubeSize * 2;
                    continue;
                }

                byte[,] symbolBytes = SymbolMap[c];

                for (int i = 0; i < symbolBytes.GetLength(0); ++i)
                {
                    for (int j = 0; j < symbolBytes.GetLength(1); ++j)
                    {
                        if (symbolBytes[i, j] == 1)
                        {
                            PlaceCube(new Vector3(position.x + cubeSize * j, position.y - cubeSize * i, position.z), cubeSize);
                        }
                    }
                }
                position.x += cubeSize + cubeSize * symbolBytes.GetLength(1);
            }
        }

        private void PlaceCube(Vector3 position, float cubeSize)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = position;
            cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            Debug.Log("Cube placed: (" + position.x + ", " + position.y + ")");
            Debug.Log("Cube placed: " + position);
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

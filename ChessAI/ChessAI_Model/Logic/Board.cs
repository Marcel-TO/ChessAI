namespace ChessAI_Model.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.Json;
    using ChessAI_Model.Figures;

    [Serializable]
    public class Board
    {
        private BaseFigure[,] figures;

        private int width;

        private int height;

        public Board(BaseFigure[,] figures, int width, int height)
        {
            this.Figures = figures;
            this.Width = width;
            this.Height = height;
            this.IsItWhitesTurn = true;
        }

        public BaseFigure[,] Figures
        {
            get
            {
                return this.figures;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.figures)} must not be null.");
                }
                else if (value.Length != 64)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.figures)} must be 64 (8x8).");
                }

                this.figures = value;
            }
        }

        public bool IsItWhitesTurn
        {
            get;
            set;
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value != 8)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.width)} must be between 8");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value != 8)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.height)} must be between 0 and 7");
                }

                this.height = value;
            }
        }

        public BaseFigure CurrentActive
        {
            get;
            set;
        }

        public Board Clone(Board source)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (Board)formatter.Deserialize(stream);
            }

            //var test = JsonSerializer.Serialize<BaseFigure[,]>(source.Figures);

            //return source;
        }
    }
}

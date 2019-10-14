namespace ernestMosebekoaPOE
{
    public class PositionModel
    {
        private int xPosition;
        private int yPosition;

        public PositionModel(int xPosition, int yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public int XPosition => xPosition;

        public int YPosition => yPosition;
    }
}
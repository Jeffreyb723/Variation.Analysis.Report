namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents an ordered pair of integer x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    public readonly struct Point
    {
        public float X { get;}
        public float Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        public Point(float x, float y) => (X, Y) = (x, y);

        public override bool Equals(object obj) => obj is Point point && this == point;

        public bool Equals(Point other) => this == other;

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Point left, Point right) => (left.X, left.Y) == (right.X, right.Y);

        public static bool operator !=(Point left, Point right) => (left.X, left.Y) != (right.X, right.Y);
    }
}

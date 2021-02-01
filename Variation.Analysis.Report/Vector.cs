namespace GeoPLM.Variation.Analysis.Report
{
    /// <summary>
    /// Represents an ordered triple of integer x-, y-, and z-coordinates that defines the end of a vector in a three-dimensional space.
    /// </summary>
    public readonly struct Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The x-axis position of the point.</param>
        /// <param name="y">The y-axis position of the point.</param>
        /// <param name="z">The z-axis position of the point.</param>
        public Vector(double x, double y, double z) => (X, Y, Z) = (x, y, z);

        public override bool Equals(object obj) => obj is Vector vector && this == vector;

        public bool Equals(Vector other) => this == other;

        public override int GetHashCode() => (X, Y, Z).GetHashCode();

        public static bool operator ==(Vector left, Vector right) => (left.X, left.Y, left.Z) == (right.X, right.Y, right.Z);

        public static bool operator !=(Vector left, Vector right) => (left.X, left.Y, left.Z) != (right.X, right.Y, right.Z);
    }
}

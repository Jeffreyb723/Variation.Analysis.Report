namespace Variation.Analysis.Report
{
    /// <summary>
    /// The <see cref="Information"/> module contains the procedures used to return, test for, or verify information. 
    /// </summary>
    public static class Information
    {
        /// <summary>
        /// Returns an <see cref="int"/> value representing an RGB color value from a set of red, green, and blue color components. 
        /// </summary>
        /// <param name="red">Required. Integer in the range 0-255, inclusive, that represents the intensity of the red component of the color.</param>
        /// <param name="green">Required. Integer in the range 0-255, inclusive, that represents the intensity of the green component of the color.</param>
        /// <param name="blue">Required. Integer in the range 0-255, inclusive, that represents the intensity of the blue component of the color.</param>
        /// <returns></returns>
        public static int Rgb(int red, int green, int blue) => red | (green << 8) | (blue << 16);
    }
}

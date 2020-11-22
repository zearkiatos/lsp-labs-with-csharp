using Xunit;
using LiskovSubstitutionPrincipleExample.src.models;

namespace LiskovSubstitutionPrincipleExample.Tests.src.models
{
    public class SquareUnitTest
    {
        [Fact]
        public void Not_Respect_The_Liskov_Substitution_Principle_Breaking_The_Rectangle()
        {
            int squareLengthAndWidth = 2;
            Square square = new Square(squareLengthAndWidth);

            int newSquareLength = 4;
            square.Length = newSquareLength;

            int expectedAreaTakingIntoAccountRectangleLaws = 8;

            Assert.NotEqual(expectedAreaTakingIntoAccountRectangleLaws, square.GetArea());
            
        }
    }
}
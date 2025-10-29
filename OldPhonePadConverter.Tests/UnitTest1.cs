using Xunit;

using Xunit;
using OldPhonePadConverter;  // your main project's namespace

namespace OldPhonePadConverter.Tests
{
    public class OldPhonePadTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void TestConversion(string input, string expected)
        {
            string result = OldPhonePadProgram.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}



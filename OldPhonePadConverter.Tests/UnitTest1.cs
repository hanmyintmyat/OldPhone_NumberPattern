namespace OldPhonePadConverter.Tests
{
    public class OldPhoneConverterTests
    {
        [Fact]
        public void HelloWorldExample()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("4433555 555666096667775553#");

            Assert.Equal("HELLO WORLD", r.Text);
            Assert.Empty(r.Warnings);
        }

        [Fact]
        public void BackspaceBehavior()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("227 *#");

            Assert.Equal("B", r.Text);  // "22" -> B, then '*' removes one letter -> B remains
        }

        [Fact]
        public void PartialWithoutHashProducesWarningButFlushes()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("33");

            Assert.Equal("E", r.Text); // 33 = E
            Assert.NotEmpty(r.Warnings);
            Assert.Contains("Input did not end with '#'", r.Warnings[0]);
        }

        [Fact]
        public void InvalidCharacterIsIgnored()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("44A#");

            Assert.Equal("H", r.Text); // 'A' ignored
            Assert.NotEmpty(r.Warnings);
        }

        [Fact]
        public void SpaceCharacterIsHandled()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("0#"); // '0' should be a space

            Assert.Equal(" ", r.Text);
            Assert.Empty(r.Warnings);
        }

        [Fact]
        public void ContinuousSameKeyWithPause()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("2 22 222#"); // "A", "B", "C"

            Assert.Equal("ABC", r.Text);
            Assert.Empty(r.Warnings);
        }

        [Fact]
        public void MultipleWordsAreHandledCorrectly()
        {
            var conv = new OldPhoneConverter();
            var r = conv.Convert("4433555 555666096667775553#"); // HELLO WORLD

            Assert.Equal("HELLO WORLD", r.Text);
        }
    }
}




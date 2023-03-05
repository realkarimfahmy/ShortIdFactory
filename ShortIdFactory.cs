namespace ShortIdFactory
{
    public class ShortIdFactory
    {
        private Random random = new Random();
        public int CharacterCount { get; }
        public ShortIdFactory(int characterCount)
        {
            CharacterCount = characterCount;
        }

        public string Generate()
        {
            var bitCount = 6 * CharacterCount;
            var byteCount = (int)Math.Ceiling(bitCount / 8f);
            byte[] buffer = new byte[byteCount];
            random.NextBytes(buffer);

            string guid = Convert.ToBase64String(buffer);
            guid = guid.Replace('+', '-').Replace('/', '_');
            return guid.Substring(0, CharacterCount);
        }
    }
}
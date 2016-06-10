using System;
using System.Linq;

namespace gollum.web.common.Helpers
{
    public class MockDataHelper
    {
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string[] RandomStringArray(int itemCount)
        {
            string[] arr = new string[itemCount + 1];
            for (int i = 0; i < itemCount; i++)
            {
                if (i % 2 == 0)
                    arr[i] = RandomString(4);
                else
                    arr[i] = RandomString(3);
            }

            return arr;
        }
    }
}

using gollum.web.common.Models.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace gollum.web.api.tests
{
    public static class MockDataProvider
    {

        #region Constants

        private const string LowerChars = "abcçdefgğhıijklmnoöpqrsştuüvwxyz";
        private const string UpperChars = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecialChars = "@#$%^&+=?";

        #endregion

        public static IEnumerable<TaskModel> MockTaskList(int listLen)
        {
            List<TaskModel> result = new List<TaskModel>();
            for (int i = 0; i < listLen; i++)
            {
                result.Add(MockSingleTaskModel());
            }
            return result;
        }

        public static TaskModel MockSingleTaskModel()
        {
            TaskModel model = new TaskModel()
            {
                Name = GenerateRandomString(false, true, true, false, 10),
                Description = GenerateRandomString(false, true, true, true, 20),
                Id = Guid.NewGuid().ToString(),
                Key = Guid.NewGuid()
            };

            return model;
        }

        private static string GenerateRandomString(bool? requireDigit, bool? requireLowercase, bool? requireUppercase, bool? requireNonLetterOrDigit, int? requiredLength)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            while (-2 < requiredLength--)
            {
                if (requireDigit == true)
                    sb.Append(Digits[rnd.Next(Digits.Length)]);
                if (requireLowercase == true)
                    sb.Append(LowerChars[rnd.Next(LowerChars.Length)]);
                if (requireUppercase == true)
                    sb.Append(UpperChars[rnd.Next(UpperChars.Length)]);
                if (requireNonLetterOrDigit == true)
                    sb.Append(SpecialChars[rnd.Next(SpecialChars.Length)]);
            }

            return sb.ToString();
        }


    }
}

using System.Security.Cryptography;
using System.Numerics;

namespace MssaExtension
{
   public enum StringFormat
   {
        Base64,
        Hex
   }

    public static class MssaExtensions
    {
        public static string GetSHAString(this FileInfo _file, StringFormat format=StringFormat.Hex) {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                return format switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash).ToLower(),
                    _ => Convert.ToBase64String(fileHash)
                };
                
            }
                
        }

        public static T Median<T>(this IEnumerable<T> _intArr) 
        {
            //how do we constraint T to that of numbers
            var sorted = _intArr.OrderBy(n => n).ToList();// lets arrange this input in sorted order so we can
            //pick out the middle item
            var middleItem = sorted.Count / 2;
            return sorted[middleItem]; 
            
        }
     
    }
}
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Security.Cryptography;

namespace TopGirl.Web
{

    public sealed class RegExpPatterns
    {
        private RegExpPatterns()
        {
        }

        public static String Matches_HTMLofXML_tags_REGEX = @"&lt;/?(\w+)(\s*\w*\s*=\s*(&quot;[^&quot;]*&quot;|'[^']'|[^&gt;]*))*|/?&gt;";
    }
    /// <summary>   
    /// 字串處理工具類別。   
    /// </summary>   
    public sealed class StringHelper
    {
        private StringHelper()
        {
        }

        /// <summary>   
        /// Append a slash character '\' to string.   
        /// </summary>   
        /// <param name="input">輸入字串。</param>   
        /// <returns>輸出字串。</returns>   
        public static string AppendSlash(string input)
        {
            if (input == null)
                return @"\";
            if (input.EndsWith("/") || input.EndsWith("\\"))
                return input;
            return input + "\\";
        }

        /// <summary>   
        /// Remove the last slash character.   
        /// </summary>   
        /// <param name="input">輸入字串。</param>   
        /// <returns>輸出字串。</returns>   
        public static string RemoveLastSlash(string input)
        {
            if (input == null)
                return "";
            if (input.EndsWith("/") || input.EndsWith("\\"))
                return input.Remove(input.Length - 1, 1);
            return input;
        }

        /// <summary>   
        /// 移除任何一個指定的字元。   
        /// </summary>       
        /// <param name="input">輸入字串。</param>   
        /// <param name="anyOf">要移除的字元。</param>   
        /// <returns>輸出字串。</returns>   
        public static string RemoveAny(string input, char[] anyOf)
        {
            if (String.IsNullOrEmpty(input))
                return input;

            int i;

            while (true)
            {
                i = input.IndexOfAny(anyOf);

                if (i < 0)
                    break;

                input = input.Remove(i, 1);

            }
            return input;

        }

        /// <summary>   
        /// 移除換行字元(\n) 和(\r)。   
        /// </summary>   
        /// <param name="input">輸入字串。</param>   
        /// <returns>輸出字串。</returns>   
        public static string RemoveNewLines(string input)
        {
            return StringHelper.RemoveNewLines(input, false);

        }

        /// <summary>   
        /// 移除換行字元(\n) 和(\r)。   
        /// </summary>   
        /// <param name="input">輸入字串。</param>   
        /// <param name="addSpace">若為true，則把換行符號替換成空白字元。</param>   
        /// <returns>輸出字串。</returns>   
        public static string RemoveNewLines(string input,
           bool addSpace)
        {
            string replace = string.Empty;

            if (addSpace)
                replace = " ";

            string pattern = @"[\r|\n]";

            Regex regEx = new Regex(pattern, RegexOptions.Multiline);

            return regEx.Replace(input, replace);

        }
        /// <summary>   
        /// 移除空白字元（包括全形空白）。 
        /// </summary> 
        /// <param name="input">輸入字串。</param>  
        /// <param name="fullShapeSpaces">是否連全形空白也一併刪除。</param>  
        /// <returns>輸出字串。</returns>  
        public static string RemoveSpaces(string input, bool fullShapeSpaces)
        {
            string replace = string.Empty;

            string pattern = @"[ ]";

            if (fullShapeSpaces)
            {
                pattern = @"[ |　]";

            }
            Regex regEx = new Regex(pattern, RegexOptions.Multiline);

            return regEx.Replace(input, replace);

        }
        /// <summary>   
        /// 擷取字串固定長度字元 (從字首開始)。 
        /// </summary> 
        /// <param name="input">輸入字串。</param>  
        /// <param name="intByteLength">要擷取字元長度。</param> 
        /// <returns>輸出字串。</returns>  
        public static string SubstringByte(string input, int intByteLength)
        {
            string strResult = string.Empty;
            int intPos= 0;
            int intCharLen = 0 ;
            byte[] byt;

            byt = Encoding.Default.GetBytes(input);
            for (int i = 0; i <= byt.Length - 1; i++)
            {

                intCharLen = (byt[i] >= 0 & byt[i] <128) ? 1 : 2;

                strResult += Encoding.Default.GetString(byt, i, intCharLen);

                if (intCharLen == 2)
                {
                    i += 1;
                }

                intPos += intCharLen;
                if (intPos >= intByteLength | (intPos == intByteLength - 1 & intCharLen == 2))
                {
                    return strResult;
                    strResult = string.Empty;
                    intPos = 0;
                }
            }
            return strResult;

        }
        /// <summary>  
        /// 檢驗身分證號碼的正確性。  
        ///    驗證規則：  
        ///  
        ///        身份證統一編號共計有10 位，其中第一位為英文字母，後共有九個數字； 
        ///        而最後一位數字為檢查碼( Check Digit ) ，表示如下表：  
        ///  
        ///        L1 D2 D2 D3 D4 D5 D6 D7 D8 D9 
        /// 
        ///        L1: 英文字母, 代表出生地的縣/市代號  
        ///        D2: 性別,1=男, 2=女 
        ///        D9: 檢查碼  
        ///  
        ///        L1 對照表:  
        ///  
        ///          字母A  B  C  D  E  F  G  H  J  K  L  M  N   
        ///          代號10 11 12 13 14 15 16 17 18 19 20 21 22   
        ///          -------------------------------------------  
        ///          字母P  Q  R  S  T  U  V  X  Y  W  Z  I  O  
        ///          代號23 24 25 26 27 28 29 30 31 32 33 34 35   
        ///  
        ///        令其十位數為X1 ，個位數為X2 ；( 如Ａ：X1=1 , X2=0 )  
        ///  
        ///        依其公式計算結果：  
        ///        Ｙ= X1 + 9*X2 + 8*D1 + 7*D2 + 6*D3 + 5*D4 + 4*D5 + 3*D6 + 2*D7 +   
        ///        D8 + D9  
        ///  
        ///      假如Ｙ能被10 整除，則表示該身份證號碼為正確，否則為錯誤。即如以10 為  
        ///        模數，檢查號碼為( 10 - Ｙ- D9 ) / 10 的餘數，如餘數為0 時，則檢查碼  
        ///        為0 。  
        ///   
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public static bool CheckIdno(string idno)
        {
            int[] letter_weight =   
             {  
                 // A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R  
                 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25,  
                 26, 27, 28, 29, 32, 30, 31, 33  
                 // S   T   U   V   W   X   Y   Z  
             };

            int i;

            int[] D = new int[9];
            // 1..9  
            int sum;

            if (idno.Length != 10)
                return false;

            idno = idno.ToUpper();

            if (!Char.IsLetter(idno[0]) || (idno[1] != '1' && idno[1] != '2'))
                return false;

            for (i = 1; i < 10; i++)
            {
                if (!Char.IsDigit(idno, i))
                    return false;

            }
            for (i = 0; i < 9; i++) // 1..9  
            {
                D[i] = Int32.Parse(idno.Substring(i + 1, 1));

            }
            i = letter_weight[idno[0] - 'A'];

            sum = (i / 10) + (i % 10) * 9;

            sum = sum + 8 * D[0] + 7 * D[1] + 6 * D[2] + 5 * D[3]
                + 4 * D[4] + 3 * D[5] + 2 * D[6] + D[7] + D[8];

            return (sum % 10 == 0);

        }
        /// <summary>  
        /// 判斷字串值是否為數字。  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public static bool IsDigit(string s)
        {
            try
            {
                long num = Convert.ToInt64(s);

                return true;

            }
            catch
            {
                return false;

            }
        }
        /// <summary>  
        /// 將字串轉成位元組陣列。  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

            return encoding.GetBytes(str);

        }
        /// <summary>  
        /// 將字串轉成位元組陣列。  
        /// </summary>  
        /// <param name="str">輸入字串。</param>  
        /// <param name="enc">編碼。</param>  
        /// <returns></returns>  
        public static byte[] StrToByteArray(string str, Encoding enc)
        {
            return enc.GetBytes(str);

        }
        /// <summary>  
        /// Byte 陣列轉成字串。  
        /// </summary>  
        /// <param name="bytes"></param>  
        /// <returns></returns>  
        public static string ByteArrayToStr(byte[] bytes)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();

            return enc.GetString(bytes);

        }
        /// <summary>  
        /// 大小寫無關的置換函式。  
        /// </summary>  
        /// <param name="input">輸入字串。</param>  
        /// <param name="newValue">要被置換的字串。</param>  
        /// <param name="oldValue">置換的新字串。</param>  
        /// <returns>A string</returns>  
        public static string CaseInsenstiveReplace(string input,
           string oldValue, string newValue)
        {
            Regex regEx = new Regex(oldValue,
               RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return regEx.Replace(input, newValue);

        }

        /// <summary>  
        /// 檢查傳入的字串是否有出現任何一個指定的字串。字串比對時有分大小寫。  
        /// </summary>  
        /// <param name="input">欲檢查的字串</param>  
        /// <param name="hasWords">要搜尋的字詞。</param>  
        /// <returns>有符合的字詞</returns>  
        public static MatchCollection HasWords(string input,
           params string[] hasWords)
        {
            StringBuilder sb = new StringBuilder(hasWords.Length + 50);

            //sb.Append("[");

            foreach (string s in hasWords)
            {
                sb.AppendFormat("({0})|",
                   HttpUtility.HtmlEncode(s.Trim()));

            }

            string pattern = sb.ToString();

            pattern = pattern.TrimEnd('|');
            // +"]";


            Regex regEx = new Regex(pattern, RegexOptions.Multiline);

            return regEx.Matches(input);

        }
        /// <summary>  
        /// 將字串以MD5 編碼。  
        /// </summary>  
        /// <param name="input">欲編碼的字串。</param>  
        /// <returns>編碼過的字串</returns>  
        public static string MD5Encode(string input)
        {
            // Create a new instance of the   
            // MD5CryptoServiceProvider object.  
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte   
            // array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(
               Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));

            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();

        }
        /// <summary>  
        /// 刪除空白以及多餘的結束字元（'\0'）。  
        /// 某些WinAPI 傳回的字元陣列轉成字串之後，後面會附加結束字元和垃圾資料，便可使用此函式。  
        /// </summary>  
        /// <param name="input">輸入字串</param>  
        /// <returns>輸出字串。</returns>  
        public static string Trim(string s)
        {
            s = s.Trim();

            int i = s.IndexOf('\0');

            if (i >= 0)
            {
                return s.Substring(0, i);

            }
            return s;

        }

        /// <summary>  
        /// 驗證一個字串是否經過MD5 編碼後會與傳入的MD5 字串相符。可用來驗證使用者密碼。  
        /// </summary>  
        /// <param name="input">欲比較的字串。</param>  
        /// <param name="hash">MD5 編碼過的字串。</param>  
        /// <returns>若相符則傳回True，否則傳回False。</returns>  

        public static bool MD5Verify(string input, string md5str)
        {
            // Hash the input.  
            string hashOfInput = StringHelper.MD5Encode(input);

            // Create a StringComparer an comare the hashes.  
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, md5str))
            {
                return true;

            }
            else
            {
                return false;

            }
        }
        /// <summary>  
        /// 將字串中的所有全形空白轉成半形空白。  
        /// </summary>  
        /// <param name="input">輸入字串。</param>  
        /// <returns>輸出字串。</returns>  
        public static string FullShapeSpaceToSpace(string input)
        {
            string replace = " ";


            string pattern = @"[　]";

            Regex regEx = new Regex(pattern, RegexOptions.Multiline);

            return regEx.Replace(input, replace);

        }

        /// <summary>  
        /// 把所有空白字元轉換成HTML 空白。  
        /// </summary>  
        /// <param name="input">輸入字串。</param>  
        /// <returns>輸出字串。</returns>  
        public static string SpaceToNbsp(string input)
        {
            string space = "&nbsp;&nbsp;";

            return input.Replace(" ", space);

        }

        /// <summary>  
        /// 把所有換行符號(\n) 和(\r) 轉成HTML 斷行標籤。  
        /// </summary>  
        /// <param name="input">輸入字串。</param>  
        /// <returns>輸出字串。</returns>  
        public static string NewLineToBreak(string input)
        {
            Regex regEx = new Regex(@"[\n|\r]+");

            return regEx.Replace(input, "<br />");

        }

        /// <summary>  
        /// 判斷傳入的字串是否為空字串。  
        /// 注意：空白、全形空白、Tab 字元、和換行符號均視為「空」字元。  
        /// </summary>  

        /// <param name="input"></param>  
        /// <returns></returns>  
        public static bool IsEmpty(string input)
        {
            string s = StringHelper.RemoveAny(input, new char[] { '　', ' ', '\t', '\r', '\n', '\0' });

            if (String.IsNullOrEmpty(s))
                return true;

            return false;

        }
        /// <summary>  
        /// 把內含16 進位值的字串轉成byte。  
        /// </summary>  
        /// <param name="input">內含16 進位值的字串，例如：1F、AE。</param>  
        /// <returns>byte 值。</returns>  
        public static byte HexStrToByte(string s)
        {
            return byte.Parse(s, System.Globalization.NumberStyles.HexNumber);

        }
        /// <summary>  
        /// 字串反轉。  
        /// </summary>  
        /// <param name="s">輸入字串。</param>  
        /// <returns>反轉後的字串。</returns>  
        public static string Reverse(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";

            char[] charArray = new char[s.Length];

            int len = s.Length - 1;

            for (int i = 0; i <= len; i++)
            {
                charArray[i] = s[len - i];

            }
            return new string(charArray);

        }

        ///// <summary>  
        ///// 尋找成對的標籤。例如：<姓名>Michael</姓名>。  
        ///// </summary>  
        ///// <param name="s"></param>  
        ///// <returns></returns>  
        //public static MatchCollection FindTagPairs(string s)
        //{
        //    return Regex.Matches(s, RegExpPatterns.OneTagPair);

        //}

        ///// <summary>  
        ///// 尋找起始標籤或結束標籤。例如：<姓名>、</aa>。  
        ///// </summary>  
        ///// <param name="s"></param>  
        ///// <returns></returns>  
        //public static MatchCollection FindTags(string s)
        //{
        //    return Regex.Matches(s, RegExpPatterns.Tags);

        //}
        
        public static bool IsDateTime(string dt)
		{
		    Regex rgx = new 
		      Regex(@"(?<Year>(?:\d{4}|\d{2}))/(?<Month>\d{1,2})/(?<Day>\d{1,2})");
		    if (rgx.IsMatch(dt))
		    {
		        return true;
		    }
		    else
		    {
		        return false;
		    }
		}
 
		public static string FormatDateTimeString(string theDate , string dtFormat){
			
			return IsDateTime(theDate) ? Convert.ToDateTime(theDate).ToString(dtFormat) : theDate;
       
		}
        public static string GetExtension(string FileName)
        {
            string[] split = FileName.Split('.');
            string Extension = split[split.Length - 1];
            return Extension;
        }

        public static string GetFileName(string FileName, char[] SplitString)
        {
            string[] split = FileName.Split(SplitString);
            string Extension = split[split.Length - 1];

             
            return Extension;
        }

    }
}
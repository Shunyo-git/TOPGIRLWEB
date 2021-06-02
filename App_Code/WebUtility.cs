using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Configuration;
using TopGirl.BusinessLogicLayer;
using System.Text;
 
/// <summary>
/// WebUtility 的摘要描述
/// </summary>
namespace TopGirl.Web
{
    /// <summary>
    /// Collection of utility methods for web tier
    /// </summary>
    public static class WebUtility
    {

        //private const string REDIRECT_URL = "~/Search.aspx?keywords={0}";
        //private static readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);


        /// <summary>
        /// Method to make sure that user's inputs are not malicious
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        /// <returns>The cleaned up version of the input</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }

        /// <summary>
        /// Method to check whether input has other characters than numbers
        /// </summary>
        public static string CleanNonWord(string text)
        {
            return Regex.Replace(text, "\\W", "");
        }

        /// <summary>
        /// Method to redirect user to search page
        /// </summary>
        /// <param name="key">Search keyword</param> 
        //public static void SearchRedirect(string key)
        //{
        //    HttpContext.Current.Response.Redirect(string.Format(REDIRECT_URL, InputText(key, 255)));
        //}

        public static string SubstringText(string Title, int MaxLength)
        {
            string Val = Title;
            if (Val.Length > MaxLength)
            {
                Val = Val.ToString().Substring(0, MaxLength) + "…";
            }
            return Val;
        }

        public static string CrToBr(string text)
        {
            string replase = "<BR />";
            string pattern = @"[\r|\n]";  
            Regex regEx = new Regex(pattern, RegexOptions.Multiline);
            return regEx.Replace(text, replase);
            
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
        /// 置換半形空白字元。  
        /// </summary>         
        /// <param name="input">輸入字串。</param>  
        /// <param name="replace">置換結果字串。</param>
        /// <param name="fullShapeSpaces">是否連全形空白也一併刪除。</param>
        /// <returns>輸出字串。</returns>  

        public static string ReplaceSpaces(string input, string replace, bool fullShapeSpaces)
        {
            
            string pattern = @"[ ]";
            if (fullShapeSpaces)  
            {  
                pattern = @"[ |　]";  
            }    

            Regex regEx = new Regex(pattern, RegexOptions.Multiline);

            return regEx.Replace(input, replace);
        }

        /// <summary>   
        /// 編碼字元。使用Base64編碼。  
        /// </summary>         
        /// <param name="input">輸入字串。</param>  
        /// <returns>輸出字串。</returns>  
        public static string ToBase64String(string input)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(input));
        }

        /// <summary>   
        /// 解碼字元。使用Base64編碼。  
        /// </summary>         
        /// <param name="input">輸入字串。</param>  
        /// <returns>輸出字串。</returns>  
        public static string FromBase64String(string input)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(input));
        }
         
    }
}
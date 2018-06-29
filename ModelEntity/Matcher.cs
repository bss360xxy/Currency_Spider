using HtmlAgilityPack;
using IBaseTaskRuner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelEntity
{
    /// <summary>
    /// 数据抽取
    /// </summary>
    public class Matcher
    {
        public static List<object> GetResult<T>(T config, String str)
        {
            List<object> vs = new List<object>();
            var configtype = typeof(T);
            switch (configtype.Name.ToUpper())
            {
                case "StringMatchConfig":
                    var config_char = config as StringMatchConfig;
                    if (config_char != null)
                    {
                        vs.Add(config_char.GetResult(str));
                    }
                    break;

                case "RegMatchConfig":
                    var config_reg = config as RegMatchConfig;
                    if (config_reg != null)
                    {
                        vs.AddRange(config_reg.GetResult(str));
                    }
                    break;
            }


            return vs;
        }

    }

    /// <summary>
    /// 中间字符串截取
    /// </summary>
    public class StringMatchConfig : IMatcher
    {
        public String headstr { get; set; } = String.Empty;
        public String footstr { get; set; } = String.Empty;

        public object GetResult(String sorcestr)
        {
            return QuMiddle(sorcestr, headstr, footstr);
        }

        #region 辅助函数
        /// <summary>
        /// 取字符串中间 切割用
        /// </summary>
        /// <param name="str">总字符串</param>
        /// <param name="str1">左边字符串</param>
        /// <param name="str2">右边字符串</param>
        /// <returns>中间字符串</returns>
        private static string QuMiddle(string str, string str1, string str2)
        {
            int leftlocation;
            //左边位置
            int rightlocation
                ;//右边位置 
            int strmidlength;
            ;//中间字符串长度
            string strmid = null;
            ;//中间字符串
            leftlocation = str.IndexOf(str1);
            //获取左边字符串头所在位置 
            if (leftlocation == -1)
            //判断左边字符串是否存在于总字符串中
            {
                return "";
            }
            leftlocation = leftlocation + str1.Length;
            //获取左边字符串尾所在位置 
            rightlocation = str.IndexOf(str2, leftlocation);
            //获取右边字符串头所在位置 
            if (rightlocation == -1 || leftlocation > rightlocation)
            //判断右边字符串是否存在于总字符串中，左边字符串位置是否在右边字符串前
            {
                return "";
            }
            strmidlength = rightlocation - leftlocation;
            //计算中间字符串长度 
            strmid = str.Substring(leftlocation, strmidlength);
            //取出中间字符串 
            return strmid;
            //返回中间字符串
        }
        #endregion
    }

    /// <summary>
    /// 正则匹配 结果分割字符为 <RegexSplit>
    /// </summary>
    public class RegMatchConfig : IMatcher
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        public String reg { get; set; } = String.Empty;
        /// <summary>
        /// 抽取层数
        /// </summary>
        public int groups { get; set; } = 0;
        /// <summary>
        /// 是否多条匹配结果
        /// </summary>
        public bool mulit { get; set; } = false;

        public object GetResult(string str)
        {
            List<object> list = new List<object>();
            Regex regex = new Regex(reg);
            try
            {
                if (regex.IsMatch(str))
                {
                    var matchs = regex.Matches(str);
                    foreach (Match m in matchs)
                    {
                        if (m.Groups.Count > groups)
                        {
                            list.Add(m.Groups[groups]);
                        }
                        if (!mulit)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +"\r\n" +ex.StackTrace);
            }

            return list?.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class XpathMatchConfig : IMatcher
    {
        /// <summary>
        /// xpath表达式
        /// </summary>
        public String xpath { get; set; } = String.Empty;
        /// <summary>
        /// 是否多条匹配结果
        /// </summary>
        public bool mulit { get; set; } = false;
        /// <summary>
        /// 抽取属性
        /// </summary>
        public String attr { get; set; } = String.Empty;
        /// <summary>
        ///true为抽取  false为匹配
        /// </summary>
        public bool innertext = true;
        public object GetResult(string str)
        {
            List<object> list = new List<object>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(str);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(xpath);
                if(nodes!=null)
                {
                    foreach(HtmlNode node in nodes)
                    {
                        if(String.IsNullOrEmpty(attr))
                        {
                            list.Add(innertext? node.InnerText:node.InnerHtml);
                        }
                        else
                        {
                            list.Add(node.Attributes[attr]);
                        }
                        if(!mulit)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }

            return list?.ToArray();
        }
    }

}

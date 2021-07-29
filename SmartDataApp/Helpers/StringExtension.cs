using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartDataApp.Helpers
{
    public static class StringExtension
    {
        public static List<string> ContainsKeywords(this string word)
        {
            List<string> result = new List<string>();
            word = word.ToLower().Replace(" ", "");

            if (word.Contains(StopWordEnum.AND.ToString().ToLower()))
            {
                result = word.Split(StopWordEnum.AND.ToString().ToLower(), StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].EndsWith("s", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].EndsWith("'", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].Contains("'", StringComparison.CurrentCultureIgnoreCase) )
                    {
                        if (result[i].EndsWith("ss", StringComparison.CurrentCultureIgnoreCase))
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                        else
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                    }
                }

                return result;
            }

            if (word.Contains(StopWordEnum.OR.ToString().ToLower()))
            {
                result = word.Split(StopWordEnum.OR.ToString().ToLower(), StringSplitOptions.RemoveEmptyEntries).ToList();
                
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].EndsWith("s", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].EndsWith("'", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].Contains("'", StringComparison.CurrentCultureIgnoreCase) )
                    {
                        if (result[i].EndsWith("ss", StringComparison.CurrentCultureIgnoreCase))
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                        else
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                    }
                }

                return result;
            }

            if (word.Contains(StopWordEnum.THE.ToString().ToLower()))
            {
                result = word.Split(StopWordEnum.THE.ToString().ToLower(), StringSplitOptions.RemoveEmptyEntries).ToList();
                
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].EndsWith("s", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].EndsWith("'", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].Contains("'", StringComparison.CurrentCultureIgnoreCase) )
                    {
                        if (result[i].EndsWith("ss", StringComparison.CurrentCultureIgnoreCase))
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                        else
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                    }
                }

                return result;
            }

            if (word.Contains(StopWordEnum.INTO.ToString().ToLower()))
            {
                result = word.Split(StopWordEnum.INTO.ToString().ToLower(), StringSplitOptions.RemoveEmptyEntries).ToList();
                
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].EndsWith("s", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].EndsWith("'", StringComparison.CurrentCultureIgnoreCase) ||
                        result[i].Contains("'", StringComparison.CurrentCultureIgnoreCase) )
                    {
                        if (result[i].EndsWith("ss", StringComparison.CurrentCultureIgnoreCase))
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                        else
                        {
                            result[i] = result[i].Remove(result[i].Length - 1);
                        }
                    }
                }

                return result;
            }
            
            result.Add(word);
            return result;
        }
    }
}
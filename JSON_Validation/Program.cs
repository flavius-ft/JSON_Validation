using System;

namespace JSON_Validation
{
    public class Program
    {
        public static void Main()
        {
            string jsonString = Console.ReadLine();

            if (ValidateJsonString(jsonString))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            Console.Read();
        }

        public static bool ValidateJsonString(string jsonString)
        {
            if (jsonString == string.Empty)
            {
                return true;
            }
            
            string controlChars = "\"/bfnrtu";
            for (int i = 1; i < jsonString.Length - 2; i++)
            {
                if (jsonString[i + 1] < 32 || jsonString[i] == '"')
                {
                    return false;
                }

                if (jsonString[i] == '\\')
                {
                    if (jsonString[i + 1] == 'u')
                    {
                        if (i + 5 < jsonString.Length - 1)
                        {
                            for (int k = i + 2; k <= i + 5; k++)
                            {
                                if (jsonString[k] >= '0' && jsonString[k] <= '9')
                                {
                                    continue;
                                }
                                else if (jsonString[k] >= 'A' && jsonString[k] <= 'F')
                                {
                                    continue;
                                }
                                else if (jsonString[k] >= 'a'&& jsonString[k] <= 'f')
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (!controlChars.Contains(jsonString[i + 1]))
                    {
                        return false;
                    }
                }
            }
            
            if (jsonString.Length < 2)
            {
                return false;
            }

            return jsonString[0] == '\"' && jsonString[jsonString.Length - 1] == '\"';
        }
    }
}

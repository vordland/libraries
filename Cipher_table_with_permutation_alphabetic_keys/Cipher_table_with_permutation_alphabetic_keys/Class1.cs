using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cipher_table_with_permutation_alphabetic_keys
{
    public class Code
    {
        public static string Ciphering_text(string original_text, string key_text)
        {
            string alf_high = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alf_low = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int max = (int)Math.Ceiling((double)(original_text.Length) / (key_text.Length));//количество строк
            string[,] table = new string[key_text.Length, max];
            string new_text = "";
            int[] i_key = new int[key_text.Length];//переменная , хранящая ключ в числовом виде
            //заменяем буквы в ключе на цифры из алфавита
            for (int i = 0; i < key_text.Length; i++)
            {
                i_key[i] = (alf_high.IndexOf(key_text[i]) != -1) ? alf_high.IndexOf(key_text[i]) : ((alf_low.IndexOf(key_text[i]) != -1) ? alf_low.IndexOf(key_text[i]) : -1);
            }
            //заменяем цифры в ключе на цифры по порядку

            int[] min_i = new int[key_text.Length];//содержит номера ключей, которые же использовались-для поиска не только самого минимального , но больше минимального
            for (int i = 0; i < key_text.Length; i++)
            {
                min_i[i] = -1;
            }
            for (int i = 0; i < key_text.Length; i++)
            {
                int min_key = alf_high.Length;//содержит мин ключ данной итерации
                int j = 0;
                for (; j < key_text.Length; j++)
                {
                    if ((min_key > i_key[j]) && (min_i.Contains(j) == false))
                    {
                        min_key = i_key[j];
                        min_i[i] = j;
                    }
                }

            }
            //занесение букв в матрицу
            for (int i = 0, k = 0; (i < key_text.Length); i++)
            {
                for (int j = 0; (j < max); j++)
                {

                    if ((k == original_text.Length) || (k > original_text.Length))
                    {
                        table[i, j] = " ";
                    }
                    else
                    {
                        table[i, j] = original_text[k].ToString();
                        
                    }
                    k++;
                }

            }
            //цикл для возврата букв
            for (int i = 0; (i < max); i++)
            {
                for (int j = 0; (j < key_text.Length); j++)
                {
                    new_text += table[min_i[j], i];
                }
            }
            return new_text;
        }
        public static string Enciphering_text(string original_text, string key_text)
        {
            string alf_high = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alf_low = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int max = (int)Math.Ceiling((double)(original_text.Length) / (key_text.Length));//количество строк
            string[,] table = new string[key_text.Length, max];
            string new_text = "";
            int[] i_key = new int[key_text.Length];//переменная , хранящая ключ в числовом виде
            //заменяем буквы в ключе на цифры из алфавита
            for (int i = 0; i < key_text.Length; i++)
            {
                i_key[i] = (alf_high.IndexOf(key_text[i]) != -1) ? alf_high.IndexOf(key_text[i]) : ((alf_low.IndexOf(key_text[i]) != -1) ? alf_low.IndexOf(key_text[i]) : -1);
            }
            //заменяем цифры в ключе на цифры по порядку

            int[] min_i = new int[key_text.Length];//содержит номера ключей, которые же использовались-для поиска не только самого минимального , но больше минимального
            for (int i = 0; i < key_text.Length; i++)
            {
                min_i[i] = -1;
            }
            for (int i = 0; i < key_text.Length; i++)
            {
                int min_key = alf_high.Length;//содержит мин ключ данной итерации
                int j = 0;
                for (; j < key_text.Length; j++)
                {
                    if ((min_key > i_key[j]) && (min_i.Contains(j) == false))
                    {
                        min_key = i_key[j];
                        min_i[i] = j;
                    }
                }
                i_key[min_i[i]] = i;
            }
            //занесение букв в матрицу
            for (int i = 0, k = 0; (i < max); i++)
            {
                for (int j = 0; (j < key_text.Length); j++)
                {

                    if ((k == original_text.Length)|| (k > original_text.Length))
                    {
                        table[j,i] = " ";
                    }
                    else
                    {
                        
                        table[j, i] = original_text[k].ToString();
                    }
                    k++;

                }
            }
            //цикл для возврата букв
            for (int i = 0; (i < key_text.Length); i++)
            {
                for (int j = 0; (j < max); j++)
                {
                    new_text += table[i_key[i], j];
                }
            }
            return new_text;

        }
    }
}

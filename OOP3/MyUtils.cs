﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    public static class MyUtils
    {
        public static int TongTu1ToN(this int n)//this là để mở rộng cho kiểu int, tức là khi gọi hàm này thì sẽ gọi trên biến kiểu int
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static int Cong(this int a, int b)//vì hàm này thuộc đối số a nên suy ra hàm này chỉ có 1 hàm 
        {
            return a + b;
        }

        public static void TaoMang(this int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100); // Tạo số ngẫu nhiên từ 0 đến 99
            }
        }

        public static void XuatMang(this int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
        }

        public static void SapXepMangTangDan(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        // Hoán đổi
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        public static int[] SapXepMangGiamDan(this int[] arr)
        {
            return arr = arr.OrderByDescending(x => x).ToArray(); // Sử dụng LINQ để sắp xếp mảng theo thứ tự giảm dần // ko chạy đc 
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        if (arr[i] < arr[j])
            //        {
            //            // Hoán đổi
            //            int temp = arr[i];
            //            arr[i] = arr[j];
            //            arr[j] = temp;
            //        }
            //    }
            //}
        }
    }
}

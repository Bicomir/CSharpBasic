using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Index
{
    class Program
    {
        // 属性(property)的书写
        public string _name;
        /*
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }

        }
        */
        public string Name { set; get; }  // C#3.0及以上可简写为此形式

        /*
            上面写法等同于是在编译器里处理为产生方法：
            void set_Name(string value );
            string get_Name();

            属性与字段相比：
            属性实际上是方法，故此属性可以具有以下优点：
            1.可以只读或只写：只有get或set；
            2.可以进行有效值检查：if ...；
            3.可以是计算得到的数据；
            4.可以定义为抽象属性；
        */

        /*
        索引器(Indexer)
        修饰符 类型名 this[ 参数列表 ]
        {
            set
            {

            }
            get
            {

            }
        } 
         // 使用索引
         对象名[参数]

        编译器自动产生两个方法，以供调用：
        T get_Item(P);
        void set_Item(P,T value);
        */

        class IndexRecord
        {
            private string[] data = new string[6];
            private string[] keys =
            {
                "Author", "Publisher", "Title",
                "Subject", "ISBN", "Comments"
            };
            public string this[ int idx ]
            {
                set
                {
                    if( idx >= 0 && idx < data.Length )
                    {
                        data[idx] = value;
                    }
                }
                get
                {
                    if( idx >= 0 && idx <= data.Length)
                    {
                        return data[idx];
                    }
                    return null;
                }
            }

            public string this[ string key ]
            {
                set
                {
                    int idx = FindKey(key);
                    this[idx] = value;
                }
                get
                {
                    return this[FindKey(key)];
                }
            }
            private int FindKey( string key )
            {
                for(int i=0; i<keys.Length; i++)
                {
                    if (keys[i] == key) return i;
                }
                return -1;
            }
        }

        static void Main(string[] args)
        {
            IndexRecord record = new IndexRecord();
            record[0] = "马克-吐温";
            record[1] = "Crox出版公司";
            record[2] = "汤姆-索亚历险记";
            Console.WriteLine(record["Title"]);
            Console.WriteLine(record["Author"]);
            Console.WriteLine(record["Publisher"]);

            Console.ReadKey();


            /*
             属性与索引的比较：
             属性
             1.通过名称标识；
             2.通过简单名称来访问；
             3.可以用static来修饰；
             4.属性的get访问器没有参数；
             5.属性的set访问器包含隐式value参数;

            索引器
            1.通过参数列表进行标识；
            2.通过[]运算符来访问；
            3.不能用static来修饰；
            4.索引的get访问器具有与索引相同的参数列表；
            5.除了有value参数外，索引的set访问器还具有与索引相同的与参数列表；

             */
        }
    }

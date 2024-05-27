

namespace TestTaskNameSpace
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //--.
    public class Test
    {


        //---------------------------------------------------
        //--.
        static int inputIntValue()
        {
            int ret;
            
            while (true)
            {

                try
                {
                    ret = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный формат ввода. Повторите ввод. ");
                }
            }

            return ret;
        }


        //---------------------------------------------------
        //--.
        static void funcCreateArray(ref int [] mas)
        {
            int size;
            //--.
            Console.WriteLine("Задайте размер одномерного массива mas : ");
            while( true )
            {
                size = inputIntValue();

                if( size > 0 )
                {
                    break;
                }

                Console.WriteLine("Размер массива не может быть нулём или отрицательным числом, повторите ввод... ");
            }

            mas = new int[size];
        }

        //---------------------------------------------------
        //--.
        static void inputArrayValues(int[] mas)
        {

            for(int i=0; i<mas.Length; i++)
            {
                Console.WriteLine($"Введите целое (int) значение для элемента mas[{i}] :  ");
                mas[i] = inputIntValue();
            }
        }

        //---------------------------------------------------
        //--.
        static int sumArray(int[] mas)
        {
            int ret = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                ret += mas[i];
            }

            return ret;
        }

        //---------------------------------------------------
        //--.
        static (int pos, int neg) sumPositiveNegative( int[] mas )
        {
            int pos = 0, neg = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                if( mas[i] > 0 )
                    pos += mas[i];
                if (mas[i] < 0)
                    neg += mas[i];

            }

            return (pos , neg);
        }

        //---------------------------------------------------
        //--.
        static (int odd, int even) sumOddEvenElements(int[] mas)
        {
            int odd = 0, even = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                if ( i%2 == 0 )
                    even += mas[i];
                else
                    odd += mas[i];

            }

            return (odd, even);
        }

        //---------------------------------------------------
        //--.
        static (uint minIdx, uint maxIdx) findMinMaxIdx(int[] mas)
        {
            uint minIdx = 0, maxIdx = 0;


            var min = int.MaxValue;
            var max = int.MinValue;

            for(int i=0; i< mas.Length; i++)
            {
                if( mas[i] < min )
                {
                    min = mas[i];
                    minIdx = (uint)i;
                }

                if (mas[i] > max)
                {
                    max = mas[i];
                    maxIdx = (uint)i;
                }
            }


            return (minIdx, maxIdx);
        }


        //---------------------------------------------------
        //--.
        static (bool valid, int mulVal) multiplyMinMaxIdx(int[] mas, uint minIdx, uint maxIdx)
        {
            bool valid = true;
            int mulVal = 0;

            int startEl = (int)minIdx;
            //int stopEl = (int)maxIdx;

            int numElements = (int)maxIdx - (int)minIdx;
            
            if (numElements < 0)
            {
                //--.
                numElements = -numElements;
                //--.
                startEl = (int)maxIdx;
                //stopEl = (int)minIdx;
            }

            startEl = +1;
            if (numElements == 0)
            {
                valid = false;
                return (valid, mulVal);
            }

            //--.
            mulVal = mas[startEl];
            startEl++;
            for (int i = startEl; i < numElements; i++)
            {
                mulVal *= mas[i];
            }

            return (valid, mulVal);
        }


        //---------------------------------------------------
        //---------------------------------------------------
        //--.
        public static void Main()
        {
            int [] mas = {};


            //--. Создаём массив: 1.Выделение памяти; 2.Ввод размера массива.  
            funcCreateArray(ref mas);

            //--. Заполненяем массив с консоли: 3.Заполнение массива данными
            inputArrayValues(mas);
            for (int i = 0; i < mas.Length; i++)
                Console.WriteLine("значение для элемента mas{0}: {1}  ", i, mas[i]);

            //--. Определение суммы всех элементов массива
            int iSummVal = sumArray( mas );
            Console.WriteLine("Сумма всех элементов массива mas[] равна: {0}", iSummVal);

            //--. Вычисление среднего значения
            Console.WriteLine("Среднее значение всех элементов массива mas[] равно: {0}", iSummVal/mas.Length);

            //--. Расчёт суммы отрицательных и положительных элементов
            var sumPosNegRes = sumPositiveNegative(mas);
            Console.WriteLine("Cумма всех отрицательных элементов массива mas[] равна: {0}", sumPosNegRes.neg);
            Console.WriteLine("Cумма всех положительных элементов массива mas[] равна: {0}", sumPosNegRes.pos);


            //--. Доп.Зад.: реализовать метода расчёта суммы элементов с нечётными и чётными номерами
            var sumOddEvenRes  = sumOddEvenElements(mas);
            Console.WriteLine("Cумма всех нечётных элементов массива mas[] равна: {0}", sumOddEvenRes.odd);
            Console.WriteLine("Cумма всех чётных элементов массива mas[] равна: {0}", sumOddEvenRes.even);

            //--. Найти максимальный и/или минимальный элементы массива и вывести их индексы
            var findMMres = findMinMaxIdx(mas);
            Console.WriteLine("Индекс максимального элементов массива mas[] равен: {0}", findMMres.maxIdx);
            Console.WriteLine("Индекс минимального элементов массива mas[] равен: {0}", findMMres.minIdx);

            //--. Рассчитать произведение элементов массива, расположенных между максимальным и минимальным элементами
            var mulRes = multiplyMinMaxIdx( mas, findMMres.minIdx, findMMres.maxIdx );
            if(mulRes.valid)
                Console.WriteLine("Произведение между значениями, расположенными между максимальным и минимальным элементом массива mas[] равно: {0}", mulRes.mulVal);
            else
                Console.WriteLine("Индексы минимального и максимального элемента массива mas[] расположены рядом");








        }
    }
}
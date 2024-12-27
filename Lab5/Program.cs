using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        answer = Combinations(n, k);
        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    public long Combinations(int n, int k)
    {
        if (k == 0 || n == 0) return 0;
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public int Factorial(int n)
    {
        if (n == 0) return 0;
        int res = 1;
        for (int i = 1; i <= n; i++)
        {
            res *= i;
        }
        return res;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a1 = first[0];
        double b1 = first[1];
        double c1 = first[2];
        double a2 = second[0];
        double b2 = second[1];
        double c2 = second[2];

        if (Error(a1, b1, c1) == false || Error(a2, b2, c2) == false || first.Length != 3 || second.Length != 3)
        {
            answer = -1;
        }
        else
        {
            if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2))
            {
                answer = 1;
            }
            else if (GeronArea(a1, b1, c1) < GeronArea(a2, b2, c2))
            {
                answer = 2;
            }
            else if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2))
            {
                answer = 0;
            }
            else
            {
                answer = -1;
            }
        }
       

        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public bool Error(double a, double b, double c)
    {
        if ((a < b + c) && (b < a + c) && (c < a + b))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            answer = 1;
        }
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time))
        {
            answer = 2;
        }
        else if (GetDistance(v1, a1, time) == GetDistance(v2, a2, time))
        {
            answer = 0;
        }
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public double GetDistance(double v, double a, double t)
    {
        return (v * t + (a * t * t) / 2);
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int t = 1;
        while (GetDistance(v2, a2, t) != GetDistance(v1, a1, t))
        {
            t++;
        }
        answer = t;
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int row1, col1, row2, col2;
        if (A.GetLength(0) != 5 || A.GetLength(1) != 6 || B.GetLength(0) != 3 || B.GetLength(1) != 5)
        {
            return;
        }
        FindMaxIndex(A, out row1, out col1);
        FindMaxIndex(B, out row2, out col2);
        int temp = A[row1, col1];
        A[row1, col1] = B[row2, col2];
        B[row2, col2] = temp;

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        int maxel = matrix[0, 0];
        row = 0;
        col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxel)
                {
                    maxel = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        if (B.GetLength(0) != B.GetLength(1) || B.GetLength(1) != 5 || C.GetLength(0) != C.GetLength(1) || C.GetLength(1) != 6)
        {
            return;
        }
        int[] index1 = FindDiagonalMaxIndex(B);
        int[] index2 = FindDiagonalMaxIndex(C);
        B = DeleteRow(B, index1[0]);
        C = DeleteRow(C, index2[0]);
        
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    public int[] FindDiagonalMaxIndex(int[,] matrix)
    {
        int[] res = new int[2] { 0, 0 };
        int maxel = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == i || j == matrix.GetLength(1) - i - 1)
                {
                    if (maxel < matrix[i, j])
                    {
                        maxel = matrix[i, j];
                        res[0] = i;
                        res[1] = j;
                    }
                }
            }
        }
        return res;
    }

    public int[,] DeleteRow(int[,] matrix, int row)
    {
        int[,] NewArr = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < NewArr.GetLength(1); i++)
        {
            for (int j = 0; j < NewArr.GetLength(0); j++)
            {
                if (j < row)
                {
                    NewArr[j, i] = matrix[j, i];
                }
                else
                {
                    NewArr[j, i] = matrix[j + 1, i];
                }
            }
        }
        return NewArr;
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6)
        {
            return;
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
       
        int row1, row2;
        FindMaxInColimn(A, 0, out row1);
        FindMaxInColimn(B, 0, out row2);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[row1, i];
            A[row1, i] = B[row2, i];
            B[row2, i] = temp;
        }
        // end
    }
    static void FindMaxInColimn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        rowIndex = 0;
        int maxel = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > maxel)
            {
                rowIndex = i;
                maxel = matrix[i, columnIndex];
            }
        }
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        if (B.GetLength(0) != 4 || B.GetLength(1) != 5 || C.GetLength(0) != 5 || C.GetLength(1) != 6)
        {
            return;
        }
        int maxk = 0;
        int rowind = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (CountRowPositive(B, i) > maxk)
            {
                maxk = CountRowPositive(B, i);
                rowind = i;
            }
        }

        int maxk1 = 0;
        int colInd = 0;
        for (int i = 0; i < C.GetLength(1); i++)
        {
            if (CountColumnPositive(C, i) > maxk1)
            {
                maxk1 = CountColumnPositive(C, i);
                colInd = i;
            }
        }
        int[] ArrC = new int[C.GetLength(0)];
        for (int i = 0; i < C.GetLength(0); i++)
        {
            ArrC[i] = C[i, colInd];
        }
        int[,] NewArr = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0; i <= rowind; i++)
        {
            for (int j = 0; j < NewArr.GetLength(1); j++)
            {
                NewArr[i, j] = B[i, j];
            }
        }
        for (int i = 0; i < NewArr.GetLength(1); i++)
        {
            NewArr[rowind + 1, i] = ArrC[i];
        }
        for (int i = rowind + 1; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                NewArr[i + 1, j] = B[i, j];
            }
        }
        B = NewArr;
        // create and use CountRowPositive(matrix, rowIndex);
        
        // end
    }
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] > 0)
            {
                count++;
            }
        }
        return count;
    }
    // create and use CountColumnPositive(matrix, colIndex);
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0)
            {
                count++;
            }
        }
        return count;
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);
        // code here
        if (A.GetLength(0) != 7 || A.GetLength(1) != 4 || C.GetLength(0) != 6 || C.GetLength(1) != 5)
        {
            return null;
        }

        // create and use SumPositiveElementsInColumns(matrix);
       
        int[] sumA = SumPositiveElementsInColumns(A);
        int[] sumC = SumPositiveElementsInColumns(C);
        int[] ans = new int[sumA.Length + sumC.Length];
        for (int i = 0; i < sumA.Length; i++)
        {
            ans[i] = sumA[i];
        }
        for (int i = 0; i < sumC.Length; i++)
        {
            ans[i + sumA.Length] = sumC[i];
        }
        // end
        answer = ans;
        return answer;
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] res = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] > 0)
                {
                    res[i] += matrix[j, i];
                }
            }
        }
        return res;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) == 0 || B.GetLength(0) == 0)
        {
            return;
        }
        int row1, col1, row2, col2;
        FindMaxIndex(A, out row1, out col1);
        FindMaxIndex(B, out row2, out col2);
        int temp = A[row1, col1];
        A[row1, col1] = B[row2, col2];
        B[row2, col2] = temp;
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) == 0)
        {
            return;
        }
        int row, col, row1, col1;
        FindMaxIndex(matrix, out row, out col);
        FindMinIndex(matrix, out row1, out col1);
        matrix = RemoveRow(matrix, row);
        if (row < row1)
        {
            matrix = RemoveRow(matrix, row1 - 1);
        }
        else if (row > row1)
        {
            matrix = RemoveRow(matrix, row1);
        }

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    public int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] NewM = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < NewM.GetLength(0); i++)
        {
            for (int j = 0; j < NewM.GetLength(1); j++)
            {
                if (i < rowIndex)
                {
                    NewM[i, j] = matrix[i, j];
                }
                else
                {
                    NewM[i, j] = matrix[i + 1, j];
                }
            }
        }
        return NewM;
    }

    public void FindMinIndex(int[,] matrix, out int row, out int col)
    {
        int minel = matrix[0, 0];
        row = 0;
        col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < minel)
                {
                    minel = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;
        if (A.GetLength(0) == 0 || B.GetLength(0) == 0 || C.GetLength(0) == 0)
        {
            answer = 0;
        }
        // code here
        double[] Arr = new double[3];
        Arr[0] = GetAverageWithoutMinMax(A);
        Arr[1] = GetAverageWithoutMinMax(B);
        Arr[2] = GetAverageWithoutMinMax(C);
        if (Arr[0] < Arr[1] && Arr[1] < Arr[2])
        {
            answer = 1;
        }
        else if(Arr[0] > Arr[1] && Arr[1] > Arr[2])
        {
            answer = -1;
        }
        else
        {
            answer = 0;
        }
        // create and use GetAverageWithoutMinMax(matrix);
   
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        int row1, col1, row2, col2;
        FindMaxIndex(matrix, out row1, out col1);
        FindMinIndex(matrix, out row2, out col2);
        double sum = 0;
        int k = 0;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j] != matrix[row1, col1] && matrix[i, j] != matrix[row2, col2])
                {
                    sum += matrix[i, j];
                    k++;
                }
            }
        }
        return sum / k;
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        if(A.Length == 0 || B.Length == 0)
        {
            return;
        }
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        // create and use SortRowsByMaxElement(matrix);
        static void SortRowsByMaxElement(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int maxJ = matrix[j, 0];
                    for (int k = 1; k < cols; k++)
                    {
                        if (matrix[j, k] > maxJ)
                        {
                            maxJ = matrix[j, k];
                        }
                    }
                    int maxJ1 = matrix[j + 1, 0];
                    for (int k = 1; k < cols; k++)
                    {
                        if (matrix[j + 1, k] > maxJ1)
                        {
                            maxJ1 = matrix[j + 1, k];
                        }
                    }

                    if (maxJ < maxJ1)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }
        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix = RemoveRow(matrix, i);
                    break;
                }
            }
        }
        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // create and use CreateArrayFromMins(matrix);
        static int[] CreateArrayFromMins(int[,] matrix)
        {
            int[] Arr = new int[matrix.GetLength(0)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int minel = matrix[i, i];
                for(int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minel)
                    {
                        minel = matrix[i, j];
                    }
                }
                Arr[i] = minel;
            }
            return Arr;
        }
        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        if (A.GetLength(0) * A.GetLength(1) == 0|| B.GetLength(0)*B.GetLength(1) == 5)
        {
            return;
        }
        A = MatrixValuesChange(A);
        B = MatrixValuesChange(B);

        static double[,] MatrixValuesChange(double[,] matrix)
        {
            double[] NewArr = new double[matrix.GetLength(0) * matrix.GetLength(1)];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    NewArr[index++] = matrix[i, j];
                }
            }

            for (int i = 0; i < NewArr.Length - 1; i++)
            {
                for (int j = 0; j < NewArr.Length - i - 1; j++)
                {
                    if (NewArr[j] > NewArr[j + 1])
                    {
                        double temp = NewArr[j];
                        NewArr[j] = NewArr[j + 1];
                        NewArr[j + 1] = temp;
                    }
                }
            }
            
            for (int i = 0; i < matrix.GetLength(0);  i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == NewArr[NewArr.Length-1] || matrix[i, j] == NewArr[NewArr.Length-2] || matrix[i, j] == NewArr[NewArr.Length - 3] || matrix[i, j] == NewArr[NewArr.Length - 4] || matrix[i,j] == NewArr[NewArr.Length - 5])
                    {
                        if (matrix[i,j] > 0)
                        {
                            matrix[i, j] *= 2;
                        }
                        else
                        {
                            matrix[i, j] /= 2;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] *= 2;
                        }
                        else
                        {
                            matrix[i, j] /= 2;
                        }
                    }
                }
            }
            return matrix;
        }
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;
        if(A.GetLength(0) == 0 || B.GetLength(0)==0 || A.GetLength(1) == 0 || B.GetLength(1) == 0)
        {
            return;
        }
        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        static int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int maxcount = CountNegativeInRow(matrix, 0);
            int row = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(CountNegativeInRow(matrix, i) > maxcount)
                {
                    maxcount = CountNegativeInRow(matrix, i);
                    row = i;
                }
            }
            return row;

            static int CountNegativeInRow(int[,] matrix, int rowIndex)
            {
                int count = 0;
                for(int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[rowIndex, i] < 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) == 0 || A.GetLength(1) == 0 || B.GetLength(0) == 0 || B.GetLength(1) == 0)
        {
            return;
        }

        A = ReplaceMaxElementEven(A);
        A = ReplaceMaxElementOdd(A);
        B = ReplaceMaxElementEven(B);
        B = ReplaceMaxElementOdd(B);

       
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }
    public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        columnIndex = 0;
        int maxel = matrix[rowIndex, 0];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] > maxel)
            {
                maxel = matrix[rowIndex, i];
                columnIndex = i;
            }
        }
    }

    public int[,] ReplaceMaxElementOdd(int[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            if ((i+1) % 2 != 0)
            {
                int column;
                FindRowMaxIndex(matrix, i, out column);
                matrix[i, column] *= column+1;
            }
        }
        return matrix;
    }

    public int[,] ReplaceMaxElementEven(int[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            if((i+1)%2 == 0)
            {
                int column;
                FindRowMaxIndex(matrix, i, out column);
                matrix[i, column] = 0;
            }
        }
        return matrix;
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public delegate double SumFunction(double x, int i);
    public delegate double YFunction(double x);

    public double Sum1(double x, int i)
    {
        return Math.Cos(i * x) / Factorial(i);
    }

    public double Sum2(double x, int i)
    {
        return Sign(i) * Math.Cos(i * x) / (i * i);
    }

    public double YFunc1(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public double YFunc2(double x)
    {
        return (x*x - Math.PI*Math.PI/3)/4;
    }

    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double start)
    {

        int steps = (int)((b - a) / h) + 1;
        double[,] Ans = new double[steps, 2];

        for (int i = 0; i < steps; i++)
        {
            double x = a + i * h; 
            double sum = start;
            int k = 1;

            while (Math.Abs(sFunction(x, k)) > 0.0001)
            {
                sum += sFunction(x, k);
                k++;
            }

            Ans[i, 0] = sum; 
            Ans[i, 1] = yFunction(x); 
        }

        return Ans;
    }
    public int Sign(int n)
    {
        if (n % 2 == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = GetSumAndY(Sum1, YFunc1, a1, b1, h1, 1);
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = GetSumAndY(Sum2, YFunc2, a2, b2, h2, 0);
        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public delegate double[] SwapDirection(double[] array);

    public double[] SwapRight(double[] array)
    {
        for(int i = array.Length-1; i > 0; i-=2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
        return array;
    }
    public double[] SwapLeft(double[] array)
    {
        int k = -1;
        for (int i = 0; i < array.Length; i+=2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
        return array;
    }

    public double SrZnach(double[] array)
    {
        double sum = 0;
        for(int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }

    public double GetSum(double[] array)
    {
        double sum = 0;
        for (int i = 1; i < array.Length; i ++)
        {
            if (i % 2 != 0)
            {
                sum += array[i];
            }
        }
        return sum;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)
        SwapDirection swapper;
        if (array[0] > SrZnach(array))
        {
            swapper = SwapLeft;
        }
        else
        {
            swapper = SwapRight;
        }
        swapper(array);
        answer = GetSum(array);
        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }
    public double Function1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double Function2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public int CountSignFlips(YFunction func, double a, double b, double h)
    {
        int signChanges = 0;
        double previousValue = func(a);
        double currentValue;

        for (double x = a + h; x <= b; x += h)
        {

            currentValue = func(x);
            if (previousValue * currentValue < 0)
            {
                signChanges++;
            }
            if (currentValue != 0)
            {
                previousValue = currentValue;
            }


        }
        return signChanges;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        double a1 = 0;
        double b1 = 2;
        double h1 = 0.1;
        func1 = CountSignFlips(Function1, a1, b1, h1);

        double a2 = -1;
        double b2 = 1;
        double h2 = 0.2;

        func2 = CountSignFlips(Function1, a2, b2, h2);
        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }


    public delegate int CountPositive(int[,] matrix, int index);

    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        int maxk = 0;
        int rowind = 0;
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            if (CountRow(matrixB, i) > maxk)
            {
                maxk = CountRow(matrixB, i);
                rowind = i;
            }
        }

        int maxk1 = 0;
        int colInd = 0;
        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            if (CountColumn(matrixC, i) > maxk1)
            {
                maxk1 = CountColumn(matrixC, i);
                colInd = i;
            }
        }
        int[] ArrC = new int[matrixC.GetLength(0)];
        for (int i = 0; i < matrixC.GetLength(0); i++)
        {
            ArrC[i] = matrixC[i, colInd];
        }
        int[,] NewArr = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
        for (int i = 0; i <= rowind; i++)
        {
            for (int j = 0; j < NewArr.GetLength(1); j++)
            {
                NewArr[i, j] = matrixB[i, j];
            }
        }
        for (int i = 0; i < NewArr.GetLength(1); i++)
        {
            NewArr[rowind + 1, i] = ArrC[i];
        }
        for (int i = rowind + 1; i < matrixB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                NewArr[i + 1, j] = matrixB[i, j];
            }
        }
        return NewArr;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }
    
    public void Task_3_10(ref int[,] matrix)
    {


        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public delegate void FindElementDelegate(int[,] matrix, out int row, out int col);

    public int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int row, col, row1, col1;
        FindMaxIndex(matrix, out row, out col);
        FindMinIndex(matrix, out row1, out col1);
        matrix = RemoveRow(matrix, row);
        if (row < row1)
        {
            matrix = RemoveRow(matrix, row1 - 1);
        }
        else if (row > row1)
        {
            matrix = RemoveRow(matrix, row1);
        }
        return matrix;
    }

    
    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        matrix = RemoveRows(matrix, FindMaxIndex, FindMinIndex);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int[,] ReplaceMaxElement(int[,] matrix);

    public int[,] EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        matrix = replaceMaxElementOdd(matrix);
        matrix = replaceMaxElementEven(matrix);
        return matrix;
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here
        A = EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        B = EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}

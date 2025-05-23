int sum (params int[] arr)
{
    int s = 0;
    foreach(int x in arr)
    {
        s = s + x;
        return s
    }
}
//từ khoá params nó sẽ tự biến đối số thành linh động -> nó nhận bao nhiêu phần tử  đối số của mảng cũng được -> nhận bao nhiêu cũng được 
//-> muốn nhận bao nhiêu đối số cũng được

int s0 = sum();
int s1 = sum(100);
int s2 = sum(100, 200);
int sn = sum(4, 5, 6, 6, 100, 2, 3, 123, 123, 123, 5, 4, 2, 1, 2, 4, 5);


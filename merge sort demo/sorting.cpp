#include <vector>
#include <iostream>

using namespace std;

template <typename C>
void insertionSort(vector<C>& v)
{   
   for (int i = 1; i < v.size(); i++)
   {
        C temp = v[i];
        int j = i;
        while (j > 0 && v[j - 1] > temp) 
        {
          v[j] = v[j - 1];
          --j;
        }
        v[j] = temp;
    }
}

template <typename C>
void selectionSort(vector<C>& v)
{   
   for (int i = 0; i < v.size() - 1; i++)
   {
        int min = i;
        for (int j = i + 1; j < v.size(); j++) 
          if (v[j] < v[min]) 
            min = j;
        if (min != i) 
        {
          C temp = v[min];
          v[min] = v[i];
          v[i] = temp;
        }
   }
}

template <typename C>
void bubbleSort(vector<C>& v)
{
    for (int i = 0; i < v.size() - 1; i++)
    {
      for (int j = 0; j < v.size() - i - 1; j++)
        if (v[j] > v[j + 1])
        {
      	  C temp = v[j];
      	  v[j] = v[j + 1];
      	  v[j + 1] = temp;	
        }
    }
}

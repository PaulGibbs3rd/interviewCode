#include <vector>
#include <iostream>
#include "sorting.cpp"
#include "MergeSort.cpp"
#include "bst.cpp"
#include <fstream>

using namespace std;

template <typename C>
void print(vector<C> v)
{
	for(int i = 0; i < v.size(); i++)
		cout << v[i] << " ";
	cout << endl;
}

int main()
{


	vector<int> v;
	BinarySearchTree<int> bst;

	ifstream input("sort.txt");
	int number;
	while (input >> number)
	{	
   		v.push_back(number);
   		bst.insert(number);
	}
	input.close();
	 
	mergeSort(v);
	print(v); 
	
	bst.printBST();

	return 0;
}

#include "bst.cpp"

int main()
{
	BinarySearchTree<int> bst;
	int x = 0;
	
	cout << "insert: " << endl;
	cin >> x;
	while (x != 0)
	{
		bst.insert(x);
		cin >> x;
	}
	
	bst.printBST();

	int k1 = 0, k2 = 0;
	cout << "Please enter the range: ";
	cin >> k1 >> k2;
	bst.printRange(k1, k2);
	
	cout << "remove: " << endl;
	cin >> x;
	while (x != 0)
	{
		bst.remove(x);
		cin >> x;
	}	
	
	bst.printBST();

}
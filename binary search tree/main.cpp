#include "treeTraversal.cpp"

BinaryNode<char>* create_binary_tree()
{
	BinaryNode<char>* node_A = new BinaryNode<char>('A');
	BinaryNode<char>* node_B = new BinaryNode<char>('B');
	BinaryNode<char>* node_C = new BinaryNode<char>('C'); 	
	BinaryNode<char>* node_D = new BinaryNode<char>('D');
	BinaryNode<char>* node_E = new BinaryNode<char>('E');

  	node_A->left = node_B;
  	node_A->right = node_C;
  
  	node_B->left = node_D;
  	node_B->right = node_E;


    
	return node_A;
}

int main()
{
	BinaryNode<char>* root = create_binary_tree();
	cout << "preorder: ";
	preorder(root);
	cout << endl;
	cout << "inorder: ";
	inorder(root);
	cout << endl;
	cout << "postorder: ";
	postorder(root);
	cout << endl;
}

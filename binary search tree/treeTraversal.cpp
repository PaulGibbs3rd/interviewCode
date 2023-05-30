// funcs.cpp
#include<iostream>
using namespace std;

template <typename T>
struct BinaryNode
{
	T element;
	BinaryNode* left;
	BinaryNode* right;
	  
	BinaryNode(const T & x = T()): element(x), left(nullptr), right(nullptr)
	{}	  
};
template <typename T>
void preorder(const BinaryNode<T>* root)
{
	if (root != nullptr)
	{
		cout << root->element << " -> ";
		preorder(root->left);
		preorder(root->right);			
	}
}
template <typename T>
void inorder(const BinaryNode<T>* root)
{
	if (root != nullptr)
	{
		inorder(root->left);
		cout << root->element << " -> ";
		inorder(root->right);			
	}
}
template <typename T>
void postorder(const BinaryNode<T>* root)
{
	if (root != nullptr)
	{
		postorder(root->left);
		postorder(root->right);			
		cout << root->element << " -> ";
	}
	
}
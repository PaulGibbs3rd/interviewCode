#ifndef LL
#define LL
#include <iostream>
using namespace std;

template <typename T>
class LinkedList 
{
 
  public:
  // Default constructor
  LinkedList(): size(0)
  {
	head = new NodeType();
  }
  
  //Destructor
  ~LinkedList()
  {
	clear();
  }

  bool empty( ) const
  {
	return get_size() == 0; 
  } 
  
  // Returns the list to the empty state.  
  void clear()
  {
	while (!empty())
	{
		pop_front();
	}
  }

  // Returns the number of items in the list.
  int get_size() const
  {
	return size;
  }

  // Checks if item is in the list. 
  bool find(const T& item) const
  {
	NodeType* ptr = head->next;
	while (ptr->data != item && ptr != nullptr)
	{
		ptr = ptr->next;
	}
	if (ptr->data == item)
		return true;
	else
		return false;  	
  }

  // Inserts item at the front.
  void push_front(const T& item)
  {
	NodeType* ptr = new NodeType(item);

	ptr->next = head->next;
	head->next = ptr;	
	++size;   	
  }
  
  // Removes the first item.
  void pop_front()
  {
	if (head->next != nullptr)
	{
		NodeType* ptr = head->next;
		head->next = ptr->next;
		delete ptr;
		--size;
	}
	
  }

  // Prints the list.
  void print() const
  {
	NodeType* ptr = head->next;
	while (ptr != nullptr)
	{
		cout << ptr->data <<" | ";
		ptr = ptr->next;
	}  
        cout << endl;
 	
  }
  
  private:
  struct NodeType
  {
	  T data;
	  NodeType* next;
	  
	  NodeType(): data(), next(nullptr)
	  {}

	  NodeType(const T& d): data(d), next(nullptr)
	  {}
  };
  int size;	// the size of the linked list.
  NodeType* head;	// points to the header node.
};

#endif



#include <string>
#include "Employee.cpp"

// Application of circular queue
//#include "CircularQueue.cpp"
// Application of singly linked queue
//#include "LinkedQueue.cpp" 
// Application of doubly linked queue
#include "DoublyLinkedQueue.cpp"


int main() 
{ 
	Queue<int> intQue;

	int x = 0, k = 0;

	cout << "Enqueue positive numbers (enter -1 to stop): ";
	cin >> x;
	while (x != -1)
	{  
		intQue.enqueue(x);
		cin >> x;		
	}
	cout << endl<< "print queue: ";
	intQue.print(); 

	cout << "How many numbers to be removed from queue: ";
	cin >> k;
	cout << endl;
	for (int i = 0; i < k; i++)
	{
		intQue.dequeue();
	}
	cout << endl << "print queue: ";
	intQue.print();
	
	
	Queue<string> stringQue;

	string s;

	cout << "Enqueue string (enter exit to stop): ";
	cin >> s;
	while (s != "exit")
	{  
		stringQue.enqueue(s);
		cin >> s;		
	}
	cout << endl<< "print queue: ";
	stringQue.print(); 
	
	cout << "How many strings to be removed from queue: ";
	cin >> k;
	
	for (int i = 1; i <= k; i++)
	{
		stringQue.dequeue();
	}
	cout << endl << "print queue: ";
	stringQue.print(); 



	Queue<Employee> emplQue;

	string name, dept;
	int id = 0;

	cout << "Enqueue employee name, id, dept(enter id 0 to stop): ";
	cin >> name >> id >> dept;
	while (id != 0)
	{  
		Employee e(name, id, dept);
		emplQue.enqueue(e);
		cout << "Enqueue employee name, id, dept(enter id 0 to stop): ";
		cin >> name >> id >> dept;		
	}
	cout << endl<< "print queue: ";
	emplQue.print(); 
	
	cout << "How many employees to be removed from queue: ";
	cin >> k;
	
	for (int i = 1; i <= k; i++)
	{
		emplQue.dequeue();
	}
	cout << endl << "print queue: ";
	emplQue.print(); 


  	
	return 0;
}


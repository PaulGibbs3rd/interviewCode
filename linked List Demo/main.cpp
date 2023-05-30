#include "Employee.cpp"
#include "LinkedList.cpp"

int main()
{
	LinkedList<int> intll;
	int x = 0;
	cout << "Create a list of integers: ";
	cin >> x;
	while (x != -1)
	{
		intll.push_front(x);
		cin >> x;
	}
		
        cout << "The size of the int linked list is " << intll.get_size() << endl;
	cout << "The linked list is: ";
	intll.print();

	cout << "Enter the key: ";
	cin >> x;
	cout << "Is "<< x <<" in the list? " << intll.find(x) << endl;	
	
	cout << "How many integers you want to remove? ";
	cin >> x;	
	for (int i = 0; i < x; i++)
		intll.pop_front();

	cout << "The linked list is: ";
	intll.print();
	cout << endl;

	
	LinkedList<string> strll;
	string s;
	cout << "Create a list of strings (stop adding when entering \"exit\" ): ";
	cin >> s;
	while (s != "exit")
	{
		strll.push_front(s);
		cin >> s;
	}

        cout << "The size of the linked list is " << strll.get_size() << endl;
	cout << "The linked list is: ";
	strll.print();
	cout << endl;
	
	int k = 0;
	cout << "enter the number of elements to be removed from the string linked list: ";
	cin >> k;
	for (int i = 0; i < k; i++)
	{
		strll.pop_front();
	}
	cout << "The linked list is: ";
	strll.print();
	cout << endl;

	LinkedList<Employee> emplll;
	string name, dept;
	int id = 0;
	cout << "Create a list of employees: " << endl;
	cout << "Input name, id, and department name (stop adding when entering id 0): ";
	cin >> name >> id >> dept;
	while (id != 0 )
	{
		Employee e(name, id, dept);
		emplll.push_front(e);
		cout << "Input name, id, and department name (stop adding when entering id 0): ";
		cin >> name >> id >> dept;
	}
        cout << "The size of the employee linked list is " << emplll.get_size() << endl;

	cout << "The linked list is: ";
	emplll.print();
	cout << endl;
	
	k = 0;
	cout << "enter the number of elements to be removed from the linked list: ";
	cin >> k;
	for (int i = 0; i < k; i++)
	{
		emplll.pop_front();
	}
	cout << "The linked list is: ";
	emplll.print();
	cout << endl;

}
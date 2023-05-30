
#include <string>
#include "BinaryHeap.cpp"

// Test program
int main( )
{
    BinaryHeap<int> printQueue;
    int x;
    cout << "Enter the priority of print job: ";
    cin >> x;
    while( x != 0)
    {
        printQueue.insert( x );
        cout << "Enter the priority of print job: ";
        cin >> x;
    }
    printQueue.printJobs();
    cout << endl;
		
    cout << "The number of jobs to be removed: ";
    cin >> x;
    for (int i = 0; i < x; i++)
    {
    	printQueue.deleteMin();
    }
    printQueue.printJobs();  
    cout << endl;
    return 0;
}

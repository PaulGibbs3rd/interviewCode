#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

void solve(int i);
void print();
bool okay(int i);
int a[11][11];
vector<int> s(11);

int main() {

	ifstream mfile;
	mfile.open("a.txt");
	for (int i = 1; i <= 10; i++) {
		for (int j = 1; j <= 10; j++) {
			mfile >> a[i][j];
			cout << a[i][j] << " ";
		}
		cout << endl;
	}

	solve(2);
	print();
	
	return 0;
}

void solve(int i) {
	if (i == 11) {
		if (a[s[10]][s[1]] == 1) {
			print();
			return;
		}
		else {
			return;
		}
	}
	for (int j = 2; j <= 10; j++) {
		s[i] = j;
		if (okay(i)) {
			solve(++i);
		}
	}
	return;
}

void print() {
	for (int l = 1; l <= 10; l++) {
		cout << s[l] << " ";
	}
	cout << endl;
	return;
}

bool okay(int i) {
	for (int j = 1; j <= 10; j++) {
		if (s[i] == s[j]) {
			return false;
		}
		if (a[s[i - 1]][s[i]] == 0) {
			return false;
		}

	}
	return true;
}
/*Output:
1 0 0 1 1 0 0 1 1 1
0 1 1 0 1 1 1 0 1 0
0 1 1 0 1 0 1 1 1 1
1 0 0 1 1 0 0 1 0 0
1 1 1 1 1 1 1 0 1 1
0 1 0 0 1 1 0 1 1 0
0 1 1 0 1 0 1 1 1 1
1 0 1 1 0 0 1 1 0 1
1 1 1 0 1 1 1 0 1 0
1 0 1 0 1 0 1 1 0 1
0 10 0 0 0 0 0 0 0 0

*/
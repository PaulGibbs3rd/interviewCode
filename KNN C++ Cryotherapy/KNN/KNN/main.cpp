#include <iostream>
#include <fstream>
#include <cmath> // The header file for math functions
#include <string> 
#include <algorithm>
#include <vector>
#include <random>
#include <time.h> 

using namespace std;

// Data structure to hold information about each entry
struct dataEntry
{
    int value;  // binary value, 0 = fail, 1 = pass
    double coord1, coord2; // data value 1 and 2, in this case will be numOfWarts and treatmentArea
    double distance; // distance from point being tested
};

// Function to compare two data entries to allow for them to be sorted based on distance
bool comparison(dataEntry a, dataEntry b)
{
    return (a.distance < b.distance);
}

// Function to classify a test data entry using the k nearest neighbour algorithm.
// This function assumes two groups and returns 0 for failed treatment and 1 for successful treatment.
int classifyADataEntry(vector<dataEntry> data, int k, dataEntry testData, int trainDataSize)
{
    // Calculate Euclidean distance from testData to every point
    for (int i = 0; i < trainDataSize; i++) {
        data[i].distance = sqrt((data[i].coord1 - testData.coord1) * (data[i].coord1 - testData.coord1) +
                                (data[i].coord2 - testData.coord2) * (data[i].coord2 - testData.coord2));
    }

    // Sort all points low to high based on distance from testData
    sort(data.begin(), data.end(), comparison);

    // Using first k nearest neighbours we can classify the testData
    int frequency1 = 0; // for result 1, treatment failed
    int frequency2 = 0; // for result 2, treatment successful
    for (int i = 0; i < k; i++) {
        if (data[i].value == 0)
            frequency1++;
        else if (data[i].value == 1)
            frequency2++;
    }

    // Return the result with the highest frequency
    return (frequency1 > frequency2 ? 0 : 1);
}

int main()
{
    // Create vectors to hold the training and test data
    vector<dataEntry> dataVector;
    vector<dataEntry> testDataVector;

    // Open the data file and read in the data
    ifstream readDataFile("data.txt");

    string buffer, subStrBuffer;
    double val1, val2;
    int result;
    while (getline(readDataFile, buffer)) {
        // Extract the data from each line and store it in a dataEntry structure
        subStrBuffer = buffer.substr(0, buffer.find('\t'));
        val1 = stoi(subStrBuffer);
        buffer = buffer.erase(0, subStrBuffer.length() + 1);
        subStrBuffer = buffer.substr(0, buffer.find('\t'));
        val2 = stoi(subStrBuffer);
        buffer = buffer.erase(0, subStrBuffer.length() + 1);
        result = stoi(buffer);

        // Store the data entry in the training data vector
        dataEntry tempData;
        tempData.coord1 = val1;
        tempData.coord2 = val2;
        tempData.value = result;
        dataVector.push_back(tempData);
    }
    readDataFile.close();

    // Split the data into training and test sets
    int trainDataSize = int(dataVector.size() * .9);
    int testDataSize = int(dataVector.size() * .1);
    srand(time(NULL));
    // Shuffle the training data to create a random test set
    for (int i = 0; i < testDataSize; i++) {
        int randInt = (rand() % (dataVector.size() - 1));
        testDataVector.push_back(dataVector[randInt]);
        dataVector.erase(dataVector.begin() + randInt);
    }

    // Loop through all possible values of k (from 1 to the size of the test data vector)
    for (int j = 1; j < 1 + testDataVector.size(); j++) {
        int k = j;
        int frequency1 = 0; // for result 1, treatment failed
        int frequency2 = 0; // for result 2, treatment successful

        // Loop through each test data entry and classify it using the k nearest neighbour algorithm
        for (int i = 0; i < testDataVector.size(); i++) {
            int testDataResult = classifyADataEntry(dataVector, k, testDataVector[i], trainDataSize);

            // Increment the appropriate frequency counter based on the classification result
            if (testDataVector[i].value == testDataResult)
                frequency1++;
            else
                frequency2++;
        }

    // Print the results for this value of k
    cout << endl << "K value = " << k << " KNN correct: " << frequency1 << " KNN wrong: " << frequency2;
	}

return 0;

}
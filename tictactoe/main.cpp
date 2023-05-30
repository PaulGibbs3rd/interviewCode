#include "mainwindow.h"
#include"gamedata.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
   // GameData * gBoard = new GameData();
    MainWindow w;
    w.show();
    return a.exec();
}

#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "gamedata.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
friend class GameData;
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
void on_button0_0_clicked();

void on_button0_1_clicked();

void on_button0_2_clicked();

void on_button1_0_clicked();

void on_button1_1_clicked();

void on_button1_2_clicked();

void on_button2_0_clicked();

void on_button2_1_clicked();

void on_button2_2_clicked();

void on_pushButtonReset_clicked();

private:
    Ui::MainWindow *ui;
    GameData * nBoard;                      // Simple check to see if user wishes to coninue playing (will reset array if yes)
    void disableAllButtons();
    void resetBoard();
};

#endif // MAINWINDOW_H

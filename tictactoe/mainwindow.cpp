#include "mainwindow.h"
#include "gamedata.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    nBoard = new GameData;
    ui->setupUi(this);
}
MainWindow::~MainWindow()
{
    delete nBoard;
    delete ui;
}

void MainWindow::on_button0_0_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button0_0->setText("O");
      nBoard->boardArray[0][0] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button0_0->setText("X");
      nBoard->boardArray[0][0] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
    ui->button0_0->setDisabled(true);
    nBoard->checkWinner();
    bool winner = nBoard->getWinner();
    if(winner == true)
    {
        if(player == 0)
        {
        QString str1 = QString::number(nBoard->winsP1);
        ui->p1Wins->setText(str1);
        nBoard->winsP1++;
        }
        else
        {
        QString str2 = QString::number(nBoard->winsP2);
        ui->p2Wins->setText(str2);
        nBoard->winsP2++;
        }
        disableAllButtons();
    }
}

void MainWindow::on_button0_1_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button0_1->setText("O");
      nBoard->boardArray[0][1] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button0_1->setText("X");
      nBoard->boardArray[0][1] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
    ui->button0_1->setDisabled(true);
    nBoard->checkWinner();
    bool winner = nBoard->getWinner();
    if(winner == true)
    {
        if(player == 0)
        {
        QString str1 = QString::number(nBoard->winsP1);
        ui->p1Wins->setText(str1);
        nBoard->winsP1++;
        }
        else
        {
        QString str2 = QString::number(nBoard->winsP2);
        ui->p2Wins->setText(str2);
        nBoard->winsP2++;
        }
        disableAllButtons();
    }
}

void MainWindow::on_button0_2_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button0_2->setText("O");
      nBoard->boardArray[0][2] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button0_2->setText("X");
      nBoard->boardArray[0][2] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button0_2->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button1_0_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button1_0->setText("O");
      nBoard->boardArray[1][0] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button1_0->setText("X");
      nBoard->boardArray[1][0] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button1_0->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button1_1_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button1_1->setText("O");
      nBoard->boardArray[1][1] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button1_1->setText("X");
      nBoard->boardArray[1][1] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button1_1->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button1_2_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button1_2->setText("O");
      nBoard->boardArray[1][2] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button1_2->setText("X");
      nBoard->boardArray[1][2] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button1_2->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button2_0_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button2_0->setText("O");
      nBoard->boardArray[2][0] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button2_0->setText("X");
      nBoard->boardArray[2][0] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button2_0->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button2_1_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button2_1->setText("O");
      nBoard->boardArray[2][1] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button2_1->setText("X");
      nBoard->boardArray[2][1] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button2_1->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}

void MainWindow::on_button2_2_clicked()
{
    int player = nBoard->setPlayer();
    if(player == 0)
    {
      ui->button2_2->setText("O");
      nBoard->boardArray[2][2] = 2;
      ui->labelPlayerTurn->setText("PLAYER 2's TURN");
    }
    if(player == 1)
    {
      ui->button2_2->setText("X");
      nBoard->boardArray[2][2] = 1;
      ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    }
      ui->button2_2->setDisabled(true);
      nBoard->checkWinner();
      bool winner = nBoard->getWinner();
      if(winner == true)
      {
          if(player == 0)
          {
          QString str1 = QString::number(nBoard->winsP1);
          ui->p1Wins->setText(str1);
          nBoard->winsP1++;
          }
          else
          {
          QString str2 = QString::number(nBoard->winsP2);
          ui->p2Wins->setText(str2);
          nBoard->winsP2++;
          }
          disableAllButtons();
      }
}
void MainWindow::disableAllButtons()
{
    ui->button0_0->setDisabled(true);
    ui->button0_1->setDisabled(true);
    ui->button0_2->setDisabled(true);
    ui->button1_0->setDisabled(true);
    ui->button1_1->setDisabled(true);
    ui->button1_2->setDisabled(true);
    ui->button2_0->setDisabled(true);
    ui->button2_1->setDisabled(true);
    ui->button2_2->setDisabled(true);
}
void MainWindow::resetBoard()
{
    ui->button0_0->setDisabled(false);
    ui->button0_1->setDisabled(false);
    ui->button0_2->setDisabled(false);
    ui->button1_0->setDisabled(false);
    ui->button1_1->setDisabled(false);
    ui->button1_2->setDisabled(false);
    ui->button2_0->setDisabled(false);
    ui->button2_1->setDisabled(false);
    ui->button2_2->setDisabled(false);
    ui->button0_0->setText("");
    ui->button0_1->setText("");
    ui->button0_2->setText("");
    ui->button1_0->setText("");
    ui->button1_1->setText("");
    ui->button1_2->setText("");
    ui->button2_0->setText("");
    ui->button2_1->setText("");
    ui->button2_2->setText("");
}

void MainWindow::on_pushButtonReset_clicked()
{
    resetBoard();
    nBoard->zeroArray();
    ui->labelPlayerTurn->setText("PLAYER 1's TURN");
    nBoard->playerCount = 1;
}

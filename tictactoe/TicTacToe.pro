#-------------------------------------------------
#
# Project created by QtCreator 2015-10-07T14:07:55
#
#-------------------------------------------------
QMAKE_LFLAGS += /INCREMENTAL:no
QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = TicTacToe
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    gamedata.cpp

HEADERS  += mainwindow.h \
    gamedata.h

FORMS    += mainwindow.ui

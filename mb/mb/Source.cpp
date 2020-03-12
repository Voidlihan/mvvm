#define _CRT_SECURE_NO_WARNINGS
#define _CRT_NONSTDC_NO_WARNINGS
#include <iostream>
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <stdio.h>
#include <time.h>
#include <ctime>
#include <fstream>
#pragma warning(disable:4996)
using namespace std;
struct LC { LC() { setlocale(LC_ALL, "rus"); srand(time(0)); }~LC() { cin.get(); cin.get(); } }l;
const int N = 10;

void mapa(int map[N][N]) {
  for (int i = 0; i < N; i++) {
    cout << "\t";
    for (int j = 0; j < N; j++) {
      cout << map[i][j] << " ";
    }
    cout << endl;
  }
}

void initships(int map[N][N]) {
  int x, y;
  cout << "Расставьте кораблик по x, y: ";
  cin >> x >> y;
  for (int i = 0; i < N; i++) {
    map[x][y] = 1;
  }
}

void initshipsBOT(int map[N][N]) {
  int x, y;
  for (int i = 0; i < N; i++) {
    x = rand() % 10;
    y = rand() % 10;
    map[x][y] = 1;
  }
}

bool proverka(int map[N][N], int x, int y) {
  for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
      if (map[x][y - 1] == ' ' && map[x - 1][y] == ' '
        && map[x + 1][y] == ' ' && map[x][y + 1] == ' ' &&
        map[x - 1][y - 1] == ' ' && map[x - 1][y + 1] == ' '
        && map[x + 1][y - 1] == ' '
        && map[x + 1][y + 1] == ' ') {
        return true;
        /*cout << "Выберите направление: " << endl;
        cout << "1.По вертикали" << endl;
        cout << "2.По горизонтали" << endl;
        cout << "Ваш выбор: ";
        int Vybor;
        cin >> Vybor;
        switch (Vybor){
        case 1: break;
        case 2: break;*/
      }
      else {
        return false;
      }
    }
  }
}

void hitshipsBOT(int map[N][N]) {
  int x, y;
  cout << endl;
  x = rand() % 10;
  y = rand() % 10;
  if (map[x][y] == 1) {
    map[x][y] = 0;
    bool sett = false;
    for (int i = 0; i < N; i++) {
      for (int j = 0; j < N; j++) {
        if (map[i][j] == 1) {
          sett = true;
          break;
        }
      }
    }
    if (sett == false) {
      cout << "Бот попал!" << endl;
    }
    else {
      cout << "Бот промазал!" << endl;
    }
  }
  else {
  }
}

void hitships(int map[N][N]) {
  int x, y;
  cout << endl;
  cout << "Введите координаты для выстрела: ";
  cin >> x;
  cin >> y;
  if (map[x][y] == 1) {
    cout << "Вы попали, ура!" << endl;
    map[x][y] = 0;
    bool sett = false;
    for (int i = 0; i < N; i++) {
      for (int j = 0; j < N; j++) {
        if (map[i][j] == 1) {
          sett = true;
          break;
        }
      }
    }
    if (sett == false) {
      cout << "Ура, победа!" << endl;
    }
  }
  else {
    cout << "Вы не попали, не переживайте!" << endl;
  }
}
void main() {
  int map[N][N] = { 0 };
  int x, y;
  cout << "Начните с x, а потом y и считайте с 0" << endl << endl;
  initships(map);
  cout << "Введите коорды куда хотите поставить корабль: ";
  cin >> x >> y;
  proverka(map, x, y);
  mapa(map);
  cout << endl;
  initshipsBOT(map);
  mapa(map);
  while (true) {

    hitships(map);
  }
} // мы старались
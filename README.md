# Bingo_Kata
### 關於這個套路 
- [TDD BUDDY](https://www.tddbuddy.com/katas/bingo.html) 
- [codewars](https://www.codewars.com/kata/566d5e2e57d8fae53c00000c) 

### 規則
- 賓果卡有 25 格
  - B 列範圍 1 - 15 
  - I 列範圍 16 - 30
  - N 列範圍 31 - 45 (第3格必須是 FREE SPACE)
  - G 列範圍 46 - 60
  - O 列範圍 61 - 75
- 賓果號碼
  - 數字介於 1 - 75 (遊戲中號碼不會重複)
- 檢查賓果卡
  - 賓果號碼在賓果卡必須連成垂直、水平或對角線才有賓果

```C#
  class BingoGame
    
    List<int> pickNumbers

    BingoCard bingoCard

    public void pickBall()
      var randomNumber = new Random();
      pickNumbers.push(randomNumber)
    
    internal void pickBall(int number)
      pickNumbers.push(number)
      pickNumbers.ForEach(number =>
      {
        for (int row = 0; row < _bingoCard.Card.GetLength(1); row++)
        {
          for (int col = 0; col < _bingoCard.Card.GetLength(0); col++)
          {
              if (_bingoCard.Card[row, col] == number)
              {
                  _bingoCard.CheckBingoNumber[row, col] = true;
              }
          }
        }
      })

    
    public List<string> GetLines()
      var bingoLines = new List<string>();
      var checkBingoNumber = _bingoCard.CheckBingoNumber;
      for(int i=0; i < checkBingoNumber.GetLength(0); i++)
      {
        // 檢查橫線
          if (checkBingoNumber[i, 0] && checkBingoNumber[i, 1]) {
              int index = i+1;
              bingoLines.Add("H"+(i+1))
          }
      }
      for (int j = 0; j < checkBingoNumber.GetLength(1); j++)
      {
          // 檢查直線
          if (checkBingoNumber[0, j] && checkBingoNumber[1, j] && checkBingoNumber[2, j]) {
              Console.Write("V"+(j+1));
          }

      }
      return bingoLines
```
```C#
  class BingoCard
    public int[,] Card { get; set; }
    public bool[,] CheckBingoNumber { get; set; }
```

### 測試案例
#### 賓果卡 (Bingo Card)
<img src="images/bingo-card.jpg" alt="image" width="50%">

#### 賓果線 (Bingo Line)
<img src="images/bingo-line.jpg" alt="image" width="50%">

#### `Vertical Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 2, 1, 11, 15] | [ "V1" ] |
| [28, 17, 29, 16, 22] | [ "V2" ] |
| [31, 45, 35, 41] | [ "V3" ] |
| [55, 59, 51, 48, 54] | [ "V4" ] |
| [61, 70, 74, 67, 65] | [ "V5" ] |

#### `Horizontal Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 28, 31, 55, 61] | [ "H1" ] |
| [2, 17, 45, 59, 70] | [ "H2" ] |
| [1, 29, 51, 74] | [ "H3" ] |
| [11, 16, 35, 48, 67] | [ "H4" ] |
| [15, 22, 41, 54, 66] | [ "H5" ] |

#### `Diagonal Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 17, 48, 66] | [ "D1" ] |
| [61, 59, 16, 15] | [ "D2" ] |

### `Multiple Lines`
| FakePickBallNumber | Output |
| :----: | :----: |
| [31, 45, 35, 41<br>1, 29, 51, 74] | [ "V3", "H3" ] |
| [10, 2, 1, 11, 15<br>15, 22, 41, 54, 66<br>61, 59, 16, 15] | [ "V1", "H5", "D2" ] |
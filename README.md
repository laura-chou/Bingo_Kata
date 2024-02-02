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
    
    public List<string> GetLines()
      var bingoLine = new List<string>();
      pickNumbers.ForEach(number =>
      {
        // 判斷number的是屬於哪一欄(B,I,N,G,O)
        var catrgory = GetCatrgory(number)
        // 檢查那一欄的數字是否有bingo
        if (category == Category.B) {
          bingoCard.B.ForEach(cardNumber => { 
              if (cardNumber.Number == number)
              {
                  number.IsBingo = true
              }
          });
        }
        // 檢查賓果線
        if (bingoCard.B.Count(number => number.IsBingo) == 5) {
          bingoLine.Add('V1')
        }
      })
      return bingoLine
```
```C#
  class BingoCard
    public List<CardNumber> B;
    public List<CardNumber> I;
    public List<CardNumber> N;
    public List<CardNumber> G;
    public List<CardNumber> O;
```
```C#
  class CardNumber
    public int Number { get; set; }  
    public bool IsBingo { get; set; }
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
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22] | [ "V1", "V2" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22,<br>31, 45, 35, 41] | [ "V1", "V2", "V3" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22<br>31, 45, 35, 41,<br>55, 59, 51, 48, 54] | [ "V1", "V2", "V3", "V4" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22<br>31, 45, 35, 41,<br>55, 59, 51, 48, 54,<br>61, 70, 74, 67, 65] | [ "V1", "V2", "V3", "V4", "V5" ] |

#### `Horizontal Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 28, 31, 55, 61] | [ "H1" ] |
| [10, 28, 31, 55, 61,<br>2, 17, 45, 59, 70] | [ "H1", "H2" ] |
| [10, 28, 31, 55, 61,<br>2, 17, 45, 59, 70,<br>1, 29, 51, 74] | [ "H1", "H2", "H3" ] |
| [10, 28, 31, 55, 61,<br>2, 17, 45, 59, 70,<br>1, 29, 51, 74,<br>11, 16, 35, 48, 67] | [ "H1", "H2", "H3", "H4" ] |
| [10, 28, 31, 55, 61,<br>2, 17, 45, 59, 70,<br>1, 29, 51, 74,<br>11, 16, 35, 48, 67,<br>15, 22, 41, 54, 66] | [ "H1", "H2", "H3", "H4", "H5" ] |

#### `Diagonal Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 17, 48, 66] | [ "D1" ] |
| [10, 17, 48, 66,<br>61, 59, 16, 15] | [ "D1", "D2" ] |
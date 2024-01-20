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

```js
  class BingoGame
    void pickBall()
      GetLines() => output [ 'L3','L8' ]
```

### 測試案例
#### 賓果卡 (Bingo Card)
<img src="images/bingo-card.jpg" alt="image" width="50%">

#### 賓果線 (Bingo Line)
<img src="images/bingo-line.jpg" alt="image" width="50%">

#### `Vertical Line`
| Input | Output |
| :----: | :----: |
| [10, 2, 1, 11, 15] | [ "V1" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22] | [ "V1", "V2" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22,<br>31, 45, 32, 35, 41] | [ "V1", "V2", "V3" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22<br>31, 45, 32, 35, 41,<br>55, 59, 51, 48, 54] | [ "V1", "V2", "V3", "V4" ] |
| [10, 2, 1, 11, 15,<br>28, 17, 29, 16, 22<br>31, 45, 32, 35, 41,<br>55, 59, 51, 48, 54,<br>61, 70, 74, 67, 65] | [ "V1", "V2", "V3", "V4", "V5" ] |

#### `Horizontal Line`
#### `Diagonal Line`

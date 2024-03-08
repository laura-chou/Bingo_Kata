# Bingo_Kata

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

### 測試案例
#### 賓果卡 (Bingo Card)
##### player A
<img src="images/bingo-card.jpg" alt="image" width="50%">

##### player B
<img src="images/bingo-card2.jpg" alt="image" width="50%">

#### 賓果線 (Bingo Line)
<img src="images/bingo-line.jpg" alt="image" width="50%">

#### `Vertical Line`
| FakePickBallNumber | Output |
| :----: | :----: |
| [10, 2, 1, 11, 15] | "player A win. player A get 1 Line(V1), player B get 0 Line. |

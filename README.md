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

### 測試案例
#### 產生賓果卡 (Bingo Card)
| 'B' | 'I' | 'N' | 'G' | 'O' |
| :----: | :----: | :----: | :----: | :----: |
| 10 | 25 | 31 | 55 | 61 |
| 2 | 17 | 45 | 59 | 70 |
| 1 | 29 | 'FREE SPACE' | 51 | 74 |
| 11 | 16 | 35 | 48 | 67 |
| 15 | 22 | 41 | '54 | 66 |

| test case |
| :----: |
| CreateColumnB  |
| CreateColumnI | 
| CreateColumnN | 
| CreateColumnG | 
| CreateColumnO |
| CreateBingoCard |

#### 產生賓果號碼 (Bingo Numbers)
['B10', 'I25', 'N31', 'G55', 'O61'] <br>
['B10', 'I14', 'N31', 'G48', 'O66'] <br>
['B15', 'I16', 'N31', 'G59', 'O61'] <br>
['I25', 'I14', 'I29', 'I16', 'I22']

| test case |
| :----: |
| CreateBRandomNumber |
| CreateIRandomNumber | 
| CreateNRandomNumber | 
| CreateGRandomNumber | 
| CreateORandomNumber |
| CreateRandomNumber |

#### 檢查賓果 (Bingo Line)
水平線 (vertical line) <br>
重直線 (horizontal line) <br>
對角線 (diagonal line)
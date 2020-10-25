## アサートファースト

テストを書くときは**アサーション**から書き始めるようにする。<br>
テストを書いているときは複数の問題を抱えがちなので、問題を「正しい結果は何か」と「それをどう検証するか」にわけて、それをテストに書くようにする。

例: `MoneyTest.cs`の異なる通貨の足し算のテスト

「正しい結果は何か」: $5 + 10CHF = $10(ドルとフランのレートが2:1のとき)
```cs
[Fact]
public void testMixedAddtion()
{
    Assert.Equal(Money.Dollar(10), result);
}
```

「それをどう検証するか」: 足し算後ドル換算した`result`ができるまでを少しずつ書いていく。
```cs
[Fact]
public void testMixedAddtion()
{
    var result = bank.Reduce(sum, "USD"); // 足し算した結果をドル換算に
    Assert.Equal(Money.Dollar(10), sum);
}
```

```cs
[Fact]
public void testMixedAddtion()
{
    var sum = Money.Dollar(5).Plus(Money.Franc(5)); // ドルとフランを足したオブジェクトを作る
    var result = bank.Reduce(sum, "USD"); // 足し算した結果をドル換算に
    Assert.Equal(Money.Dollar(10), sum);
}
```

## テストするもの
* 条件分岐
* ループ
* 操作
* ポリモフィズム

## 良くないテスト
* アサーションする対象のオブジェクトを作るのに大量のコードを書いているテスト
* テストの実行時間が長いテスト
* 前準備のコードが重複しているテスト
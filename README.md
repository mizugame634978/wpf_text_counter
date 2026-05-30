c#, wpfの基礎を学ぶための学習用プロジェクト。AIが作成した`仕様書.md`を元に実装する

# build and run

この階層で行う場合
```shell
# git bash
sh run.sh
```

# 学習メモ

## セッターに `=>` が使えない理由

`=>` は「1つの式」しか書けない。セッターで複数の処理（代入 + `OnPropertyChanged`）が必要な場合は使えない。

```csharp
// NG: 2つの文があるので => は使えない
set => { _value = value; OnPropertyChanged(nameof(Foo)); }

// OK: {} ブロックで複数処理を書く
set
{
    _value = value;
    OnPropertyChanged(nameof(Foo));
}
```

## 最終的な解決策: SetProperty

同じパターンのセッターが繰り返されるのを解消するには `SetProperty` ヘルパーメソッドを使う。

- **ライブラリを使う場合**: `CommunityToolkit.Mvvm` が提供する `[ObservableProperty]` 属性で自動生成できる
- **自前で作る場合**: `ViewModelBase` クラスに `SetProperty` を実装してプロジェクト全体で共有する

```csharp
// SetProperty を使うとセッターが1行になる
public int CharCount
{
    get => _charCount;
    set => SetProperty(ref _charCount, value);
}
```

今の学習段階では `INotifyPropertyChanged` を手書きして仕組みを理解することが優先。理解できたらライブラリや自前 `SetProperty` に移行する。

---

下の階層に移動して行う場合
```shell
░▒▓ 󰍲   …\wpf_text_counter\text_counter   main !   16:50 
❯ dotnet build text_counter.slnx  && dotnet run --project text_counter
```

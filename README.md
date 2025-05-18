# OpenVideoX
OpenVideoX OSS 動画編集ソフトの開発前段階としての Hello World アプリです。
OpenVideoX は C#＋Avalonia UI のクロスプラットフォーム対応動画編集ソフトを目指しています

aviutlのような多くの人が自由に使い倒せるソフトを作りたい。
ただし、OSSにすることで柔軟性の高いソフトを目指したい。

技術がないので、個人でつかえることを直近の目標に作ります！

## 要求

- .NET 8 SDK
- Avalonia UI 11.x

## ビルドと実行

```bash
git clone https://github.com/gladiiiii/OpenVideoX.git
cd HelloOpenVideoX/src/HelloOpenVideoX
dotnet restore
dotnet run